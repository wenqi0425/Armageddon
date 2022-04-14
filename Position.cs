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
        private int x;
        private int y;
        public int X 
        {
            get 
            {
                return x;
            }

            set 
            {                
                if (value > 1000 || value < 0) throw new ArgumentException("Positon value beyounds world scope.");
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {                
                if (value > 1000 || value < 0) throw new ArgumentException("Positon value beyounds world scope.");
                y = value;
            }
        }

        //public int Y { get; set; } 

        public Position(int x, int y)
        {
            validatePositionValue(x);
            validatePositionValue(y);
            X = x;
            Y = y;
        }

        private void validatePositionValue(int value)
        {
            if (value > 1000 || value < 0) throw new ArgumentException("Positon value beyounds world scope.");
        }

        public Position GetPostion()
        {
            return this;
        }

        public override string ToString()
        {
            return "X:" + X + " Y:" + Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }
    }
}
