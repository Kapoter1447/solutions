using System;
using System.Threading;

namespace CollisionGame
{
    class Program
    {
        static void Main(string[] args)
        {
            #region initialisering och deklarering
            Console.CursorVisible = false;

            World calculation = new World(100,10);
            World visual = new World(100, 10);

            Object player = new Object("p", 1, 1);
            player.health = 10;

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

            bool animationDelay = false;

            bool renderReduce = false;
            int renderSpeed = 50;
            int i = 0;

            #endregion

            while (true)
            {
                if (i%renderSpeed == 0)
                {
                    renderReduce = true;
                }
                else
                {
                    renderReduce = false;
                }

                #region place
                // FIENDE
                calculation.Place(enemy.appearance, enemy.xPosition, enemy.yPosition);
                visual.Place(enemyFrame1, enemy.xPosition-1, enemy.yPosition-3);
                visual.Place(enemy.health.ToString(), enemy.xPosition+4, enemy.yPosition-5);

                // SPELARE
                calculation.Place(player.appearance, player.xPosition, player.yPosition);
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
                bool eTouchesGround = calculation.CheckCollision(enemy.appearance, ground.appearance, "down");
                if (!eTouchesGround && renderReduce)
                {
                    enemy.Move("down", 1);
                }

                // CHASE
                // Ifall negativ är enemy till höger, positiv är till vänster
                int distance = player.xPosition - enemy.xPosition;

                if (renderReduce)
                {
                    if (calculation.CheckCollision(player.appearance, enemy.appearance))
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
                if (calculation.CheckCollision(enemy.appearance, player.appearance, "up"))
                {
                    enemy.Move("right", 40);
                }

                #endregion

                #region player
                // Movement
                bool pTouchesGround = calculation.CheckCollision(player.appearance, ground.appearance, "down");

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
                            player.Move("left", 2);
                            break;
                            /*
                        case ConsoleKey.S:
                            player.Move("down", 1);
                            break;
                            */
                        case ConsoleKey.D:
                            player.Move("right", 2);
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
                bool touchesEnemyLeft = calculation.CheckCollision(player.appearance, enemy.appearance, "right");

                if (touchesEnemyLeft && renderReduce)
                {
                    player.health = player.health - 1;
                }


                #endregion

                // PRINT
                //calculation.Print();
                visual.Print();
                calculation.Clear();

                i++; 
            }
        }

        static void playerAttack(Object player)
        {
            
        }

        static void battle()
        {

        }


    }



}
