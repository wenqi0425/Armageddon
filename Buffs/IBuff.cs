using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    interface IBuff
    {
        public double GetDefenceRatio();
        public double GetAttackRatio();
        public double GetLifeRatio();
    }
}
