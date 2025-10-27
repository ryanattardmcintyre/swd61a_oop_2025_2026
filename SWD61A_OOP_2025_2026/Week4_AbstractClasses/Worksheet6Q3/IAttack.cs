using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_AbstractClasses.Worksheet6Q3
{
    /*
     * 1.	Create a new interface IAttack
2.	IAttack should hold one method Attack
3.	Create another interface IHeal, which should contain a method Heal.  This will be used by the priest character.
4.	Both the Attack and Heal methods should accept a parameter called target of type Character. 
5.	We need three types of characters which have some commonalities but also differences (the priest can heal, other characters cannot).

6.	Create a base class Character.  It is not logical for the user to directly instantiate something nonspecific like a Character, thus this class should be declared as abstract.

     */
    public interface IAttack
    {
        void Attack(Character c);
    }
    public interface IHeal
    {
        void Heal(Character c);
    }

    public abstract class Character : IAttack
    {
        protected Character(int mana, int health, int damage)
        {
            Mana = mana;
            Health = health;
            Damage = damage;
        }

        public int Mana { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public abstract void Attack(Character c);
    }

    /*
     * The Priest has initial health of 125, initial mana of 200 and damage of 100.
     */
    public class Priest : Character, IHeal
    {
        public Priest():base(200, 125, 100) { }

        //15.	When the Priest Heals, he reduces his mana by 100 and heals the target character by increasing his health with 150 health points.
        public void Heal(Character c)
        {
            Mana -= 100;
            c.Health += 150;
        }

        public override void Attack(Character c)
        {
            c.Health -= Damage;
            this.Health += Convert.ToInt32(0.1 * Damage);
        }
    }
    public class Warrior: Character
    {
        public Warrior():base(0, 300, 120) { }

        public override void Attack(Character c)
        {
            c.Health -= Damage;
        }
    }
    public class Mage : Character
    {
        public Mage(): base(300, 100, 75) 
        { 
        }

        public override void Attack(Character c)
        {
            this.Mana -= 100;
            c.Health -= 2 * Damage;
        }
    }


}
