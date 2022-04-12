using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon.AbstractFactoryAttackItems
{
    public class Knife : AbstractAttackItem
    {
        public Knife(int range, string name, double attackRatio, bool lootable, bool removable, Size itemSize, Position itemPositon) 
            : base(range, name, attackRatio, lootable, removable, itemSize, itemPositon)
        {
        }

        public override double GetAttackRatio()
        {
            return base.AttackRatio;
        }

        public override double GetDefenceRatio()
        {
            return base.DefenceRatio;
        }

        public override double GetLifeRatio()
        {
            return base.LifeRatio;
        }
    }
}
