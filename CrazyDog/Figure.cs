using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDog
{
    public abstract class Figure
    {
        protected int _x;
        protected int _y;

        public abstract void Draw();

        public abstract void Clear();

    }
}
