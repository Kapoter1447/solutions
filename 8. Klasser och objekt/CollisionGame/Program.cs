using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CollisionGame
{

    class Program
    {
        static Actor cat = new Actor("c", 1, 0);

        static Dictionary<string, string> stats = new Dictionary<string, string>
        {
            {"Repleteness", "PR4; VA5; ACFeed; COQ;" }, // VA as i health, PR as in price, AC as in action
            {"Energy", "PR0; VA1; ACSleep; COW;" },
            {"Mood", "PR1; VA7; ACPlay; COE;" },
            {"Muscles", "PR2; VA10; ACWorkout; COR;" },
        };

        static Dictionary<string, string> sponsors = new Dictionary<string, string>
        {
                {"Fasebook", "MO3;"},
                {"Besla: Cars and bots", "MO10;"},
                {"Doening Airplanes", "MO5;"},
                {"ICA crypto currency", "MO1;"},
                {"AMOGUS VR", "MO7;"},
        };

        static Stopwatch stopwatch = new Stopwatch();

        static int money = 10;

        static string currentSponsor = ""; 


        static void Main(string[] args)
        {

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
            string[,] signL = new string[6, 1]
            {
                {""},
                {"/"},
                {"|"},
                {"|"},
                {"|"},
                {"\\"},
            };
            string[,] signM = new string[6, 1]
            {
                {"_"},
                {""},
                {""},
                {""},
                {""},
                {"_"},
            };
            string[,] signR = new string[6, 1]
            {
                {""},
                {"\\"},
                {"|"},
                {"|"},
                {"|"},
                {"/"},
            };

            bool alive = true;

            TimeSpan time = new TimeSpan();

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            #region Intro
            
            int signX = visual.x;
            int signOffset = 15;

            for (int i = 0; i < 80; i++)
            {
                visual.Place(signL, signOffset+signX, visual.y / 2);
                signOffset++;

                visual.PlaceText("CAT MUSCLE CONTEST", signOffset+signX, visual.y/2+1);
                visual.PlaceText("AT 3:0PM", signOffset + signX, visual.y / 2 + 2);
                visual.PlaceText("'Gains Gain Gains'", signOffset + signX, visual.y / 2 + 3);
                visual.PlaceText("Sponsors available!", signOffset + signX, visual.y / 2 + 4);

                //visual.PlaceText("Click 'i' för instructions in game!", 40 + signX, visual.y-2);
                visual.PlaceText("Click Enter To Proceed...", 40 + signX, visual.y-1);

                visual.PlaceText("A game by Kasper Larsson", 0, 0, "vertical");

                for (int a = 0; a < 20; a++)
                {
                    visual.Place(signM, signOffset + signX, visual.y / 2);
                    signOffset++;
                }
                visual.Place(signR, signOffset + signX, visual.y / 2);

                visual.Print();
                Thread.Sleep(20);

                signOffset = 0;
                signX--;
            }

            Console.ReadLine();
            #endregion

            stopwatch.Start();

            while (true)
            {
                // Tamagotchi phase
                alive = Tamagotchi();

                // Break if time is up or cat is dead
                time = stopwatch.Elapsed;
                if (!alive)
                {
                    break;
                }
                else if (time.Minutes >= 3)
                {
                    break;
                }

                int sponsorPayment = int.Parse(SSID(currentSponsor, "MO", ";", sponsors));

                // Battle phase
                alive = Battle(sponsorPayment);

                // Break if time is up or cat is dead
                time = stopwatch.Elapsed;
                if (!alive)
                {
                    break;
                }
                else if (time.Minutes >= 3)
                {
                    break;
                }
            }

            // Endings
            if (alive)
            {
                int podiumOffset = -5;
                visual.PlaceRotated(BakeCat(cat.Muscles, 0, 0), 50 + podiumOffset, -10);
                visual.PlaceText("Score/Muscle Mass: " + cat.Muscles, 50, 10);
                visual.Place(podium, 50 + podiumOffset, 13);
                visual.Place(podium, 39 + podiumOffset, 15);
                visual.Place(podium, 61 + podiumOffset, 15);
                visual.Print();
                Console.ReadLine();

            }
            else
            {
                visual.Place(catDead, 0, 0);
                visual.PlaceText("You are a bad pet owner and your cat died... Program will now close", 30, visual.y/2);
                visual.Print();
                Thread.Sleep(4000);
            }


        }

        static void Tutorial()
        {

        }

        static bool Battle(int enemieCount) 
        {
            #region initiering och deklarering
            string[,] sponsorFrame = new string[4, 4]
            {
                {"", "O", "", ""},
                {"/", "|", "\\", ""},
                {"", "|", "", "", },
                {"/", "", "\\", ""}
            };

            string[,] sponsorFrame2 = new string[6, 4]
            {
                {"", "$", "", ""},
                {"", "", "", ""},
                {"", "O", "", ""},
                {"\\", "|", "/", ""},
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
                {"/", " ", "$", " ", "\\"},
                {"|", "R", "I", "P", "|"},
            };

            string[,] moneyBag = new string[3, 5]
            {
                {"", "", "V", "", ""},
                {"", "/", " ", "\\", ""},
                {"(", " ", "$", " ", ")"},
            };

            string[,] bakedCat = BakeCat(cat.Muscles, 0, 0);

            Canvas calculation = new Canvas(100, 25);
            Canvas visual = new Canvas(100, 25);

            List<Actor> enemies = new List<Actor>();

            Actor ground = new Actor("g", 1, 1);
            
            Actor player = new Actor("p", 20, 7);
            player.health = 20;
            player.frames.Add(bakedCat);

            Actor sword = new Actor("s", 1, 1);

            Actor wallet = new Actor("m", 15, calculation.y-3);
            wallet.health = money;
            wallet.frames.Add(moneyBag);

            bool attacking = false;

            bool tutorialActive = true;

            bool renderReduce = false;
            int renderSpeed = 30;

            string clock;

            int placedEnemies = 0;
            bool enemiesAlive = true;
            bool enemyKilled = false;
            int enemyFrameCounter = 0;

            int i = 0;
            int pastI = 0;
            #endregion

            #region tutorial
            stopwatch.Stop();
            int textX = 20;
            int textY = 10;

            visual.PlaceText("Kill rats to impress sponsor", textX, textY);
            visual.PlaceText("Rats eat your money if they get to your wallet", textX, textY+1);

            visual.PlaceText("Cat stats have impact on game:", textX, textY+3);
            visual.PlaceText("* Muscles - Makes cat bigger (Muscly cat makes cat large)", textX, textY+4);
            visual.PlaceText("* Mood - Increases attack range (Happy cat gives better fighting perfomance)", textX, textY+5);
            visual.PlaceText("* Repleteness - Decreases jump height (Fat cat can't jump)", textX, textY+6);
            visual.PlaceText("* Energy - Increases movement speed (Alert cat moves faster)", textX, textY+7);

            visual.PlaceText("IF YOU DIE, YOU DIE", textX, textY + 9);

            visual.PlaceText("Click 'Enter' To Proceed", textX, textY+11);


            visual.Print();

            Console.ReadLine();
            stopwatch.Start();
            #endregion

            while (player.health > 0 && enemiesAlive)
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
                // Tutorial
                if (tutorialActive)
                {
                    visual.PlaceText("W, A and D - Movement", 1 ,9);
                    visual.PlaceText("Spacebar - Attack", 1, 10);
                }

                // ENEMY
                // Create enemies
                if (i%1000 == 0 && placedEnemies<enemieCount)
                {
                    string enemyName = "e" + placedEnemies.ToString(); // Every name should be uniqe. A number is added after the name
                    enemies.Add(new Actor(enemyName, 80, calculation.y - 10));

                    // Adds standard values for every enemy
                    enemies[placedEnemies].frames.Add(enemyIdleFrame);
                    enemies[placedEnemies].health = placedEnemies+1;

                    placedEnemies++;
                }
                // Placerar fiende
                for (int a = 0; a < enemies.Count; a++)
                {
                    int eXPos = enemies[a].XPos;
                    int eYPos = enemies[a].YPos;

                    if (enemies[a].health > 0)
                    {
                        calculation.Place(enemies[a].id, eXPos, eYPos);
                        visual.Place(enemies[a].health.ToString(), enemies[a].XPos + 4, enemies[a].YPos - 5);
                    }
                    visual.Place(enemies[a].frames[0], enemies[a].XPos, enemies[a].YPos - 3);

                    if (tutorialActive && enemies[a].health > 0)
                    {
                        visual.PlaceText("Rat", enemies[a].XPos + 3, enemies[a].YPos - 1);
                        visual.PlaceText("Rat Health -->", enemies[a].XPos - 12, enemies[a].YPos - 5);
                    }
                    else if (tutorialActive)
                    {
                        visual.PlaceText("Dead Rat", enemies[a].XPos, enemies[a].YPos - 1);
                    }
                }

                // GROUND AND MAP
                for (int a = 0; a < 100; a++)
                {
                    calculation.Place(ground.id, a, calculation.y-2);
                    visual.Place("=", a, calculation.y-2);
                }
                for (int a = 0; a < 30; a++)
                {
                    calculation.Place(ground.id, 70+a, calculation.y - 5);
                    visual.Place("=", 70+a, calculation.y - 5);
                }

                // Instakillblock
                for (int a = 0; a < 4; a++)
                {
                    calculation.Place("i", calculation.x-4, calculation.y-2-a); 
                }

                // Take cash
                calculation.Place(wallet.id, wallet.XPos, wallet.YPos);
                visual.Place(wallet.frames[0], wallet.XPos, wallet.YPos-2);
                visual.Place(wallet.frames[0], wallet.XPos-3, wallet.YPos-2);
                visual.PlaceText(money.ToString() + "$", wallet.XPos-1, wallet.YPos-4);
                
                if (tutorialActive)
                {
                    visual.PlaceText("Your wallet. Protect it from rats", wallet.XPos - 7, wallet.YPos+2);
                }

                // PLAYER
                int pYOffset = -22;
                int pXOffset = -1;

                int catWidth = ((cat.Muscles - 2) * 2) + 9;

                for (int a = 2; a < catWidth; a++)
                {
                    calculation.Place(player.id, player.XPos + a, player.YPos);
                }
                visual.PlaceRotated(player.frames[0], player.XPos + pXOffset, player.YPos + pYOffset);
                visual.PlaceText(player.health.ToString(), player.XPos-1, player.YPos-5);

                if (tutorialActive)
                {
                    visual.PlaceText("Health-->", player.XPos - 11, player.YPos - 5);
                }

                // SPONSOR
                int sponsorY = 5;
                int sponsorX = visual.x/2;

                if (enemyKilled)
                {
                    visual.Place(sponsorFrame2, sponsorX, sponsorY - 2);
                    visual.Place(sponsorFrame2, sponsorX + 4, sponsorY - 2);
                    visual.Place(sponsorFrame2, sponsorX + 8, sponsorY - 2);

                    int happySponsorsFrames = 200;
                    if (enemyFrameCounter < happySponsorsFrames)
                    {
                        enemyFrameCounter++;
                    }
                    else
                    {
                        enemyFrameCounter = 0;
                        enemyKilled = false;
                    }
                }
                else
                {
                    visual.Place(sponsorFrame, sponsorX, sponsorY);
                    visual.Place(sponsorFrame, sponsorX + 4, sponsorY);
                    visual.Place(sponsorFrame, sponsorX + 8, sponsorY);
                }
                visual.PlaceText(currentSponsor, sponsorX - 1, sponsorY + 4);

                // TIME
                TimeSpan time = stopwatch.Elapsed;
                clock = String.Format("{0}:{1}", time.Minutes, time.Seconds);
                visual.PlaceText("Clock: " + clock, 1, 2);

                // Attack - När attack är använd sparas den nuvarande frame:en och en bool som säger att svärdet används sätt till true. Genom att ta skillnaden på antalet frames som gått överlag och de som gått när attacken aktiverades; fås hur många frames som appserat. Då kan jag göra så att svärdet är aktivit i ett visst antal frames. Sen sätts boolen till false.
                if (attacking)
                {
                    int framesPassed = i - pastI;

                    if (framesPassed < 100)
                    {
                        int attackMultiplier = int.Parse(SSID("Mood", "VA", ";", stats));

                        for (int a = 0; a < attackMultiplier; a++)
                        {
                            calculation.Place(sword.id, player.XPos + catWidth + a, player.YPos - 1);
                        }

                        // Creates foot 
                        string[,] foot = new string[1,attackMultiplier];

                        for (int a = 0; a < attackMultiplier-2; a++)
                        {
                            foot[0, a] = "-";
                        }
                        int footClamp = Math.Clamp(attackMultiplier-2, 0, attackMultiplier); 
                        
                        foot[0, footClamp] = "I";
                        visual.Place(foot, player.XPos + catWidth + 1, player.YPos - 1);

                    }
                    else
                    {
                        attacking = false;
                    }
                }
                else
                {
                  //  player.frames.RemoveAt(0);
                  //  player.frames.Add(sponsorFrame);
                }
                #endregion

                #region enemy
                int enemiesDead = 0;
                for (int a = 0; a < enemies.Count; a++)
                {
                    if (enemies[a].health > 0) // Gör bara handlingar ifall lever
                    {
                        // GRAVITY
                        bool eTouchesGround = calculation.CheckCollision(enemies[a].id, ground.id, "down");
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

                        // KNOCKBACK
                        if (calculation.CheckCollision(enemies[a].id, player.id, "up"))
                        {
                            enemies[a].namelessBool1 = true;
                        }

                        if (enemies[a].namelessInt1 >= 20)
                        {
                            enemies[a].namelessBool1 = false;
                            enemies[a].namelessInt1 = 0;
                        }
                        else if (enemies[a].namelessBool1)
                        {
                            enemies[a].Move("right", 1);
                            enemies[a].namelessInt1++;
                        }

                        // TAKE DAMAGE
                        // By sword
                        if (calculation.CheckCollision(enemies[a].id, sword.id) && renderReduce)
                        {
                            enemies[a].health--;
                            if (enemies[a].health <= 0) // If dies: get money
                            {
                                money++;
                                enemyKilled = true;
                            }
                        }
                        // By insta kill
                        if (calculation.CheckCollision(enemies[a].id, "i"))
                        {
                            enemies[a].health = 0;
                            money++;
                        }
                        
                        // MONEYBAG INTERACTION
                        if (calculation.CheckCollision(enemies[a].id, wallet.id))
                        {
                            money--;
                            enemies[a].health = 0;
                            enemies[a].Move("left", 100);
                        }
                    }
                    else // Ifall död ändra utseende till gravsten
                    {
                        enemies[a].frames.Remove(enemyIdleFrame);
                        enemies[a].frames.Add(tombStone);
                        enemiesDead++;
                    }
                }
                #endregion

                #region player
                // Movement
                bool pTouchesGround = calculation.CheckCollision(player.id, ground.id, "down");

                if (Console.KeyAvailable == true)
                {
                    var keyPress = Console.ReadKey().Key;
                    int energyMultiplier = int.Parse(SSID("Energy", "VA", ";", stats));

                    switch (keyPress) // Ifall flera knappar kan vara intryckta samtidigt borde jag bara använda if satser för att kunna göra flera röresler samtidigt
                    {
                        case ConsoleKey.W:
                            if (pTouchesGround)
                            {
                                player.Move("up", energyMultiplier);
                            }
                            break;

                        case ConsoleKey.A:
                            player.Move("left", energyMultiplier);
                            break;

                        case ConsoleKey.D:
                            player.Move("right", energyMultiplier);
                            break;

                        case ConsoleKey.I:
                            if (tutorialActive)
                            {
                                tutorialActive = false;
                            }
                            else
                            {
                                tutorialActive = true;
                            }
                            break;

                        case ConsoleKey.Spacebar:
                            attacking = true;
                            pastI = i;
                            break;

                        default:
                            break;
                    }
                }

                // GRAVITY
                if (!pTouchesGround && player.YPos < 22)
                {
                    int gravityMultiplier = int.Parse(SSID("Repleteness", "VA", ";", stats));
                    gravityMultiplier = 10 - gravityMultiplier;

                    if (i % gravityMultiplier * 200 == 0)
                    {
                        player.Move("down", 1);
                    }

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

                if (enemiesDead == enemieCount)
                {
                    enemiesAlive = false;
                }

                //calculation.Print();
                visual.Print();
                calculation.Clear();
                i++;
            }

            if (player.health <= 0)
            {
                stopwatch.Stop();

                for (int b = 0; b < visual.y; b++) // "Screen cleaner"
                {
                    for (int a = 0; a < visual.x; a++)
                    {
                        visual.Place("¤", a, b);
                        visual.Print();
                    }
                }

                visual.PlaceText("YOU DIED", visual.x / 2, visual.y / 2);
                visual.PlaceText("Click enter to proceed...", visual.x / 2, visual.y / 2 + 1);
                visual.Print();
                Console.ReadLine();

                return false;

            }
            else
            {
                visual.PlaceText("Sponsor was impressed. Click enter to proceed...", visual.x / 2, visual.y / 2);
                visual.Print();
                Console.ReadLine();

                return true;
            }

        }

        static bool Tamagotchi()
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

            int feedPrice = 4;
            int playPrice = 1;
            int workoutPrice = 2;
            int sleepPrice = 0;

            bool isAlive = true;
            bool noAfford = false;
            bool workouting = false;

            bool tutorialActive = false;

            Stopwatch stpWTmgi = new Stopwatch();
            stpWTmgi.Start();

            // Sponsor
            bool sponsorTime = false;
            bool sponsorArrived = false;

            string clock;
            int timeBeforeSponsor = 3;

            string[] shuffledArray = new string[sponsors.Count];
            // Sponsor end

            string[,] bakedCat = BakeCat(cat.Muscles, cat.XPos, cat.YPos);
            UpdateStats(cat, stats, bakedCat);

            int i = 0;
            int pastI = 0;

            #endregion

            while (isAlive && !sponsorTime)
            {
                #region renderReduce
                if (i % renderSpeed == 0)
                {
                    renderReduce = true;
                } // A bool that is active after a certain amount of frames
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
                                bakedCat = UpdateStats(cat, stats, bakedCat);
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
                                bakedCat = UpdateStats(cat, stats, bakedCat);
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
                                bakedCat = UpdateStats(cat, stats, bakedCat);
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
                            if (tutorialActive)
                            {
                                tutorialActive = false;
                            }
                            else
                            {
                                tutorialActive = true;
                            }
                            break;
                            
                        case ConsoleKey.Spacebar:
                            if (sponsorArrived)
                            {
                                currentSponsor = shuffledArray[0];

                                sponsorTime = true;
                            }
                            break;

                        default:
                            break;
                    }
                }
                #endregion

                #region place
                // SYRINGE
                calculation.Place(syringe.id, syringe.XPos, syringe.YPos);

                if (tutorialActive && syringe.XPos < syringeStart)
                {
                    visual.PlaceText("Anabolic Steriods", syringe.XPos, syringe.YPos - 4);
                }

                // CAT
                int catXOffset = cat.Muscles * 2 + 8;
                int catYOffset = -2;
                visual.PlaceRotated(bakedCat, cat.XPos, cat.YPos);
                calculation.Place(cat.id, cat.XPos + catXOffset, calculation.y + catYOffset);

                // GROUND
                for (int a = 0; a < calculation.x; a++)
                {
                    visual.Place("=", a, calculation.y - 2);
                }

                // UI
                string statValue;
                UIYpos = 2; // Start UI Y statValue
                
                if (tutorialActive)
                {
                    visual.PlaceText("Money to perform", UIXpos - 20, UIYpos-1);
                    visual.PlaceText("actions with -->", UIXpos - 20, UIYpos);
                }

                visual.PlaceText("Wallet:" + money + "$", UIXpos, UIYpos);
                UIYpos++;

                visual.PlaceText("___________", UIXpos, UIYpos);
                UIYpos = UIYpos + 3;

                if (tutorialActive)
                {
                    visual.PlaceText("Name of need --> ", UIXpos - 20, UIYpos);
                    visual.PlaceText("The State of your cat's need -->", UIXpos - 36, UIYpos + 1);
                    visual.PlaceText("The cost to raise need --> ", UIXpos - 30, UIYpos + 2);

                    visual.PlaceText("To keep cat alive:", UIXpos - 30, UIYpos + 4);
                    visual.PlaceText("Keep the values over 0", UIXpos - 30, UIYpos + 5);
                    visual.PlaceText("but not more than 10", UIXpos - 30, UIYpos + 6);
                }

                foreach (KeyValuePair<string, string> element in stats)
                {
                    // Stat name
                    visual.PlaceText(element.Key, UIXpos, UIYpos);

                    // Stat status bar
                    UIYpos++;
                    statValue = SSID(element.Key, "VA", ";", stats);
                    visual.PlaceText("|>", UIXpos, UIYpos);

                    for (int a = 1; a < 11; a++)
                    {
                        if (a <= int.Parse(statValue))
                        {
                            visual.Place("¤", UIXpos + a, UIYpos);

                        }
                        else
                        {
                            visual.Place("-", UIXpos + a, UIYpos);

                        }
                    }

                    if (int.Parse(statValue) == 10)
                    {
                        visual.PlaceText("<|" + "HIGH!", UIXpos + 12, UIYpos);
                    }
                    else if (int.Parse(statValue) == 1)
                    {
                        visual.PlaceText("<|" + "LOW!", UIXpos + 12, UIYpos);
                    }
                    else
                    {
                        visual.PlaceText("<|" + statValue, UIXpos + 12, UIYpos);
                    }


                    // Action
                    UIYpos++;
                    statValue = SSID(element.Key, "AC", ";", stats);
                    string price = SSID(element.Key, "PR", ";", stats);

                    visual.PlaceText(statValue + " " + price + "$", UIXpos, UIYpos);

                    if (tutorialActive)
                    {
                        string control = SSID(element.Key, "CO", ";", stats);
                        visual.PlaceText("<-- Click " + control, UIXpos + 10, UIYpos);
                    }

                    UIYpos++;
                    UIYpos++;
                }

                // Time
                TimeSpan time = stopwatch.Elapsed;
                TimeSpan timePassedTmgi = stpWTmgi.Elapsed;
                string timeUntilSponsor = (timeBeforeSponsor - timePassedTmgi.Seconds).ToString();
                clock = String.Format("{0}:{1}", time.Minutes, time.Seconds);

                visual.PlaceText("Clock: " + clock + "pm.", 1, 2);
                if (tutorialActive)
                {
                    visual.PlaceText("<-- Muscle contest 3:0pm", 16, 2);
                }

                // Instructions
                visual.PlaceText("Click 'i' for instructions", 1, 4);

                int instrX = 1;
                int instrY = 6;

                if (tutorialActive)
                {
                    visual.PlaceText("To Do List:", instrX, instrY);
                    visual.PlaceText("1. Keep Cat Alive", instrX, instrY + 1);
                    visual.PlaceText("2. Get Muscles", instrX, instrY + 2);
                    visual.PlaceText("3. Get Money By Impressing Sponsors", instrX, instrY + 3);
                    visual.PlaceText("4. Win Muscle Contest", instrX, instrY + 4);
                }

                // Sponsor
                if (timePassedTmgi.Seconds > timeBeforeSponsor)
                {
                    string[] sponsorArray = new string[sponsors.Count];

                    int a = 0;
                    foreach (KeyValuePair<string,string> sponsor in sponsors)
                    {
                        sponsorArray[a] = sponsor.Key;
                        a++;
                    }

                    shuffledArray = Shuffle(sponsorArray);
                    currentSponsor = shuffledArray[0];
                    
                    sponsorArrived = true;

                    stpWTmgi.Restart();
                }

                if (sponsorArrived)
                {
                    visual.PlaceText("SPONSOR HAS ARRIVED: " + currentSponsor + " || Click 'Space' to impress sponsor", 1, visual.y-1);
                }
                else if (tutorialActive)
                {
                    visual.PlaceText("Sponsors show up here every 15 seconds", 1 , visual.y-1);
                }

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


                        bakedCat = UpdateStats(cat, stats, bakedCat);
                    }
                }

                // No money warning
                if (noAfford)
                {
                    int framesPassed = i - pastI;

                    if (framesPassed < 200)
                    {
                        visual.PlaceText("MAN YOU ARE BROKE AND CANNOT AFFORD", 10, 10);
                    }
                    else
                    {
                        noAfford = false;
                    }


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

        static string[,] BakeCat(int fatness, int startX, int startY)
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
                {"\\", "_", "/", "" +
                "", " ", " ", }
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

            fatness = fatness - 2;

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

            return BakeCat(cat.Muscles, cat.XPos, cat.YPos);
            
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

        static string[] Shuffle(string[] inputs)
        {
            List<string> list = new List<string>();
            Random rnd = new Random();

            for (int i = 0; i < inputs.Length; i++)
            {
                list.Add(rnd.Next(0, 100) + "¤" + inputs[i]);
            }

            list.Sort();
            string[] outputs = new string[inputs.Length];
            int a = 0;

            foreach (string item in list)
            {
                string[] split = item.Split('¤');

                outputs[a] = split[1];
                a++;
            }

            return outputs;
        }

    }
}


