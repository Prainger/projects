using System;

namespace MyGame
{
    public class Arena
    {
        private readonly Hero _hero1;
        private readonly Hero _hero2;
        private readonly bool _computer;
        private int RoundCounter { get; set; }

        public Arena(Hero hero1, Hero hero2, bool computer)
        {
            _hero1 = hero1;
            _hero2 = hero2;
            _computer = computer;
            RoundCounter = 1;
        }

        public bool IsGameOver()
        {
            return (_hero1.IsDefeated() || _hero2.IsDefeated());
        }

        public void PrintResult()
        {
            if (_hero1.IsDefeated())
            {
                if (_hero2.IsDefeated())
                {
                    Console.WriteLine("It is tie!");
                }
                else
                {
                    Console.WriteLine(_hero2.GetName() + " has won!");
                }
            }
            else if (_hero2.IsDefeated())
            {
                Console.WriteLine(_hero1.GetName() + " has won!");
            }
            else
            {
                Console.WriteLine("Continued to be in next round!");
            }
        }

        public void RestartMatch()
        {
            _hero1.Reset();
            _hero2.Reset();
            RoundCounter = 1;
        }

        public void PerformRound()
        {
            if (IsGameOver())
            {
                Console.WriteLine("Game is over!");
            }
            else
            {
                PerformAttack(_hero1, _hero2);
                if (!IsGameOver())
                {
                    PerformAttack(_hero2, _hero1);
                }
                RoundCounter++;
            }
        }

        private void PerformAttack(Hero attackH, Hero defence)
        {
            defence.Regenerate();
            
            Console.WriteLine(attackH.GetName() + "'s turn");
            Console.WriteLine(attackH.ToString());
            Console.WriteLine(defence.ToString());
            attackH.PrintAttacks();

            Attack attack;
            if (_computer && _hero2 == attackH)
            {
                attack = attackH.GetAttackFromComputer();
            }
            else
            {
                attack = attackH.GetAttackFromInput();
            }
            Console.WriteLine(attackH.GetName() + " has choosen "  + attack);
            attackH.AttackOtherHero(defence, attack);
        }
    }
}