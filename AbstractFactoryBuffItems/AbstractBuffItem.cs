using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public abstract class AbstractBuffItem : AbstractWorldObject
    {
        protected AbstractBuffItem(string name, bool lootable, bool removable,
            Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio)
        {
            Name = name;
            Lootable = lootable;
            Removable = removable;
            ItemSize = itemSize;
            ItemPositon = itemPositon;
            DefenceRatio = defenceRatio;
            AttackRatio = attackRatio;
            LifeRatio = lifeRatio;
        }
    }
}
