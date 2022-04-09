using System;
using System.Collections.Generic;
using System.Text;

namespace CollisionGame
{
    class Object
    {
        // Medlemsvariabler
        private int xPos;
        private int yPos;

        private string appr;
        private string[,] apprArray;

        // Konstruktor
        public Object(string appearance, int xStart, int yStart)
        {
            xPos = xStart;
            yPos = yStart;
            appr = appearance;
        }

        public Object(string[,] appearance, int xStart, int yStart)
        {
            xPos = xStart;
            yPos = yStart;
            apprArray = appearance;
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
        public string[,] appearanceArray
        {
            get
            {
                return apprArray;
            }
        }

        // Metoder
        public override string ToString()
        {
            return appearance;
        }

        public void Move(int distance)
        {
            if (Console.KeyAvailable == true)
            {
                var keyPress = Console.ReadKey().Key;

                switch (keyPress)
                {
                    case ConsoleKey.W:
                        yPos = yPos - distance;
                        break;

                    case ConsoleKey.A:
                        xPos = xPos - distance;
                        break;

                    case ConsoleKey.S:
                        yPos = yPos + distance;
                        break;

                    case ConsoleKey.D:
                        xPos = xPos + distance;
                        break;

                    default:
                        break;
                }
            }
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

        // skicka position till world där vi har en "draw"/"place" funktion som ritar ut 

    }
}
