using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Hero
    {
        private readonly string _name;
        private int _health;
        private readonly int _maxHealth;
        private int _energy;
        private readonly int _maxEnergy;
        private readonly List<Attack> _listOfAttacks;
        private readonly int _energyRegen;
        private readonly int _healthRegen;
        
        public Hero(string name, int  health, int energy, List<Attack>  attacks)
        {
            _name = name;
            _health = health;
            _maxHealth = health;
            _energy = energy;
            _maxEnergy = energy;
            _listOfAttacks = attacks;
            _healthRegen = health / 10;
            _energyRegen = energy / 10;
        }

        public override string ToString()
        {
            return _name + " has " + _health + "/" + _maxHealth + " health and "
                   + _energy + "/" + _maxEnergy + " energy";
        }

        public void Regenerate()
        {
            _health = _health + _healthRegen;
            _energy = _energy + _energyRegen;
            if (_health  > _maxHealth)
            {
                _health = _maxHealth;
            }
            if (_energy > _maxEnergy)
            {
                _energy = _maxEnergy;
            }
        }

        private void TakeDamage(int damege)
        {
            _health = _health - damege;
            if (_health < 0)
            {
                _health = 0;
            }
        }

        public bool IsDefeated()
        {
            return _health == 0;
        }

        public void PrintAttacks()
        {
            for (int i = 0; i < _listOfAttacks.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine(j + " - " + _listOfAttacks[i]);
            }
        }

        public void AttackOtherHero(Hero hero, Attack attack)
        {
            _energy = _energy - attack.GetCost();
            hero.TakeDamage(attack.GetPower());
        }

        public void Reset()
        {
            _health = _maxHealth;
            _energy = _maxEnergy;
        }

        private bool HasEnoughEnergy(int index)
        {
            return _energy >= _listOfAttacks[index].GetCost();
        }

        public Attack GetAttackFromComputer()
        {
            int len = _listOfAttacks.Count;
            for (int i = 0; i < len - 1; i++)
            {
                if (HasEnoughEnergy(len - 1 - i))
                {
                    return _listOfAttacks[len - 1 - i];
                }
            } 
            return _listOfAttacks[1];
        }
        
        public Attack GetAttackFromInput()
        {    
            
            string myInput = null;
            while (myInput == null)
            {
                myInput = Console.ReadLine();
            }
            try
            {
                int intInput = Int32.Parse(myInput) - 1;
                Attack myAttack = _listOfAttacks[intInput];
                return myAttack;
            }
            catch (Exception)
            {
                return GetAttackFromInput();
            }
        }

        public string GetName()
        {
            return _name;
        }
    }
}