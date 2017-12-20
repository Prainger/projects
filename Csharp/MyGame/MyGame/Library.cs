using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Library
    {
        private readonly List<Hero> _heroes = new List<Hero>();

        public Library()
        {
            //Batman
            Attack fist = new Attack("Fist", 10, 5, 50, 1.4);
            Attack hook = new Attack("Hook & Fist combo", 40, 18, 30, 2.1);
            Attack rampage = new Attack("Rampage", 280, 175, 10, 1.5);
            List<Attack> batmanAttacks = new List<Attack> {fist, hook, rampage};
            Hero batman = new Hero("Batman", 350, 175, batmanAttacks);
            _heroes.Add(batman);
            //Pikachu
            Attack tail = new Attack("Tail whip", 10, 5, 50, 3.0);
            Attack ball = new Attack("Electro ball", 50, 24, 30, 3.0);
            Attack shock = new Attack("Thunder shock", 300, 150, 10, 1.3);
            List<Attack> pikachuAttacks = new List<Attack> {tail, ball, shock};
            Hero pikachu = new Hero("Pikachu", 300, 150, pikachuAttacks);
            _heroes.Add(pikachu);
            //Thor
            Attack tornado = new Attack("Tornado", 20, 0, 20, 1.5);
            Attack lightning = new Attack("Lightning", 100, 50, 80, 2);
            Attack hammer = new Attack("Hammer hit", 350, 100, 30, 2.5);
            List<Attack> thorAttacks = new List<Attack>{tornado, lightning, hammer};
            Hero thor = new Hero("Thor", 1000, 120, thorAttacks);
            _heroes.Add(thor);
            //Legoles
            Attack arrow = new Attack("Arrow", 25, 10, 100, 2);
            Attack hit = new Attack("Bow hit", 100, 55, 30, 1.3);
            Attack stormOfArrows = new Attack("Storm of arrows", 400, 250, 20, 1.5);
            List<Attack> legolasAttacks = new List<Attack>{arrow, hit, stormOfArrows};
            Hero legolas = new Hero("Legolas", 750, 400, legolasAttacks);
            _heroes.Add(legolas);
            //Zed
            Attack basicAttack = new Attack("Basic Attack", 15, 0, 90, 3);
            Attack razorShuriken = new Attack("Razor Shuriken", 100, 65, 0, 1);
            Attack livingShadow = new Attack("Living Shadow", 0, 45, 0, 1);
            Attack shadowSlash = new Attack("Shadow_Slash", 65, 45, 50, 1.5);
            Attack deathMark = new Attack("Death Mark", 30, 30, 10, 2);
            Attack combo1 = new Attack("Shadow and Shuriken combo", 200, 110, 0, 1);
            Attack combo2 = new Attack("Death Mark, Shadow and shuriken combo", 430, 140, 10, 2);
            Attack combo3 = new Attack("Death Mark, Shadow and shuriken combo", 360, 140, 40, 1.5);
            Attack combo4 = new Attack("Full combo", 560, 185, 10, 1.3);
            List<Attack> zedAttacks = new List<Attack>{basicAttack, razorShuriken, livingShadow, shadowSlash,
                deathMark, combo1, combo2, combo3, combo4};
            Hero zed = new Hero("Zed", 666, 200, zedAttacks);
            _heroes.Add(zed);
        }

        public Hero ChooseHero()
        {
            for (int i = 0; i < _heroes.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + _heroes[i] + ". " + _heroes[i].GetName() + " has attacks: ");
                _heroes[i].PrintAttacks();
            }
            Console.WriteLine("Choose one of the heroes! ");
            return ValidIndex();

        }

        private Hero ValidIndex()
        {
            string myInput = null;
            while (myInput == null)
            {
                myInput = Console.ReadLine();
            }
            try
            {
                int intInput = Int32.Parse(myInput) - 1;
                Hero myHero =  _heroes[intInput];
                return myHero;
            }
            catch (Exception)
            {
                return ValidIndex();
            }
        }

        public Hero ComputerChooseHero()
        {
            Random random = new Random();
            int index = random.Next(0, _heroes.Count);
            return _heroes[index];
        }
    }
}