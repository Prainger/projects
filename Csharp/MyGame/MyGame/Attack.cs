using System;

namespace MyGame
{
    public class Attack
    {
        private readonly string _name;
        private readonly int _power;
        private readonly int _cost;
        private readonly int _criticalChance;
        private readonly double _criticalAmplifier;
        
        public Attack(string attackName, int attackPower, int energyCost, int criticalChance, double criticalAmplifier)
        {
            _name = attackName;
            _power = attackPower;
            _cost = energyCost;
            _criticalChance = criticalChance;
            _criticalAmplifier = criticalAmplifier;
        }
        public override string ToString()
        {
            return ("'" + _name + "' power: " + _power + ", cost: " + _cost + ", critical chance: " + _criticalChance +
                    "% and critical amplifier: " + _criticalAmplifier);
        }
        public int GetPower()
        {
            Random random = new Random();
            int critical = random.Next(0, 101);
            int attackPower = _power;
            if (critical <= _criticalChance)
            {
                attackPower = (int) (_power * _criticalAmplifier);
                Console.WriteLine("Critical attack power: " + attackPower);
            }
            else
            {
                Console.WriteLine("Attack power is: " + attackPower);
            }
            return attackPower;
        }
        public int GetCost()
        {
            return _cost;
        }
    }
}