using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CollisionGame
{
    class Program
    {
        static Actor cat = new Actor("c", 1, 0);

        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            int money = 10;

            Canvas visual = new Canvas(100, 25);

            string[,] catDead = new string[4, 12]
            {
                {"", "", "", "", "", "", "", "", "A", "_", "A", "",},
                {"", "", "", "_", "_", "_", "_", "/", " ", "x", "x", "\\",},
                {"", "_", "/", " ", " ", " ", " ", " ", " ", ">", "*", "<",},
                {"/", "", "\\", "b", "-", "b", "-", "b", "-", "b", "/", "",},
            };

            string[,] podium = new string[6, 12]
            {
                {"", "_", "_", "_", "_", "_", "_", "_", "_", "_", "_", "",},
                {"/", "", "", "", "", "", "", "", " ", "", "", "\\",},
                {"|", "", "", " ", " ", " ", " ", " ", " ", "", "", "|",},
                {"|", "", "", "", "", "#", "1", "", "", "", "", "|",},
                {"|", "", "", "", "", "", "", "", "", "", "", "|",},
                {"|", "", "", "", "", "", "", "", "", "", "", "|",},
            };

            bool alive = true; ;

            stopwatch.Start();

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            // To do: Sponsors to get money, giga rat attack, sleepiness, hunger/muscles, happiness,  steriods, (rat gets bigger),
            // Hur mycket pengar förlorades, sluta när fiender är döda, fiender ska inte kunanna gå in i varandra, mouse traps
            // Endings

            for (int i = 0; i < 2; i++)
            {
                alive = Tamagotchi(money);

                if (!alive)
                {
                    break;
                }

                battle(i+1*2, money);
            }

            // Endings
            if (alive)
            {
                int podiumOffset = -5;
                visual.PlaceRotated(bakeCat(cat.Muscles, 0, 0), 50 + podiumOffset, -10);
                visual.Place(podium, 50 + podiumOffset, 13);
                visual.Place(podium, 39 + podiumOffset, 15);
                visual.Place(podium, 61 + podiumOffset, 15);
                visual.Print();
                Console.ReadLine();

            }
            else
            {
                visual.Place(catDead, 0, 0);
                visual.Print();
                Console.ReadLine();
            }


        }

        static void battle(int enemieCount, int money) 
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

            string[,] moneyBag = new string[3, 5]
            {
                {"", "", "V", "", ""},
                {"", "/", " ", "\\", ""},
                {"(", " ", "$", " ", ")"},
            };

            string[,] bakedCat = bakeCat(1, 0, 4);

            Canvas calculation = new Canvas(100,10);
            Canvas visual = new Canvas(100, 10);

            List<Actor> enemies = new List<Actor>();

            Actor ground = new Actor("g", 1, 1);
            
            Actor player = new Actor("p", 20, 7);
            player.value = 20;
            player.frames.Add(playerIdleFrame);

            Actor sword = new Actor("s", 1, 1);

            Actor wallet = new Actor("m", 15, calculation.y-4);
            wallet.value = money;
            wallet.frames.Add(moneyBag);

            bool swordUsed = false;

            bool renderReduce = false;
            int renderSpeed = 50;

            string clock;

            int placedEnemies = 0;

            int i = 0;
            int pastI = 0;
            #endregion

            while (player.value > 0)
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
                visual.PlaceRotated(bakedCat, 0, 4);
                visual.PlaceText("Undvik skada genom att först attackera och sen hoppa på råttornas näsor när de kommer för nära!", 0, 0, "horizontal");

                // FIENDE
                // Skapar fiende
                if (i%1000 == 0 && placedEnemies<enemieCount)
                {
                    string enemyName = "e" + placedEnemies.ToString(); // Har namnet 'e' + ett nummer för att de ska ha olika namn
                    enemies.Add(new Actor(enemyName, 80, 1)); // Skapar en ny fiende

                    // Lägger til standarvärden för varje enemy
                    enemies[placedEnemies].frames.Add(enemyIdleFrame);
                    enemies[placedEnemies].value = placedEnemies+1;

                    placedEnemies++;
                }
                // Placerar fiende
                for (int a = 0; a < enemies.Count; a++)
                {
                    int eXPos = enemies[a].XPos;
                    int eYPos = enemies[a].YPos;

                    if (enemies[a].value > 0)
                    {
                        calculation.Place(enemies[a].id, eXPos, eYPos);
                        visual.Place(enemies[a].value.ToString(), enemies[a].XPos + 4, enemies[a].YPos - 5);
                    }
                    visual.Place(enemies[a].frames[0], enemies[a].XPos, enemies[a].YPos - 3);
                }

                // GROUND AND MAP
                for (int a = 0; a < 100; a++)
                {
                    calculation.Place(ground.id, a, 10);
                    visual.Place("=", a, 10);
                }

                // Instakillblock
                for (int a = 0; a < 4; a++)
                {
                    calculation.Place("i", calculation.x-4, a+6); 
                }

                // Take cash
                calculation.Place(wallet.id, wallet.XPos, wallet.YPos);
                visual.Place(wallet.frames[0], wallet.XPos, wallet.YPos);
                visual.Place(wallet.frames[0], wallet.XPos-3, wallet.YPos);

                // SPELARE
                calculation.Place(player.id, player.XPos, player.YPos);
                visual.Place(player.frames[0], player.XPos - 1, player.YPos - 3);
                visual.PlaceText(player.value.ToString(), player.XPos-1, player.YPos-5, "horizontal");

                // TIME
                TimeSpan time = stopwatch.Elapsed;
                clock = String.Format("{0}:{1}", time.Minutes, time.Seconds);
                visual.PlaceText("Clock: " + clock, 1, 2, "horizontal");

                // ATTACKS
                // Sword - När attack är använd sparas den nuvarande frame:en och en bool som säger att svärdet används sätt till true. Genom att ta skillnaden på antalet frames som gått överlag och de som gått när attacken aktiverades; fås hur många frames som appserat. Då kan jag göra så att svärdet är aktivit i ett visst antal frames. Sen sätts boolen till false.
                if (swordUsed)
                {
                    int framesPassed = i - pastI;

                    if (framesPassed < 100)
                    {
                        calculation.Place(sword.id, player.XPos + 1, player.YPos - 1);
                        calculation.Place(sword.id, player.XPos + 2, player.YPos - 1);
                        calculation.Place(sword.id, player.XPos + 3, player.YPos - 1);

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
                for (int a = 0; a < enemies.Count; a++)
                {
                    if (enemies[a].value > 0) // Gör bara handlingar ifall lever
                    {
                        // GRAVITY
                        bool eTouchesGround = calculation.CheckCollision(enemies[a].id, ground.id, "down");
                        Console.WriteLine(eTouchesGround);
                        if (!eTouchesGround && renderReduce)
                        {
                            enemies[a].Move("down", 1);
                        }

                        // CHASE
                        int distance = player.XPos - enemies[a].XPos; // Ifall negativ är enemy till höger, positiv är till vänster

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
                            enemies[a].value--;
                        }

                        if (calculation.CheckCollision(enemies[a].id, "i"))
                        {
                            enemies[a].value = 0;
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
                        player.value = player.value - 1;
                    }
                }
                #endregion

                //calculation.Print();
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
            Console.Write("YOUR STICKMAN DIED AND YOU LOST ALL YOUR MONEY");
            Console.ReadLine();
        }

        static bool Tamagotchi(int money)
        {
            #region init + dekl
            string[,] syringeFrame = new string[3, 15]
            {
                {"", "", "", "", "", "", "", "", "", "", "(", ")", "", "", "",},
                {"-", "-", "[", "=", "=", "=", "=", "=", "=", "=", "=", "]", "-", "-", "|",},
                {"", "", "", "", "", "", "", "", "", "", "(", ")", "", "", "",},
            };

            Canvas visual = new Canvas(100, 25);
            Canvas calculation = new Canvas(100, 25);

            int syringeStart = 80;
            Actor syringe = new Actor("s", syringeStart, calculation.y - 2);

            bool renderReduce = false;
            int renderSpeed = 10;

            int UIXpos = 70;
            int UIYpos;
            Dictionary<string, string> ui = new Dictionary<string, string>
            {
                {"Repleteness", "PR4; VA5; ACFeed;" }, // VA as i value, PR as in price, AC as in action
                {"Energy", "PR0; VA1; ACSleep;" },
                {"Mood", "PR1; VA7; ACPlay;" },
                {"Muscles", "PR2; VA10; ACWorkout;" },
            };

            int feedPrice = 4;
            int playPrice = 1;
            int workoutPrice = 2;
            int sleepPrice = 0;

            bool isAlive = true;
            bool noAfford = false;
            bool workouting = false;

            Stopwatch sWTamagotchi = new Stopwatch();
            sWTamagotchi.Start();
            bool timeUp = false;
            string clock;

            string[,] bakedCat = bakeCat(cat.Muscles, cat.XPos, cat.YPos);
            UpdateStats(cat, ui, bakedCat);

            int i = 0;
            int pastI = 0;

            #endregion

            while (isAlive && !timeUp)
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


                    switch (keyPress)
                    {
                        case ConsoleKey.Q:
                            if (money >= feedPrice)
                            {
                                cat.Feed();

                                money = money - feedPrice;
                                bakedCat = UpdateStats(cat, ui, bakedCat);
                            }
                            else
                            {
                                noAfford = true;
                                pastI = i;
                            }
                            break;

                        case ConsoleKey.W:
                            if (money >= sleepPrice)
                            {
                                cat.Sleep();

                                money = money - sleepPrice;
                                bakedCat = UpdateStats(cat, ui, bakedCat);
                            }
                            else
                            {
                                noAfford = true;
                                pastI = i;
                            }
                            break;

                        case ConsoleKey.E:
                            if (money >= playPrice)
                            {
                                cat.Play();

                                money = money - playPrice;
                                bakedCat = UpdateStats(cat, ui, bakedCat);
                            }
                            else
                            {
                                noAfford = true;
                                pastI = i;
                            }
                            break;

                        case ConsoleKey.R:
                            if (money >= workoutPrice)
                            {
                                workouting = true;
                                money = money - workoutPrice;
                            }
                            else
                            {
                                noAfford = true;
                                pastI = i;
                            }
                            break;

                        case ConsoleKey.I:
                            break;

                        default:
                            break;
                    }
                }
                #endregion

                #region place
                // SYRINGE
                calculation.Place(syringe.id, syringe.XPos, syringe.YPos);

                // CAT
                int catOffset = cat.Muscles * 2 + 8;
                visual.PlaceRotated(bakedCat, cat.XPos, cat.YPos);
                calculation.Place(cat.id, cat.XPos + catOffset, calculation.y - 2);

                // GROUND
                for (int a = 0; a < calculation.x; a++)
                {
                    visual.Place("=", a, calculation.y - 2);
                }

                // UI
                string value;
                UIYpos = 2;
                visual.PlaceText("Wallet:" + money + "$", UIXpos, UIYpos, "horizontal");
                UIYpos++;

                visual.PlaceText("___________", UIXpos, UIYpos, "horizontal");
                UIYpos = UIYpos + 3;

                foreach (KeyValuePair<string, string> element in ui)
                {
                    // name
                    visual.PlaceText(element.Key, UIXpos, UIYpos, "horizontal");

                    // status bar
                    UIYpos++;
                    value = SSID(element.Key, "VA", ";", ui);
                    visual.PlaceText("|>", UIXpos, UIYpos, "horizontal");

                    for (int a = 1; a < 11; a++)
                    {
                        if (a <= int.Parse(value))
                        {
                            visual.Place("¤", UIXpos + a, UIYpos);

                        }
                        else
                        {
                            visual.Place("-", UIXpos + a, UIYpos);

                        }
                    }

                    if (int.Parse(value) == 10)
                    {
                        visual.PlaceText("<|" + "HIGH!", UIXpos + 12, UIYpos, "horizontal");
                    }
                    else if (int.Parse(value) == 1)
                    {
                        visual.PlaceText("<|" + "LOW!", UIXpos + 12, UIYpos, "horizontal");
                    }
                    else
                    {
                        visual.PlaceText("<|" + value, UIXpos + 12, UIYpos, "horizontal");
                    }


                    // Action
                    UIYpos++;
                    value = SSID(element.Key, "AC", ";", ui);
                    string price = SSID(element.Key, "PR", ";", ui);

                    visual.PlaceText(value + " " + price + "$", UIXpos, UIYpos, "horizontal");

                    UIYpos++;
                    UIYpos++;
                }

                // Time
                TimeSpan time = stopwatch.Elapsed;
                clock = String.Format("{0}:{1}", time.Minutes, time.Seconds);
                visual.PlaceText("Clock: " + clock, 1, 100, "horizontal");

                // Instructions
              //  visual.PlaceText("GOAL: Give cat muscles to win muscle contest || Make all values stay between 1-10 or die", 1, 100, "horizontal");



                /*
                visual.PlaceText("Make all values stay between 1-10 or die", scrollText, 100, "horizontal");
                if (i%renderSpeed*120 == 0)
                {
                    scrollText++;
                }
                if (scrollText > 100)
                {
                    scrollText = -50;
                }
                */


                #endregion

                #region other
                // Workout (steriods)
                if (workouting)
                {
                    int syringeHeight = syringeFrame.GetLength(0);

                    if (renderReduce)
                    {
                        syringe.Move("left", 1);
                    }

                    if (!calculation.CheckCollision(syringe.id, cat.id))
                    {
                        visual.Place(syringeFrame, syringe.XPos, syringe.YPos - syringeHeight);
                    }
                    else
                    {
                        cat.WorkOut();

                        syringe.XPos = syringeStart;
                        workouting = false;


                        bakedCat = UpdateStats(cat, ui, bakedCat);
                    }
                }

                // No money warning
                if (noAfford)
                {
                    int framesPassed = i - pastI;

                    if (framesPassed < 200)
                    {
                        visual.PlaceText("MAN YOU ARE BROKE AND CANNOT AFFORD", 10, 10, "horizontal");
                    }
                    else
                    {
                        noAfford = false;
                    }


                }

                // Check if time is up
                if (sWTamagotchi.ElapsedMilliseconds > 10000)
                {
                    timeUp = true;
                }

                // Check if dead
                if (renderReduce)
                {
                    if (cat.Mood <= 0 || cat.Repleteness <= 0 || cat.Energy <= 0 || cat.Muscles <= 0)
                    {
                        isAlive = false;
                    }
                }
                #endregion

                // PRINT
                //calculation.Print();
                visual.Print();
                calculation.Clear();
                i++;
            }

            if (!isAlive)
            {
                for (int b = 0; b < visual.y; b++)
                {
                    for (int a = 0; a < visual.x; a++)
                    {
                        visual.Place("¤", a, b);
                        visual.Print();
                    }
                }

                Console.SetCursorPosition(visual.x / 2, visual.y / 2);
                Console.Write("YOU DIED");
                Console.ReadLine();
            }

            Console.Clear();

            return isAlive;
        }

        static string[,] bakeCat(int fatness, int startX, int startY)
        {
            #region cat frames

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
            #endregion

            Canvas cat = new Canvas(100, 50);

            fatness--;

            int currentX;
            int currentY;
            int offset = 18;

            int catFillsHoriz = fatness * 2;
            int catFillsVerti = fatness * 1;

            startY = startY - catFillsVerti;

            if (fatness >= 0)
            {
                // Top part
                currentX = startX;
                currentY = startY + offset;

                cat.Place(catTopLeft, currentX, currentY);

                currentX = currentX + 6;
                for (int a = 0; a < catFillsHoriz; a++)
                {
                    cat.Place(catFillTop, currentX + a, currentY);
                }

                currentX = currentX + catFillsHoriz;
                cat.Place(catTopRight, currentX, currentY);

                // Middle part
                currentX = startX;
                currentY = startY + 3 + offset;

                for (int a = 0; a < catFillsVerti; a++)
                {
                    cat.Place(catFillLeft, currentX, currentY + a);
                }

                currentX = currentX + 6 + catFillsHoriz;
                for (int a = 0; a < catFillsVerti; a++)
                {
                    cat.Place(catFillRight, currentX, currentY + a);
                }

                // Bottom part
                currentX = startX;
                currentY = startY + 3 + catFillsVerti + offset;

                cat.Place(catBottomLeft, currentX, currentY);

                currentX = currentX + 6;
                for (int a = 0; a < catFillsHoriz; a++)
                {
                    cat.Place(catFillBottom, currentX + a, currentY);
                }

                currentX = currentX + catFillsHoriz;
                cat.Place(catBottomRight, currentX, currentY);

            }
            else
            {
                cat.Place(catShort, startX, startY + offset);
            }

            return cat.canvArray;


        }

        static string[,] UpdateStats(Actor cat, Dictionary<string,string> ui, string[,] bakedcat)
        {
            // Update stats
            RSID("Repleteness", "VA", ";", ui);
            LSID("Repleteness", "VA" + cat.Repleteness + ";", ui);

            RSID("Energy", "VA", ";", ui);
            LSID("Energy", "VA" + cat.Energy + ";", ui);

            RSID("Mood", "VA", ";", ui);
            LSID("Mood", "VA" + cat.Mood + ";", ui);

            RSID("Muscles", "VA", ";", ui);
            LSID("Muscles", "VA" + cat.Muscles + ";", ui);

            return bakeCat(cat.Muscles, cat.XPos, cat.YPos);
            
        }

        static string SSID(string sökNyckel, string startOrd, string stopOrd, Dictionary<string, string> dic)
        {
            // Sök substring i dictionary

            int sökPlats;
            int start = 0;
            int stop = 0;

            string returString = "";

            foreach (KeyValuePair<string, string> föremål in dic)
            {
                if (sökNyckel == föremål.Key)
                {
                    sökPlats = 0;
                    while (true)
                    {
                        start = föremål.Value.IndexOf(startOrd, sökPlats);
                        // IndexOf returnerar -1 ifall inte hittar något, isåfall break;
                        if (start == -1)
                            break;
                        else
                            start = start + startOrd.Length;

                        stop = föremål.Value.IndexOf(stopOrd, start);
                        sökPlats = stop;

                        string resultat = föremål.Value.Substring(start, stop - start);
                        returString = returString + resultat + "¤";
                    }
                }
            }
            if (returString == "")
            {
                returString = "null";
            }
            else
            {
                // Tar bort sista ¤
                returString = returString.Remove(returString.Length - 1);
            }

            return returString;
        }

        static void RSID(string sökNyckel, string startOrd, string stopOrd, Dictionary<string, string> dic)
        {
            // Radera substring i dictionary

            int sökPlats;
            int start = 0;
            int stop = 0;

            string resultat = "";

            foreach (KeyValuePair<string, string> föremål in dic)
            {
                if (sökNyckel == föremål.Key)
                {
                    sökPlats = 0;
                    while (true)
                    {
                        start = föremål.Value.IndexOf(startOrd, sökPlats);
                        // IndexOf returnerar -1 ifall inte hittar något, isåfall break;
                        if (start == -1)
                            break;
                        else
                            start = start + startOrd.Length;

                        stop = föremål.Value.IndexOf(stopOrd, start);
                        sökPlats = stop;

                        // Start-2 för att ta bort identifierare t.ex "VA eller BE" och sedan +3 för att få bort ";".
                        resultat = föremål.Value.Remove(start - 2, stop - start + 3);

                    }
                }
            }
            dic.Remove(sökNyckel);
            dic.Add(sökNyckel, resultat);
        }

        static void LSID(string nyckel, string attLäggaTill, Dictionary<string, string> dic)
        {
            // Lägg till substring i dictionary
            string värde = "";

            foreach (KeyValuePair<string, string> item in dic)
            {
                if (item.Key == nyckel)
                {
                    värde = item.Value + attLäggaTill;
                }
            }
            dic.Remove(nyckel);
            dic.Add(nyckel, värde);

        }


    }
}


