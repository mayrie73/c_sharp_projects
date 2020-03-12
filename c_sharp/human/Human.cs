using System;
namespace human
{
    //Create a base Human class with five attributes: name, strength, intelligence, dexterity, and health.
    //Give a default value of 3 for strength, intelligence, and dexterity. Health should have a default of 100.

    public class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        //When an object is constructed from this class it should have the ability to pass a name
        public Human(string newName)
        {
            name = newName;
        }
        //Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
        public Human(string n, int s, int i, int d, int h)
        {
            name = n;
            strength = s;
            intelligence = i;
            dexterity = d;
            health = h;
        }
        //Now add a new method called attack, which when invoked, should attack another Human object that is passed as a parameter. 
        //The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker).
        public int Attack(Human victim)
        {
            int damage = this.strength * 5;
            Console.WriteLine("Victims name is {0}", victim.name);
            victim.health -= damage;
            return victim.health;
        }
       public object Attack(object thing){
           if(thing is Human){
               Human victim = this as Human;
               int damage = this.strength * 5;
               victim.health -=damage;
            Console.WriteLine("{0} was attacked by {1} and lost {2} health points. Health is now {3}", victim.name, this.name, damage, victim.health);
              return (victim as Human);
           } else{
               Console.WriteLine("Attack failed");
               return thing;
           }
       }
    }

}