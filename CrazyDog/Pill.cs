using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDog
{
    public class Pill : Figure
    {
        private DateTime _created;

        public Pill()
        {
            Random rnd = new Random();
            _x = rnd.Next(0, Console.WindowWidth);
            _y = rnd.Next(10, Console.WindowHeight);
            _created = DateTime.Now;
        }

        private bool _isExpired() => ((DateTime.Now - _created).TotalSeconds > 5);

        public bool ClearIfExpired()
        {
            var isExpired = _isExpired();
            if (isExpired)
                Clear();
            return isExpired;
        }

        public override void Clear()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(" ");
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
