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
    
    public enum AttackProduct { Gun, Sword, Knife }

    public abstract class AttackItemAbstractFactory
    {
        public abstract AbstractAttackItem CreateAttackItem(AttackProduct itemType, int range, string name, double attackRatio, bool lootable, bool removable, Size itemSize, Position itemPositon);
    }
}
