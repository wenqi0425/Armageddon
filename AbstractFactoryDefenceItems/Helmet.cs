
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public class Helmet : AbstractDefenceItem
    {
        public Helmet(string name, double defenceRatio, bool lootable, bool removable, Size itemSize, Position itemPositon) : base(name, defenceRatio, lootable, removable, itemSize, itemPositon)
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
