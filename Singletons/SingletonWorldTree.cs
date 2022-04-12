using Armageddon.AbstractFactoryBuffItems;
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace Armageddon
{
    /// <summary>
    /// Singleton
    /// There is only one World Tree in this project. 
    /// </summary>
    
    public class SingletonWorldTree : AbstractBuffItem
    {
        public Position TreePosistion;
        public WorldTreeBuffDecorator WorldTreeBuff;
        public Size TreeSize;
        Creature creature;

        private SingletonWorldTree(Creature creature, string name, bool lootable, bool removable, Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio) 
            : base(name, lootable, removable, itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio)
        {
            GetConfiguration();
        }

        private void GetConfiguration()
        {
            Configuration.ReadConfiguration();
            GetTreeSize();
            Trace.TraceLog(TraceEventType.Information, "Create a World Tree with a fixed size");

            GetTreePosition();
            Trace.TraceLog(TraceEventType.Information, "Create a fixed position of the World Tree");
            
            WorldTreeBuff.AttackRatio = Configuration.TreeAttackRatio;
            WorldTreeBuff.DefenceRatio = Configuration.TreeDefenceRatio;
            WorldTreeBuff.LifeRatio = Configuration.StoneLifeRatio;
            Trace.TraceLog(TraceEventType.Information, "Create a World Tree Buff");
        }

        public WorldTreeBuffDecorator TouchTree(Creature creature, string name, bool lootable, bool removable, Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio)
        {
            return new WorldTreeBuffDecorator(creature, name, lootable, removable, itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio);
        }

        private static SingletonWorldTree worldTree;
        private static readonly object syncRoot = new();         

        public static SingletonWorldTree GetInstance(Creature creature, string name, bool lootable, bool removable, Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio)
        {
                lock (syncRoot)
                {
                    if (worldTree == null)
                    {
                        worldTree = new SingletonWorldTree(creature,name, lootable, removable, itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio);

                    
                    }
                return worldTree;
            }
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

        private Position GetTreePosition()
        {
            TreePosistion.X = Configuration.TreePosistionX;
            TreePosistion.Y = Configuration.TreePosistionY;
            return TreePosistion;
        }

        private Size GetTreeSize()
        {
            TreeSize.Width = Configuration.WorldTreeWidth;
            TreeSize.Height = Configuration.WorldTreeHeight;
            return TreeSize;
        }
    }
}
