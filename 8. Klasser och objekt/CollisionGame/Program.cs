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

            battle(10);

            #region gammal kod
            /*
            #region initialisering och deklarering
            Console.CursorVisible = false;

            World calculation = new World(100,10);
            World visual = new World(100, 10);

            Object player = new Object("p", 1, 1);
            player.health = 10;

            // Göra lista sen så att man kan spawna hur som helst utan att bry sig om längden
            //Object[] enemies = new Object[10];

            List<Object> enemies = new List<Object>();

            Object enemy = new Object("e", 50, 1);
            enemy.health = 5;

            Object ground = new Object("g", 1, 1);

            // Prakiskt om den kan ta en vanlig string och dela upp den i en array så slipper man det här:
            string[,] playerIdleFrame = new string[4, 4]
            {
                {"", "O", "", ""},
                {"/", "|", "\\", ""},
                {"", "|", "", "", },
                {"/", "", "\\", ""}
            };

            string[,] playerAttackFrame = new string[4, 4]
            {
                {"", "O", "", "+"},
                {"/", "|", "/", ""},
                {"", "|", "", "", },
                {"/", "", "\\", ""}
            };

            string[,] enemyFrame1 = new string[4, 12]
            {
                {"", "", "", "_","D", "D", "_", "_", "", "","","",},
                {"", "", "/", "O","O", " ", " ", " ", " ", "\\","_","_",},
                {"o", "_", "_", "_","_", "_", "_", "_", "/", "","","",},
                {"", "I", "", "I","", "I", "", "I", "", "","","",}
            };

            string[,] groundArray1 = new string[1, 1]
            {
                {"g"},
            };


            bool renderReduce = false;
            int renderSpeed = 50;
            int i = 0;

            #endregion




            battle(3);

            



            // waste kod atm
            while (true)
            {
                
                #region renderReduce
                if (i%renderSpeed == 0)
                {
                    renderReduce = true;
                }
                else
                {
                    renderReduce = false;
                }
                #endregion

                #region place
                // FIENDE
                // SPAWN
                for (int e = 0; e < enemies.Count; e++)
                {
                    enemies[e] = new Object("e", 100, 1);
                }
                // sen en loop för att placea alla enemies

                
                calculation.Place(enemy.id, enemy.xPosition, enemy.yPosition);
                visual.Place(enemyFrame1, enemy.xPosition-1, enemy.yPosition-3);
                visual.Place(enemy.health.ToString(), enemy.xPosition+4, enemy.yPosition-5);
                

                for (int e = 0; e < enemies.Count; e++)
                {
                    Console.WriteLine(enemies[e].id);
                    calculation.Place(enemies[e].id, enemies[e].xPosition, enemies[e].yPosition);
                }
                // På något sätt ge en bokstav i calculation 
                // Sätta ut fiender on command

                // SPELARE
                calculation.Place(player.id, player.xPosition, player.yPosition);
                visual.Place(playerIdleFrame, player.xPosition - 1, player.yPosition - 3);

                // MARK
                for (int a = 0; a < 100; a++)
                {
                    calculation.Place(groundArray1, a, 10);
                    visual.Place("=", a, 10);
                }

                // TEXT
                string hpText = "HP: " + player.health;
                visual.PlaceText(hpText, 1, 1, "horizontal");
                #endregion

                #region enemy
                // GRAVITY
                bool eTouchesGround = calculation.CheckCollision(enemy.id, ground.id, "down");
                if (!eTouchesGround && renderReduce)
                {
                    enemy.Move("down", 1);
                }

                // CHASE
                int distance = player.xPosition - enemy.xPosition; // Ifall negativ är enemy till höger, positiv är till vänster

                if (renderReduce)
                {
                    if (calculation.CheckCollision(player.id, enemy.id))
                    {
                        // Stanna
                    }
                    else if (distance > 0)
                    {
                        enemy.Move("left", 1);
                    }
                    else if (distance < 0)
                    {
                        enemy.Move("left", 2);
                    }
                }

                // TAKE DAMAGE
                if (calculation.CheckCollision(enemy.id, player.id, "up"))
                {
                    enemy.Move("right", 40);
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
                            
                        case ConsoleKey.S:
                            player.Move("down", 1);
                            break;
                            
                        case ConsoleKey.D:
                            player.Move("right", 1);
                            break;

                        case ConsoleKey.Spacebar:
                            playerAttack(player);
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
                bool touchesEnemyLeft = calculation.CheckCollision(player.id, enemy.id, "right");

                if (touchesEnemyLeft && renderReduce)
                {
                    player.health = player.health - 1;
                }
                #endregion

                // PRINT
                calculation.Print();
                visual.Print();
                calculation.Clear();

                i++; 

            }
            */
            #endregion
        }

        static void battle(int enemieCount)
        {
            #region initiering och deklarering
            string[,] playerIdleFrame = new string[4, 4]
            {
                {"", "O", "", ""},
                {"/", "|", "\\", ""},
                {"", "|", "", "", },
                {"/", "", "\\", ""}
            };

            string[,] playerAttackFrame = new string[4, 4]
            {
                {"", "O", "", "+"},
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

            string[,] bowl = new string[4, 4]
            {
                {"", "", "", ""},
                {"", "", "", ""},
                {"-", " ", " ", "-"},
                {"\\", "_", "_", "/"}
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
            player.health = 100;
            player.frames.Add(playerIdleFrame);
            player.frames.Add(playerAttackFrame);

            Object sword = new Object("s", 1, 1);

            bool swordUsed = false;
            int pastI = 0;

            bool renderReduce = false;
            int renderSpeed = 50;

            int placedEnemies = 0;
            int deadEnemies = 0;

            int i = 0;
            #endregion

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

                #region place
                // SPELARE
                calculation.Place(player.id, player.xPosition, player.yPosition);
                visual.Place(player.frames[0], player.xPosition - 1, player.yPosition - 3);

                // CAT/FOOD
                /*
                visual.Place(catShort, 20, 5);
                visual.Place(bowl, 35, 1);
                */
                visual.Place(catIdleFrame, 0, 4);

                // FIENDE --- När dödar en fiende så ändras övriga fienders plats i dictionaryn vilket skapar problem.
                // Skapar fiende
                if (i%1000 == 0 && placedEnemies<enemieCount)
                {
                    string enemyName = "e" + placedEnemies.ToString(); // Har namnet 'e' + ett nummer för att de ska ha olika namn
                    enemies.Add(new Object(enemyName, 80, 1)); // Skapar en ny fiende

                    // Lägger til standarvärden för varje enemy
                    enemies[placedEnemies].frames.Add(enemyIdleFrame);
                    enemies[placedEnemies].health = 2;

                    placedEnemies++;
                }
                // Placerar fiende
                for (int a = 0; a < enemies.Count; a++)
                {
                    int eXPos = enemies[a].xPosition;
                    int eYPos = enemies[a].yPosition;
                    calculation.Place(enemies[a].id, eXPos, eYPos);
                    visual.Place(enemies[a].frames[0], enemies[a].xPosition - 1, enemies[a].yPosition - 3);
                    visual.Place(enemies[a].health.ToString(), enemies[a].xPosition + 4, enemies[a].yPosition - 5);
                }

                // MARK
                for (int a = 0; a < 100; a++)
                {
                    calculation.Place(ground.id, a, 10);
                    visual.Place("=", a, 10);
                }

                // ATTACKS
                // Sword - När attack är använd sparas den nuvarande frame:en och en bool som säger att svärdet används sätt till true. Genom att ta skillnaden på antalet frames som gått överlag och de som gått när attacken aktiverades; fås hur många frames som appserat. Då kan jag göra så att svärdet är aktivit i ett visst antal frames. Sen sätts boolen till false.
                // Placerad efter kollision
                if (swordUsed)
                {
                    int framesPassed = i - pastI;

                    if (framesPassed < 200)
                    {
                        calculation.Place(sword.id, player.xPosition + 1, player.yPosition - 1);
                        calculation.Place(sword.id, player.xPosition + 2, player.yPosition - 1);
                    }
                    else
                    {
                        swordUsed = false;
                    }
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
                                enemies[a].Move("right", 1);
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
                        if (calculation.CheckCollision(enemies[a].id, sword.id))
                        {
                            enemies[a].health--;
                            enemies[a].Move("right", 1);
                            deadEnemies++;
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

                        case ConsoleKey.Spacebar:
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
                    bool touchesEnemyLeft = calculation.CheckCollision(player.id, enemies[a].id, "right");

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
            Console.WriteLine("\nIt's over...");
            Console.ReadLine();
        }


    }



}
