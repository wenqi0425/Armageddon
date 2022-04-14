using Armageddon.AbstractFactoryAttackItems;
using Armageddon.AbstractFactoryBuffItems;
using System;
using System.Collections.Generic;
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

        List<AbstractDefenceItem> defenceItems  = new List<AbstractDefenceItem>();
        List<AbstractAttackItem> attackItems = new List<AbstractAttackItem>();
        List<AbstractBuffItem> buffItems  = new List<AbstractBuffItem>();        
        public Position position { get; set; }
        public string Name { get; set; }
        public double BasicHitPoint { get; set; }
        public double BasicDefencePoint { get; set; }
        public double BasicLifePoint { get; set; }

        public Creature(List<AbstractDefenceItem> defenceItems, List<AbstractAttackItem> attackItems, List<AbstractBuffItem> buffItems, 
            Position position, string name, double basicHitPoint, double basicDefencePoint, double basicLifePoint)
        {
            this.defenceItems = defenceItems;
            this.attackItems = attackItems;
            this.buffItems = buffItems;
            this.worldObjects = worldObjects;
            this.position = position;
            Name = name;
            BasicHitPoint = basicHitPoint;
            BasicDefencePoint = basicDefencePoint;
            BasicLifePoint = basicLifePoint;
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
                Console.WriteLine("pick up a gun");
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

        public double GetTotalLifePoint()
        {
            double basicLifeRatio = 1;
            foreach (var buffItem in this.buffItems)
            {
                this.TotalLifeRatio += buffItem.LifeRatio;
            }

            TotalLifeRatio += basicLifeRatio;

            this.TotalLifePoint = this.BasicLifePoint * TotalLifeRatio;

            return TotalLifePoint;
        }


        public double GetTotalHitPoint()
        {
            double basicAttackRatio = 1;
            foreach (var buffItem in this.buffItems)
            {
                this.TotalAttackRatio += buffItem.AttackRatio;
            }

            foreach (var attackItem in this.attackItems)
            {
                this.TotalAttackRatio += attackItem.AttackRatio;
            }

            TotalAttackRatio += basicAttackRatio;

            this.TotalHitPoint = this.BasicHitPoint * TotalAttackRatio;

            return TotalHitPoint;
        }

        public double GetTotalDefencePoint()
        {
            double basicDefenceRatio = 1;
            foreach (var buffItem in this.buffItems)
            {
                this.TotalDefenceRatio += buffItem.DefenceRatio;
            }

            foreach (var defenceItem in this.defenceItems)
            {
                this.TotalDefenceRatio += defenceItem.DefenceRatio;
            }

            TotalAttackRatio += basicDefenceRatio;

            this.TotalDefencePoint = this.BasicDefencePoint * TotalDefenceRatio;

            return TotalDefencePoint;
        }

        public void Hit(Creature attacked)
        {
            if(this.TotalHitPoint > attacked.TotalDefencePoint)
            {
                attacked.TotalLifePoint -= (this.TotalHitPoint - attacked.TotalDefencePoint);
            }
            else
            {
                attacked.TotalLifePoint -= 1;
            }            
        }

        public void ReceiveHit(Creature attacker)
        {
            if(attacker.TotalHitPoint > this.TotalDefencePoint)
            {
                this.TotalLifePoint -= (attacker.TotalHitPoint - this.TotalDefencePoint);
            }
            else
            {
                this.TotalLifePoint -= 1;
            }            
        }        
    }
}