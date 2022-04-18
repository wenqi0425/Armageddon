using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Creature
    {
        public MoveDirection direction;
        SingletonWorld world;

        public double TotalHitPoint { get; set; }
        public double TotalLifePoint { get; set; }
        public double TotalDefencePoint { get; set; }
        public double TotalAttackRatio { get; set; }
        public double TotalLifeRatio { get; set; }
        public double TotalDefenceRatio { get; set; }
        List<AbstractWorldObject> worldObjects = new List<AbstractWorldObject>();
        List<AbstractDefenceItem> defenceItems = new List<AbstractDefenceItem>();
        List<AbstractAttackItem> attackItems = new List<AbstractAttackItem>();
        List<AbstractBuffItem> buffItems = new List<AbstractBuffItem>();
        
        // the following properties will be set in the constructor
        public Position position { get; set; }
        public string Name { get; set; }
        public double BasicHitPoint { get; set; }
        public double BasicDefencePoint { get; set; }
        public double BasicLifePoint { get; set; }
        public double BasicAttackRatio { get; set; }
        public double BasicDefenceRatio { get; set; }
        public double BasicLifeRatio { get; set; }

        public Creature(Position position, string name, double basicHitPoint, double basicDefencePoint, double basicLifePoint, double basicAttackRatio, double basicDefenceRatio, double basicLifeRatio)
        {
            this.position = position;
            Name = name;
            BasicHitPoint = basicHitPoint;
            BasicDefencePoint = basicDefencePoint;
            BasicLifePoint = basicLifePoint;
            BasicAttackRatio = basicAttackRatio;
            BasicDefenceRatio = basicDefenceRatio;
            BasicLifeRatio = basicLifeRatio;
        }


        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    this.position.Y -= 1;
                    break;
                case MoveDirection.Down:
                    this.position.Y += 1;
                    break;
                case MoveDirection.Left:
                    this.position.X -= 1;
                    break;
                case MoveDirection.Right:
                    this.position.X += 1;
                    break;
            }
        }

        public void SetWorld(SingletonWorld world)
        {
            this.world = world;
        }

        public void PickWorldObjects(AbstractWorldObject worldObject)
        {
            //Console.WriteLine("pick up item");
            //if (this.position.Equals(worldObject.ItemPositon))
            //{
                if (worldObject is Gun gun)
                {
                    this.attackItems.Add(gun);
                    world.GetWorldObjects().Remove(worldObject);
                }

                if (worldObject is Knife knife)
                {
                    this.attackItems.Add(knife);
                    world.GetWorldObjects().Remove(worldObject);
                }

                if (worldObject is Sword sword)
                {
                    this.attackItems.Add(sword);
                    world.GetWorldObjects().Remove(worldObject);
                }

                if (worldObject is Armor armor)
                {
                    this.defenceItems.Add(armor);
                    world.GetWorldObjects().Remove(worldObject);
                }

                if (worldObject is Helmet helmet)
                {
                    this.defenceItems.Add(helmet);
                    world.GetWorldObjects().Remove(worldObject);
                }

                if (worldObject is Shield shield)
                {
                    this.defenceItems.Add(shield);
                    world.GetWorldObjects().Remove(worldObject);
                }

                if (worldObject is FlowerBuffDecorator flower)
                {
                    this.buffItems.Add(flower);
                    world.GetWorldObjects().Remove(worldObject);
                }

                if (worldObject is StoneBuffDecorator stone)
                {
                    this.buffItems.Add(stone);
                    world.GetWorldObjects().Remove(worldObject);
                }

                if (worldObject is WorldTreeBuffDecorator worldTree)
                {
                    Console.WriteLine("pick up world tree item");
                    this.buffItems.Add(worldTree);
                }
            //}            
        }

        public List<AbstractDefenceItem> GetDefenceItems()
        {
            return defenceItems;
        }

        public List<AbstractAttackItem> GetAttackItems()
        {
            return attackItems;
        }

        public List<AbstractBuffItem> GetBuffItems()
        {
            return buffItems;
        }   
        
        public double GetTotalLifeRatio()
        {
            double bufflifeRatio = 0;
            foreach (var buffItem in this.buffItems)
            {
                bufflifeRatio += buffItem.LifeRatio;
            }

            this.TotalLifeRatio = 1 + bufflifeRatio;
            return this.TotalLifeRatio;
        }

        public double GetTotalLifePoint()
        {
            this.TotalLifePoint = this.BasicLifePoint * GetTotalLifeRatio();
            return TotalLifePoint;
        }

        public double GetTotalAttackRatio()
        {
            double buffAttackRatio = 0;
            double attackItemRatio = 0;

            foreach (var buffItem in this.buffItems)
            {
                buffAttackRatio += buffItem.AttackRatio;
            }

            foreach (var attackItem in this.attackItems)
            {
                attackItemRatio += attackItem.AttackRatio;
            }

            this.TotalAttackRatio = 1 + buffAttackRatio + attackItemRatio;
            return this.TotalAttackRatio;
        }

        public double GetTotalHitPoint()
        {
            this.TotalHitPoint = this.BasicHitPoint * GetTotalAttackRatio();
            return this.TotalHitPoint;
        }

        public double GetTotalDefenceRatio()
        {
            double buffDefenceRatio = 0;
            double defenceItemRatio = 0;

            foreach (var buffItem in this.buffItems)
            {
                buffDefenceRatio += buffItem.DefenceRatio;
            }

            foreach (var defenceItem in this.defenceItems)
            {
                defenceItemRatio += defenceItem.DefenceRatio;
            }

            this.TotalDefenceRatio = 1 + buffDefenceRatio + defenceItemRatio;
            return this.TotalDefenceRatio;
        }

        public double GetTotalDefencePoint()
        {
            this.TotalDefencePoint = this.BasicDefencePoint * GetTotalDefenceRatio();
            return TotalDefencePoint;
        }

        public void Hit(Creature attacked)
        {
            Console.WriteLine("hit");
            double injurePoint = this.GetTotalHitPoint() - attacked.GetTotalDefencePoint();
            double totalLifePoint = attacked.GetTotalLifePoint();
            Console.WriteLine("Before hitting, has life point: " + totalLifePoint);
            if (this.GetTotalHitPoint() > attacked.GetTotalDefencePoint())
            {
                totalLifePoint -= injurePoint;
                Console.WriteLine("1. After hitting, has life point: " + totalLifePoint);
            }
            else
            {
                totalLifePoint -= 1;
                Console.WriteLine("2. After hitting, has life point: " + totalLifePoint);
            }

            attacked.TotalLifePoint = totalLifePoint;
        }

        //public void ReceiveHit(Creature attacker)
        //{
        //    double injurePoint = attacker.GetTotalHitPoint() - attacker.GetTotalDefencePoint();
        //    double totalLifePoint = attacker.GetTotalLifePoint();
        //    if (attacker.GetTotalHitPoint() > this.GetTotalDefencePoint())
        //    {
        //        totalLifePoint -= injurePoint;
        //    }
        //    else
        //    {
        //        totalLifePoint -= 1;
        //    }
        //    attacker.TotalLifePoint = totalLifePoint;
        //}        
    }
}