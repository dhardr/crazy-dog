using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDog
{
    public class JumpAnimation
    {

        private int[] TRANSITON_Y = new int[] { -6, -3, -1, 1, 3, 6 };
        private int _transition_index;

        public JumpAnimation()
        {
            _transition_index = 0;
        }

        public (int incr_x, int incr_y) GetNextIncrements()
        {
            if (!IsAnimationDone())
            {
                _transition_index++;
                return (0, TRANSITON_Y[_transition_index - 1]);
            } else
            {
                return (0, 0);
            }
        }
        public bool IsAnimationDone() => _transition_index >= TRANSITON_Y.Length;

    }
}
