using Armageddon.AbstractFactoryAttackItems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Armageddon
{
    /// <summary>
    /// Singleton
    /// There is only one World Tree in this project. 
    /// </summary>

    public class SingletonWorld
    {
        private static SingletonWorld world;
        private static readonly object syncRoot = new();
        Creature creature;
        List<AbstractWorldObject> worldObjects = new();

        public double MaxWidth;
        public double MaxHeight;

        private SingletonWorld()
        {
            GetConfiguration();
        }

        public static SingletonWorld GetInstance()
        {
            if (world == null)
            {
                lock (syncRoot)
                {
                    if (world == null)
                    {
                        world = new SingletonWorld();
                    }
                }
            }
            return world;
        }

        private void GetConfiguration()
        {
            Configuration.ReadConfiguration();
            MaxWidth = Configuration.MaxWidth;
            MaxHeight = Configuration.MaxHeight;
            Trace.TraceLog(TraceEventType.Information, "Create a world with a Max Size");
        }

        public IEnumerable<AbstractWorldObject> CreateItem()
        {
            var gun = new Gun(10, "Gun", 0.5, true, true, new (1,1), getRandomObjectPosition());
            var knife = new Knife(1, "Knife", 0.1, true, true, new(1, 1), getRandomObjectPosition());
            var sword = new Sword(5, "Sword", 0.2, true, true, new(1, 2), getRandomObjectPosition());
            var armor = new Armor("Armor", 0.2, true, true, new(1,1),getRandomObjectPosition());
            var helmet = new Helmet("Helmet", 0.1, true, true, new(1, 1), getRandomObjectPosition());
            var shield = new Shield("Shield", 0.3, true, true, new(1, 1), getRandomObjectPosition());
            var flower = new FlowerBuffDecorator(creature, "Flower", true, true, new Size(1,1), getRandomObjectPosition(), 
                Configuration.FlowerAttackRatio, Configuration.FlowerDefenceRatio, Configuration.FlowerLifeRatio);
            var stone = new StoneBuffDecorator(creature, "Stone", false, true, new Size(1, 1), getRandomObjectPosition(),
                Configuration.StoneAttackRatio, Configuration.StoneDefenceRatio, Configuration.StoneLifeRatio);
            var worldTree = new WorldTreeBuffDecorator(creature, "The World Tree", false, false, new Size(1, 1), 
                new Position(Configuration.TreePosistionX,Configuration.TreePosistionY),Configuration.TreeAttackRatio, 
                Configuration.TreeDefenceRatio, Configuration.TreeLifeRatio);
            return worldObjects;
        }

        private Position getRandomObjectPosition()
        {
            Random random = new();
            return new Position(random.Next(1, 1000), random.Next(1, 1000));
        }
    }
}
