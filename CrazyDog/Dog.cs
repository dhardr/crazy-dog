using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDog
{
    public class Dog : Figure
    {

        public Dog()
        {
            _x = 5;
            _y = Console.WindowHeight - 7;
        }
        
        public override void Draw()
        {
            string ascii = @"
 ,    /-.
((___/ __>
/      }
\ .--.( 
 \\   \\";
            int i = 0;
            foreach (var line in ascii.Split("\r\n"))
            {
                Console.SetCursorPosition(_x, _y + i);
                Console.Write(line);
                i++;
            }
        }

        public override void Clear()
        {
            for (int i=0;i<6;i++)
            {
                Console.SetCursorPosition(_x, _y + i);
                Console.Write("            ");
            }
        }

        public void MoveRight()
        {
            if (_x > Console.WindowWidth - 3 - 10 - 8)
                return;
            Clear();
            if (_isJumping())
                _x += 10;
            else
                _x += 3;
            Draw();

        }
        public void MoveLeft()
        {
            if (_x < 3)
                return;
            Clear();
            if (_isJumping())
                _x -= 10;
            else
                _x -= 3;
            Draw();
        }

        private JumpAnimation _jumpAnimation = null;

        public void Jump()
        {
            if (!_isJumping())
                _jumpAnimation = new JumpAnimation();
        }


        private bool _isJumping() => _jumpAnimation != null;

        public void Update()
        {
            if (_isJumping())
            {
                if (_jumpAnimation.IsAnimationDone())
                    _jumpAnimation = null;
                else
                {
                    Clear();
                    (int incr_x, int incr_y) = _jumpAnimation.GetNextIncrements();
                    _x += incr_x;
                    _y += incr_y;
                    Draw();
                }
            }

        }

    }
}
