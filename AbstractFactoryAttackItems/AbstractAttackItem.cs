using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Armageddon
{
    public abstract class AbstractAttackItem : AbstractWorldObject
    {
        public int Range { get; set; }
        protected AbstractAttackItem(int range, string name, double attackRatio, bool lootable, bool removable, Size itemSize, Position itemPositon)
        {
            Range = range;
            Name = name;
            AttackRatio = attackRatio;
            Lootable = lootable;
            Removable = removable;
            ItemSize = itemSize;
            ItemPositon = itemPositon;
        }
    }
}
