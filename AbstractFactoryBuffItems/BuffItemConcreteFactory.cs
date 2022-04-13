using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon.AbstractFactoryBuffItems
{
    public abstract class BuffItemConcreteFactory : BuffItemAbstractFactory
    {
        Creature creature;
        public override AbstractBuffItem CreateBuffItem(BuffProduct itemType, string name, bool lootable, bool removable, Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio)
        {
            AbstractBuffItem instance = null;
            switch (itemType)
            {
                case BuffProduct.MagicFlower:
                    instance = new FlowerBuffDecorator( name, lootable, removable, itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio);
                    break;
                case BuffProduct.SingletonWorldTree:
                    instance = SingletonWorldTree.GetInstance(name, lootable, removable);
                    break;
                case BuffProduct.NormalStone:
                    instance = new StoneBuffDecorator(name, lootable, removable, itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio);
                    break;
                default:
                    Console.WriteLine("item type is not defined.");
                    break;
            }

            return instance;
        }
    }
}
