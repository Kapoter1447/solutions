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

            World calculation = new World(25,25);
            Object player = new Object("p", 1, 1);
            Object ground = new Object("g", 1, 1);

            // Prakiskt om den kan ta en vanlig string och dela upp den i en array så slipper man det här:
            string[,] temp = new string[4, 4]
            {
                {" ", "O", " ", " "},
                {"/", "|", "\\", " "},
                {" ", "|", " ", " ", },
                {"/", " ", "\\", " "}
            };

            string[,] temp2 = new string[4, 4]
            {
                {" ", "O", " ", " "},
                {"\\", "|", "/", " "},
                {" ", "|", " ", " ", },
                {"/", " ", "\\", " "}
            };

            string[,] tamagotchi = new string[4, 4]
{
                {" ", "O", " ", " "},
                {"\\", "|", "/", " "},
                {" ", "|", " ", " ", },
                {"/", " ", "\\", " "}
};


            string[,] groundArray = new string[1, 20]
            {
                {"g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g", "g"},

            };

            #endregion
            
            int i = 0;
            while (true)
            {


                //  calculation.Place(temp2, player.xPosition, player.yPosition);


                // Place player
                calculation.Place(temp, player.xPosition-1, player.yPosition-3);
                calculation.Place(player.appearance, player.xPosition, player.yPosition);


                // Place ground
                calculation.Place(groundArray, 1, 20);
                calculation.Place(groundArray, 10, 18);


                #region movement
                //  player.Move(2);
                bool touchesGround = calculation.CheckCollision(player.appearance, ground.appearance, "down");

                if (Console.KeyAvailable == true)
                {
                    var keyPress = Console.ReadKey().Key;
                    int jumpHeight = 4;

                    // Ifall flera knappar kan vara intryckta samtidigt borde jag bara använda if satser för att kunna göra flera röresler samtidigt

                    switch (keyPress)
                    {
                        case ConsoleKey.W:
                            if (touchesGround)
                            {
                               player.Move("up", 5);

                            }
                            break;

                        case ConsoleKey.A:
                            player.Move("left", 2);
                            break;

                        case ConsoleKey.S:
                            player.Move("down", 2);
                            break;

                        case ConsoleKey.D:
                            player.Move("right", 2);
                            break;

                        default:
                            break;
                    }
                }

                // Gravity
                Console.WriteLine(touchesGround);

                if (!touchesGround && i%15 == 0)
                {
                    player.Move("down", 1);
                }
                #endregion


                // Print
                calculation.Print();
                i++;
            }
        }
    }



}
