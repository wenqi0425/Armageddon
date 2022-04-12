using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public abstract class AbstractDefenceItem : AbstractWorldObject
    {
        protected AbstractDefenceItem(string name, double defenceRatio, bool lootable, bool removable, Size itemSize, Position itemPositon)
        {
            Name = name;
            DefenceRatio = defenceRatio;
            Lootable = lootable;
            Removable = removable;
            ItemSize = itemSize;
            ItemPositon = itemPositon;
        }
    }
}
