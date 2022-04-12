using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    /// <summary>
    /// abstract factory
    /// DefenceItem
    /// </summary>
    /// 
    public enum DefenceProduct { Helmet, Armor, Shield }

    public abstract class DefenceItemAbstractFactory
    {
        public abstract AbstractDefenceItem CreateDefenceItem(DefenceProduct itemType, string name, double defenceRatio, bool lootable, bool removable, Size itemSize, Position itemPositon);
    }
}
