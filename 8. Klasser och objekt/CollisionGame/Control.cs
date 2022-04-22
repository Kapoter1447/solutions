using System;
using System.Collections.Generic;
using System.Text;

namespace CollisionGame
{
    class Control
    {
        private ConsoleKey controlKey;

        // Konstruktur
        public Control(ConsoleKey key)
        {
           controlKey = key;
        }

        // Metoer
        public bool isClicked()
        {
            if (Console.KeyAvailable == true)
            {
                var keyPress = Console.ReadKey().Key;

                if (keyPress == controlKey)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


    }
}
