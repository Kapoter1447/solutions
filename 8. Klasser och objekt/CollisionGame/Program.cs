using System;
using System.Collections.Generic;
using System.Threading;

namespace CollisionGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            // To do: Sponsors to get money, giga rat attack, sleepiness, hunger/muscles,  steriods, rat gets bigger

            Tamagotchi();

            battle(10);
        }
        static void battle(int enemieCount)
        {
            #region initiering och deklarering
            string[,] playerIdleFrame = new string[4, 4]
            {
                {"", "O", "", ""},
                {"/", "|", "\\", ""},
                {"", "|", "", "\\", },
                {"/", "", "\\", ""}
            };

            string[,] playerAttackFrame = new string[4, 4]
            {
                {"", "O", "", "/"},
                {"/", "|", "/", ""},
                {"", "|", "", "", },
                {"/", "", "\\", ""}
            };

            string[,] enemyIdleFrame = new string[4, 12]
            {
                {"", "", "", "_","D", "D", "_", "_", "", "","","",},
                {"", "", "/", "O","O", " ", " ", " ", " ", "\\","_","_",},
                {"o", "_", "_", "_","_", "_", "_", "_", "/", "/","","",},
                {"", "I", "", "I","", "I", "", "I", "", "","","",}
            };

            string[,] catIdleFrame = new string[5, 12]
            {
                {"", "", "", "", "", "", "", "", "A", "_", "A", "",},
                {"|", "", "", "_", "_", "_", "_", "/", " ", "o", "o", "\\",},
                {"\\", "_", "/", " ", " ", " ", " ", " ", " ", ">", "*", "<",},
                {"", "", "\\", "_", "_", "_", "_", "_", "_", "_", "/", "",},
                {"", "", "", "L", "", "L", "", "L", "", "L", "", "",},
            };

            string[,] catShort = new string[4, 12]
            {
                {"", "", "", "", "", "", "", "", "A", "_", "A", "",},
                {"|", "", "", "_", "_", "_", "_", "/", " ", "o", "o", "\\",},
                {"\\", "_", "/", "_", "_", "_", "_", "_", "_", ">", "*", "<",},
                {"", "", "", "L", "", "L", "", "L", "", "L", "", "",},
            };

            string[,] tombStone = new string[4, 5]
            {
                {"", "", "", "", ""},
                {"", "_", "_", "_", ""},
                {"/", " ", " ", " ", "\\"},
                {"|", "R", "I", "P", "|"},
            };

            World calculation = new World(100,10);
            World visual = new World(100, 10);

            List<Object> enemies = new List<Object>();

            Object ground = new Object("g", 1, 1);
            
            Object player = new Object("p", 20, 7);
            player.health = 20;
            player.frames.Add(playerIdleFrame);

            Object sword = new Object("s", 1, 1);

            bool swordUsed = false;
            int pastI = 0;

            bool renderReduce = false;
            int renderSpeed = 50;

            int placedEnemies = 0;

            int i = 0;
            #endregion

            while (player.health > 0)
            {
                #region renderReduce
                if (i % renderSpeed == 0)
                {
                    renderReduce = true;
                }
                else
                {
                    renderReduce = false;
                }
                #endregion

                #region place
                // ÖVRIGT
                /*
                visual.Place(catShort, 20, 5);
                visual.Place(bowl, 35, 1);
                */
                visual.Place(catIdleFrame, 0, 4);
                visual.PlaceText("Undvik skada genom att först attackera och sen hoppa på råttornas näsor när de kommer för nära!", 0, 0, "horizontal");

                // FIENDE
                // Skapar fiende
                if (i%1000 == 0 && placedEnemies<enemieCount)
                {
                    string enemyName = "e" + placedEnemies.ToString(); // Har namnet 'e' + ett nummer för att de ska ha olika namn
                    enemies.Add(new Object(enemyName, 80, 1)); // Skapar en ny fiende

                    // Lägger til standarvärden för varje enemy
                    enemies[placedEnemies].frames.Add(enemyIdleFrame);
                    enemies[placedEnemies].health = placedEnemies+1;

                    placedEnemies++;
                }
                // Placerar fiende
                for (int a = 0; a < enemies.Count; a++)
                {
                    int eXPos = enemies[a].xPosition;
                    int eYPos = enemies[a].yPosition;

                    if (enemies[a].health > 0)
                    {
                        calculation.Place(enemies[a].id, eXPos, eYPos);
                        visual.Place(enemies[a].health.ToString(), enemies[a].xPosition + 4, enemies[a].yPosition - 5);
                    }
                    visual.Place(enemies[a].frames[0], enemies[a].xPosition, enemies[a].yPosition - 3);
                }

                // MARK
                for (int a = 0; a < 100; a++)
                {
                    calculation.Place(ground.id, a, 10);
                    visual.Place("=", a, 10);
                }

                // SPELARE
                calculation.Place(player.id, player.xPosition, player.yPosition);
                visual.Place(player.frames[0], player.xPosition - 1, player.yPosition - 3);
                visual.PlaceText(player.health.ToString(), player.xPosition-1, player.yPosition-5, "horizontal");

                // ATTACKS
                // Sword - När attack är använd sparas den nuvarande frame:en och en bool som säger att svärdet används sätt till true. Genom att ta skillnaden på antalet frames som gått överlag och de som gått när attacken aktiverades; fås hur många frames som appserat. Då kan jag göra så att svärdet är aktivit i ett visst antal frames. Sen sätts boolen till false.
                if (swordUsed)
                {
                    int framesPassed = i - pastI;

                    if (framesPassed < 100)
                    {
                        calculation.Place(sword.id, player.xPosition + 1, player.yPosition - 1);
                        calculation.Place(sword.id, player.xPosition + 2, player.yPosition - 1);
                        calculation.Place(sword.id, player.xPosition + 3, player.yPosition - 1);

                        player.frames.RemoveAt(0);
                        player.frames.Add(playerAttackFrame);
                    }
                    else
                    {
                        swordUsed = false;
                    }
                }
                else
                {
                    player.frames.RemoveAt(0);
                    player.frames.Add(playerIdleFrame);
                }
                #endregion

                #region enemy
                // GRAVITY
                for (int a = 0; a < enemies.Count; a++)
                {
                    if (enemies[a].health > 0) // Gör bara handlingar ifall lever
                    {
                        bool eTouchesGround = calculation.CheckCollision(enemies[a].id, ground.id, "down");
                        Console.WriteLine(eTouchesGround);
                        if (!eTouchesGround && renderReduce)
                        {
                            enemies[a].Move("down", 1);
                        }

                        // CHASE
                        int distance = player.xPosition - enemies[a].xPosition; // Ifall negativ är enemy till höger, positiv är till vänster

                        if (renderReduce)
                        {
                            if (calculation.CheckCollision(player.id, enemies[a].id))
                            {
                                // Stanna
                            }
                            else if (distance > 0)
                            {
                                enemies[a].Move("left", 1);
                            }
                            else if (distance < 0)
                            {
                                enemies[a].Move("left", 1);
                            }
                        }

                        // Knockback
                        if (calculation.CheckCollision(enemies[a].id, player.id, "up"))
                        {
                            enemies[a].Move("right", 40);
                        }

                        // Take damage
                        if (calculation.CheckCollision(enemies[a].id, sword.id) && renderReduce)
                        {
                            enemies[a].health--;
                        }
                    }
                    else // Ifall död ändra utseende till gravsten
                    {
                        enemies[a].frames.Remove(enemyIdleFrame);
                        enemies[a].frames.Add(tombStone);
                    }
                }
                #endregion

                #region player
                // Movement
                bool pTouchesGround = calculation.CheckCollision(player.id, ground.id, "down");

                if (Console.KeyAvailable == true)
                {
                    var keyPress = Console.ReadKey().Key;

                    // Ifall flera knappar kan vara intryckta samtidigt borde jag bara använda if satser för att kunna göra flera röresler samtidigt

                    switch (keyPress)
                    {
                        case ConsoleKey.W:
                            if (pTouchesGround)
                            {
                                player.Move("up", 5);
                            }
                            break;

                        case ConsoleKey.A:
                            player.Move("left", 1);
                            break;

                        case ConsoleKey.D:
                            player.Move("right", 1);
                            break;

                        case ConsoleKey.P:
                            swordUsed = true;
                            pastI = i;
                            break;

                        default:
                            break;
                    }
                }


                // GRAVITY
                if (!pTouchesGround && renderReduce)
                {
                    player.Move("down", 1);
                }

                // DAMAGE
                for (int a = 0; a < enemies.Count; a++)
                {
                    bool touchesEnemyLeft = calculation.CheckCollision(player.id, enemies[a].id, "right") || calculation.CheckCollision(player.id, enemies[a].id, "left");

                    if (touchesEnemyLeft && renderReduce)
                    {
                        player.health = player.health - 1;
                    }
                }
                #endregion

             //   calculation.Print();
                visual.Print();
                calculation.Clear();

                i++;
            }

            for (int b = 0; b < visual.y; b++)
            {
                for (int a = 0; a < visual.x; a++)
                {
                    visual.Place("¤", a, b);
                    visual.Print();
                }
            }
            Console.SetCursorPosition(visual.x/2, visual.y/2);
            Console.Write("YOU DIED");
            Console.ReadLine();
        }
        static void Tamagotchi()
        {
            string[,] syringeFrame = new string[3, 15]
            {
                {"", "", "", "", "", "", "", "", "", "", "(", ")", "", "", "",},
                {"-", "-", "[", "=", "=", "=", "=", "=", "=", "=", "=", "]", "-", "-", "|",},
                {"", "", "", "", "", "", "", "", "", "", "(", ")", "", "", "",},
            };

            string[,] catIdleFrame = new string[5, 12]
            {
                {"", "", "", "", "", "", "", "", "A", "_", "A", "",},
                {"|", "", "", "_", "_", "_", "_", "/", " ", "o", "o", "\\",},
                {"\\", "_", "/", " ", " ", " ", " ", " ", " ", ">", "*", "<",},
                {"", "", "\\", "_", "_", "_", "_", "_", "_", "_", "/", "",},
                {"", "", "", "L", "", "L", "", "L", "", "L", "", "",},
            };

            string[,] catTopLeft = new string[3, 6]
            {
                {"", "", "", "", "", "",},
                { "|", "", "", "_", "_", "_",},
                {"\\", "_", "/", " ", " ", " ", }
            };

            string[,] catTopRight = new string[3, 6]
            {
                {"", "", "A", "_", "A", "",},
                {"_", "/", " ", "o", "o", "\\",},
                {" ", " ", " ", ">", "*", "<",}
            };

            string[,] catBottomLeft = new string[2, 6]
            {
                {"", "", "\\", "_", "_", "_"},
                {"", "", "", "L", "", "L",},
            };

            string[,] catBottomRight = new string[2, 6]
            {
                {"_", "_", "_", "_", "/", "",},
                {"", "L", "", "L", "", "",},
            };

            string[,] catFillLeft = new string[1, 6]
            {
                {"", "", "|", " ", " ", " "},
            };

            string[,] catFillRight = new string[1, 6]
            {
                {" ", " ", " ", " ", "|", ""},
            };

            string[,] catFillTop = new string[6, 1]
            {
                {""},
                {"_"},
                {""},
                {""},
                {""},
                {""},
            };

            string[,] catFillBottom = new string[1, 1]
            {
                {"_"},
            };

            World visual = new World(100, 25);
            World calculation = new World(100,25);

            int syringeStart = 80;

            Object syringe = new Object("s", syringeStart,  5);
            Object cat = new Object("c", 1, 1);

            int currentX;
            int currentY;

            int catFillsHoriz = 5;
            int catFillsVerti = 5;

            bool renderReduce = false;
            int renderSpeed = 10;

            bool feeding = false;

            int fat = 0;
            int energy = 0;
            int mood = 0;

            int i = 0;
            int pastI = 0;

            while (true)
            {
                #region renderReduce
                if (i % renderSpeed == 0)
                {
                    renderReduce = true;
                }
                else
                {
                    renderReduce = false;
                }
                #endregion

                #region input
                if (Console.KeyAvailable == true)
                {
                    var keyPress = Console.ReadKey().Key;

                    // Ifall flera knappar kan vara intryckta samtidigt borde jag bara använda if satser för att kunna göra flera röresler samtidigt

                    switch (keyPress)
                    {
                        case ConsoleKey.F:
                            feeding = true;
                            pastI = i;
                            break;


                        default:
                            break;
                    }
                }
                #endregion

                #region place
                // Syringe
                calculation.Place(syringe.id, syringe.xPosition, syringe.yPosition);
            
                #region cat
                catFillsHoriz = fat*20;
                catFillsVerti = 0;

                // Calculation
                calculation.Place(cat.id, cat.xPosition, cat.yPosition +4);

                // Top cat
                currentX = cat.xPosition;
                currentY = cat.yPosition;

                visual.Place(catTopLeft, currentX, currentY);

                currentX = currentX + 6;
                for (int a = 0; a < catFillsHoriz; a++)
                {
                    visual.Place(catFillTop, currentX + a, currentY);
                }

                currentX = currentX + catFillsHoriz;
                visual.Place(catTopRight, currentX, currentY);

                // Middle cat
                currentX = cat.xPosition;
                currentY = cat.yPosition + 3;

                for (int a = 0; a < catFillsVerti; a++)
                {
                    visual.Place(catFillLeft, currentX, currentY + a);
                }

                currentX = currentX + 6 + catFillsHoriz;
                for (int a = 0; a < catFillsVerti; a++)
                {
                    visual.Place(catFillRight, currentX, currentY + a);
                }

                // Bottom cat
                currentX = cat.xPosition;
                currentY = cat.yPosition + 3 + catFillsVerti;

                visual.Place(catBottomLeft, currentX, currentY);

                currentX = currentX + 6;
                for (int a = 0; a < catFillsHoriz; a++)
                {
                    visual.Place(catFillBottom, currentX + a, currentY);
                }

                currentX = currentX + catFillsHoriz;
                visual.Place(catBottomRight, currentX, currentY);
                #endregion

                // Syringe
                int framesPassed = i - pastI;
                if (feeding)
                {
                    if (renderReduce)
                    {
                        syringe.Move("left", 1);
                    }

                    if (!calculation.CheckCollision(syringe.id, cat.id))
                    {
                        visual.Place(syringeFrame, syringe.xPosition, syringe.yPosition);
                    }
                    else
                    {
                        syringe.xPosition = syringeStart;
                        fat++;
                        feeding = false;
                    }
                }
                #endregion

             //   calculation.Print();
                visual.Print();

                calculation.Clear();
                i++;
            }
        }
    }
}
