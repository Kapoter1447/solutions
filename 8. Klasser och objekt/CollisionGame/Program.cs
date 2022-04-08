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

            string[,] groundArray = new string[15, 1]
            {
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
                {"g"},
            };

            #endregion

            #region animation
            int i = 0;
            bool animation = false;

            while (true)
            {
                if (i%20 == 0)
                {
                    if (animation)
                    {
                        animation = false;
                    }
                    else
                    {
                        animation = true;
                    }
                }
                if (animation)
                {
                    calculation.Place(temp, player.xPosition, player.yPosition);
                }
                else
                {
                    calculation.Place(temp2, player.xPosition, player.yPosition);
                }
                #endregion

                // Place player
                calculation.Place(player.appearance, player.xPosition, player.yPosition);

                // Place ground
              //  calculation.Place(groundArray, 1, 1);


                
                calculation.CheckCollision(player.appearance, ground.appearance);

                // Print
                calculation.Print();

                if (Console.KeyAvailable == true)
                {
                    var keyPress = Console.ReadKey().Key;

                    switch (keyPress)
                    {
                        case ConsoleKey.W:
                            player.Move("up", 1);
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

                        default:
                            break;
                    }
                }
                Console.WriteLine(player);
                i++;
            }
        }
    }


    class Object
    {
        // Medlemsvariabler
        private int xPos;
        private int yPos;
        private string appr;

        // Konstruktor
        public Object(string appearance, int xStart, int yStart)
        {
            xPos = xStart;
            yPos = yStart;
            appr = appearance;
        }

        public int xPosition
        {
            get
            {
                return xPos;
            }
            set
            {
                xPos = value;
            }
        }

        public int yPosition
        {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value;
            }
        }

        public string appearance
        {
            get
            {
                return appr;
            }


        }

        // Metoder
        public override string ToString()
        {
            return appearance;
        }

        public void Move(string direction, int distance)
        {
            switch (direction)
            {
                case "up":
                    yPos = yPos - distance;
                    break;

                case "down":
                    yPos = yPos + distance;
                    break;

                case "left":
                    xPos = xPos - distance;
                    break;

                case "right":
                    xPos = xPos + distance;
                    break;

                default:
                    break;
            }
        }

        public void Collision()
        {
           
        }


        // skicka position till world där vi har en "draw"/"place" funktion som ritar ut 

    }

}
