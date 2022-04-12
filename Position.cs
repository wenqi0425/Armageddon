using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Armageddon
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; } 

        public Position(int x, int y)
        {
            validatePositionValue(x);
            validatePositionValue(y);
            X = x;
            Y = y;
        }

        private void validatePositionValue(int value)
        {
            if (value > 1000 || value < 0) throw new ArgumentException("");
        }

        public Position GetPostion()
        {
            return this;
        }
    }
}
