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
        private static Position TreePosistion;
        private static WorldTreeBuffDecorator WorldTreeBuff;
        private static Size TreeSize;

        private static double _treeAttactRatio;
        private static double _treeDefenceRatio;
        private static double _treeLifeRatio;


        private SingletonWorldTree(string name, bool lootable, bool removable, Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio) 
            : base(name, lootable, removable, itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio)
        {
            GetConfiguration();
        }

        private void GetConfiguration()
        {
            Configuration.ReadConfiguration();
            TreeSize = new Size(Configuration.WorldTreeWidth, Configuration.WorldTreeHeight);
            Trace.TraceLog(TraceEventType.Information, "Create a World Tree with a fixed size");

            TreePosistion = new Position(Configuration.TreePosistionX, Configuration.TreePosistionY);
            Trace.TraceLog(TraceEventType.Information, "Create a fixed position of the World Tree");
            
            _treeAttactRatio = Configuration.TreeAttackRatio;
            _treeDefenceRatio = Configuration.TreeDefenceRatio;
            base.LifeRatio = Configuration.TreeLifeRatio;          

            Trace.TraceLog(TraceEventType.Information, "Create a World Tree Buff");            
        }

        public WorldTreeBuffDecorator TouchTree(Creature creature, string name, bool lootable, bool removable, Size itemSize, Position itemPositon, double defenceRatio, double attackRatio, double lifeRatio)
        {
            return new WorldTreeBuffDecorator(name, lootable, removable, itemSize, itemPositon, defenceRatio, attackRatio, lifeRatio);
        }

        private static SingletonWorldTree worldTree;
        private static readonly object syncRoot = new();         

        public static SingletonWorldTree GetInstance(string name, bool lootable, bool removable)
        {
                lock (syncRoot)
                {
                if (worldTree == null)
                {
                    worldTree = new SingletonWorldTree(name, lootable, removable, TreeSize, TreePosistion, _treeAttactRatio, _treeDefenceRatio, _treeLifeRatio);
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
            return TreePosistion;
        }

        public Size GetTreeSize()
        {
            return TreeSize;
        }
    }
}
