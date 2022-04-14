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
        private List<Creature> creatures = new();
        private List<AbstractWorldObject> worldObjects = new();

        public double MaxWidth;
        public double MaxHeight;

        private SingletonWorld()
        {
            GetConfiguration();
            CreateItem();
            //CreateCreatures();
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
                        //after world is created, createing creatures. 
                        //this sequence is critical. 
                        world.CreateCreatures();
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

        public List<AbstractWorldObject> GetWorldObjects()
        {
            return worldObjects;
        }

        public List<Creature> GetCreatures()
        {
            return creatures;
        }

        private void CreateCreatures()
        {
            var defenceItems = new List<AbstractDefenceItem>();
            var attackItems = new List<AbstractAttackItem>();
            var buffItems = new List<AbstractBuffItem>();

            var AAA = new Creature(GetRandomObjectPosition(), "AAA", 20, 10, 200, 1, 1, 1);
            creatures.Add(AAA);
            AAA.SetWorld(world);

            var BBB = new Creature(GetRandomObjectPosition(), "BBB", 20, 10, 200, 1, 1, 1);
            creatures.Add(BBB);
            BBB.SetWorld(world);
        }

        private void CreateItem()
        {
            var gun = new Gun(10, "Gun", 0.5, true, true, new(1, 1), GetRandomObjectPosition());
            worldObjects.Add(gun);

            var knife = new Knife(1, "Knife", 0.1, true, true, new(1, 1), GetRandomObjectPosition());
            worldObjects.Add(knife);

            var sword = new Sword(5, "Sword", 0.2, true, true, new(1, 2), GetRandomObjectPosition());
            worldObjects.Add(sword);

            var armor = new Armor("Armor", 0.2, true, true, new(1, 1), GetRandomObjectPosition());
            worldObjects.Add(armor);

            var helmet = new Helmet("Helmet", 0.1, true, true, new(1, 1), GetRandomObjectPosition());
            worldObjects.Add(helmet);

            var shield = new Shield("Shield", 0.3, true, true, new(1, 1), GetRandomObjectPosition());
            worldObjects.Add(shield);

            var flower = new FlowerBuffDecorator("Flower", true, true, new Size(1, 1), GetRandomObjectPosition(),
                Configuration.FlowerAttackRatio, Configuration.FlowerDefenceRatio, Configuration.FlowerLifeRatio);
            worldObjects.Add(flower);

            var stone = new StoneBuffDecorator("Stone", false, true, new Size(1, 1), GetRandomObjectPosition(),
                Configuration.StoneAttackRatio, Configuration.StoneDefenceRatio, Configuration.StoneLifeRatio);
            worldObjects.Add(stone);

            var worldTree = new WorldTreeBuffDecorator("The World Tree", false, false, new Size(1, 1),
                new Position(Configuration.TreePosistionX, Configuration.TreePosistionY), Configuration.TreeAttackRatio,
                Configuration.TreeDefenceRatio, Configuration.TreeLifeRatio);
            worldObjects.Add(worldTree);
        }

        private Position GetRandomObjectPosition()
        {
            Random random = new();
            return new Position(random.Next(1, 1000), random.Next(1, 1000));
        }
    }
}
