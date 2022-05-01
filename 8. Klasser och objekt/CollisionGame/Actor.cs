using System;
using System.Collections.Generic;
using System.Text;

namespace CollisionGame
{
    class Actor
    {
        // Medlemsvariabler
        private int xPos;
        private int yPos;

        private int energy = 3;
        private int mood = 3;
        private int muscles = 1;
        private int repleteness = 3;

        private string identf;

        public List<string[,]> frames = new List<string[,]>();

        public int value = 1;

        // Konstruktor
        public Actor(string id, int xStart, int yStart)
        {
            xPos = xStart;
            yPos = yStart;
            identf = id;
        }

        public Actor(string[,] appearance, int xStart, int yStart)
        {
            xPos = xStart;
            yPos = yStart;
        }


        // Metoder
        public override string ToString()
        {
            return id;
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

        public void Feed()
        {
            energy--;
            mood--;
            repleteness = repleteness + 3;
        }

        public void WorkOut()
        {
            energy--;
            mood--;
            repleteness--;
            muscles++;
        }

        public void Sleep()
        {
            repleteness--;
            mood--;
            energy = energy + 3;
            muscles--;
        }

        public void Play()
        {
            energy--;
            repleteness--;
            mood = energy + 3;
        }

        public int Muscles
        {
            get
            {
                return muscles;
            }
        }

        public int Repleteness
        {
            get
            {
                return repleteness;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }
        }

        public int Mood
        {
            get
            {
                return mood;
            }
        }

        public int XPos
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

        public int YPos
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

        public string id
        {
            get
            {
                return identf;
            }
        }

        // skicka position till canvas där vi har en "draw"/"place" funktion som ritar ut 

    }
}
