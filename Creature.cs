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

        List<AbstractDefenceItem> defenceItems { get; set; } = new List<AbstractDefenceItem>();
        List<AbstractAttackItem> attackItems { get; set; } = new List<AbstractAttackItem>();
        List<AbstractBuffItem> buffItems { get; set; } = new List<AbstractBuffItem>();        
        public Position position { get; set; }
        public string Name { get; set; }
        public double BasicHitPoint { get; set; }
        public double BasicDefencePoint { get; set; }
        public double BasicLifePoint { get; set; }
        
        public Creature(List<AbstractDefenceItem> defenceItems, List<AbstractAttackItem> attackItems, List<AbstractBuffItem> buffItems, Position position, string name, double basicHitPoint, double basicDefencePoint, double basicLifePoint)
        {
            this.defenceItems = defenceItems;
            this.attackItems = attackItems;
            this.buffItems = buffItems;
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

        public void PickAttackItem(AbstractAttackItem attackItem)
        {
            if(this.position == attackItem.ItemPositon)
            {
                if (attackItem is Gun)
                {
                    attackItems.Add(attackItem);
                }

                if (attackItem is Knife)
                {
                    attackItems.Add(attackItem);
                }

                if (attackItem is Sword)
                {
                    attackItems.Add(attackItem);
                }
            }

            this.attackItems.Add(attackItem);
            world.GetWorldObjects().Remove(attackItem);
        }

        public void PickDefenceItem(AbstractDefenceItem defenceItem)
        {
            if (this.position == defenceItem.ItemPositon)
            {
                if (defenceItem is Armor)
                {
                    defenceItems.Add(defenceItem);
                }

                if (defenceItem is Helmet)
                {
                    defenceItems.Add(defenceItem);
                }

                if (defenceItem is Shield)
                {
                    defenceItems.Add(defenceItem);
                }
            }            
        }

        public void PickBuffItem(AbstractBuffItem buffItem)
        {
            if (this.position == buffItem.ItemPositon)
            {
                if (buffItem is FlowerBuffDecorator)
                {
                    buffItem.SetCreature(this);
                    buffItems.Add(buffItem);
                }

                if (buffItem is StoneBuffDecorator)
                {
                    buffItem.SetCreature(this);
                    buffItems.Add(buffItem);
                }

                if (buffItem is WorldTreeBuffDecorator)
                {
                    buffItem.SetCreature(this);
                    buffItems.Add(buffItem);
                }
            }                
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