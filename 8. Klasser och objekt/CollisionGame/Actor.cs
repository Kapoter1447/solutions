using System;
using System.Collections.Generic;
using System.Text;

namespace CollisionGame
{
    class Actor
    {
        // Member variables
        private int xPos;
        private int yPos;

        private int energy = 3;
        private int mood = 3;
        private int muscles = 1;
        private int repleteness = 3;
        public int health = 1;

        public int namelessInt1 = 0;

        public bool namelessBool1 = false;

        private string identf;

        public List<string[,]> frames = new List<string[,]>();

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

            repleteness = Math.Clamp(repleteness + 3, 0, 10);
        }

        public void WorkOut()
        {
            energy--;
            muscles++;
        }

        public void Sleep()
        {
            repleteness--;
            mood--;
            energy = Math.Clamp(energy + 3, 0, 10);
        }

        public void Play()
        {
            energy--;
            repleteness--;
            mood = Math.Clamp(mood + 3, 0, 10);
        }

        public int Muscles
        {
            get
            {
                return muscles;
            }
            set
            {
                muscles = Math.Clamp(value, 0, 10);
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
