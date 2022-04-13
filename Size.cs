using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public class Size
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Size(int w, int h)
        {
            validateSizeValue(w);
            validateSizeValue(h);
            Width = w;
            Height = h;
        }

        private void validateSizeValue(int value)
        {
            if (value > 10 || value < 0) throw new ArgumentException("");
        }

        public Size GetSize()
        {
            return this;
        }

        public override string ToString()
        {
            return "Width:" + Width + " Height:" + Height;
        }
    }
}
