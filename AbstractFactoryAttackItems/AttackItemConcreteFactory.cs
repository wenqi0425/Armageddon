using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public class AttackItemConcreteFactory : AttackItemAbstractFactory
    {
        public override AbstractAttackItem CreateAttackItem(AttackProduct itemType, int range, string name, double attackRatio, bool lootable, bool removable, Size itemSize, Position itemPositon)
        {
            AbstractAttackItem instance = null;

            switch (itemType)
            {
                case AttackProduct.Gun:
                    instance = new Gun(range, name, attackRatio, lootable, removable, itemSize, itemPositon);
                    break;
                case AttackProduct.Sword:
                    instance = new Sword(range, name, attackRatio, lootable, removable, itemSize, itemPositon);
                    break;
                case AttackProduct.Knife:
                    instance = new Knife(range, name, attackRatio, lootable, removable, itemSize, itemPositon);
                    break;
                default:
                    break;
            }
            return instance;
        }
    }
}
