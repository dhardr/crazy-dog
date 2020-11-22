using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDog
{
    class Life : Figure
    {
        private int _juice = 1;

        public Life()
        {
            _x = Console.WindowWidth - 5;
            _y = Console.WindowHeight - 5;
        }

        public override void Clear()
        {
            
        }

        public override void Draw()
        {
            for (int i=0;i<4;i++)
            {
                Console.BackgroundColor = (_juice >= 4 - i) ? ConsoleColor.Cyan : ConsoleColor.White;
                Console.SetCursorPosition(_x, _y+i);
                Console.Write("   ");

                Console.BackgroundColor = ConsoleColor.Black;

            }
          

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
