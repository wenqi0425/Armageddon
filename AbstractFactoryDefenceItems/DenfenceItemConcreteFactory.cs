using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Armageddon
{
    public class DenfenceItemConcreteFactory : DefenceItemAbstractFactory
    {
        /// <summary>
        /// Simple Factory (under AbstractFactory)
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public override AbstractDefenceItem CreateDefenceItem(DefenceProduct itemType,
            string name, double defenceRatio, bool lootable, bool removable, Size itemSize, Position itemPositon)
        {
            AbstractDefenceItem instance = null;
            switch (itemType)
            {
                case DefenceProduct.Helmet:
                    instance = new Helmet(name, defenceRatio, lootable, removable, itemSize, itemPositon);
                    break;
                case DefenceProduct.Armor:
                    instance = new Armor(name, defenceRatio, lootable, removable, itemSize, itemPositon);
                    break;
                case DefenceProduct.Shield:
                    instance = new Shield(name, defenceRatio, lootable, removable, itemSize, itemPositon);
                    break;
                default:
                    Console.WriteLine("item type is not defined.");
                    break;
            }

            return instance;
        }
    }
}
