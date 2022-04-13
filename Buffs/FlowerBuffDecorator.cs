using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public class FlowerBuffDecorator : AbstractBuffItem
    {

        public FlowerBuffDecorator(String name, bool lootable, bool removable, Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio) 
            : base(name, lootable, removable,itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio)
        {
        }

        public override double GetAttackRatio()
        {
            return AttackRatio;
        }

        public override double GetDefenceRatio()
        {
            return DefenceRatio;
        }

        public override double GetLifeRatio()
        {
            return LifeRatio;
        }
    }
}
