using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Armageddon
{
    public abstract class AbstractWorldObject : IBuff
    {
        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removable { get; set; }
        public Size ItemSize { get; set; }
        public Position ItemPositon { get; set; }
        public double DefenceRatio { get; set; }
        public double AttackRatio { get; set; }
        public double LifeRatio { get; set; }

        public abstract double GetAttackRatio();
        public abstract double GetDefenceRatio();
        public abstract double GetLifeRatio();
        public abstract Size GetSize();
        public abstract Position GetPosition();

        public override string ToString()
        {
            return Name;
        }
    }


}
