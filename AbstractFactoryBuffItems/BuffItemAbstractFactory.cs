using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public enum BuffProduct { MagicFlower, NormalStone, SingletonWorldTree }
    
    public abstract class BuffItemAbstractFactory 
    {
        public abstract AbstractBuffItem CreateBuffItem(
            BuffProduct itemType, 
            string name, bool lootable, bool removable, 
            Size itemSize, Position itemPositon, 
            double defenceRatio, double attackRatio, double lifeRatio);
    }
}