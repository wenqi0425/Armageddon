using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public class StoneBuffDecorator : AbstractBuffItem
    {
        public StoneBuffDecorator(string name, bool lootable, bool removable, Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio)
            : base(name, lootable, removable, itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio)
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

        public override Position GetPosition()
        {
            return base.ItemPositon;
        }

        public override Size GetSize()
        {
            return base.ItemSize;
        }
    }
}
