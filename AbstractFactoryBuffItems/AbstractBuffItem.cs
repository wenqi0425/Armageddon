using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public abstract class AbstractBuffItem : AbstractWorldObject
    {
        protected Creature? creature = null;

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

        public void SetCreature(Creature creature) 
        {
            this.creature = creature;
        }
    }
}
