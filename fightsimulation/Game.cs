using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fightsimulation
{
    //creating the monsters structures
    struct Monster
    {
        public string name;
        public float health;
        public float attack;
        public float defense;

        public Monster(
            string name,
            float health,
            float attack,
            float defense)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
            this.defense = defense;
        }
    }
    internal class Game
    {
        bool _gameOver = false;
        Monster _monster1;
        Monster _monster2;
        Monster _monster3;
        //creating the actul monsters and printing stats
        void Start()
        {
            //monster 1
            _monster1 = new Monster ("Wompus", 100, 15, 5);

            //monster 2
            _monster2 = new Monster ("Thwompus", 80, 15, 10);

            _monster3 = new Monster("Gim", 4800, 1000, 1);

            PrintStats(_monster1);
            PrintStats(_monster2);
        }

        void Update()
        {
            //fight 1
            while (_monster1.health > 0 && _monster2.health > 0)
            {
                Console.WriteLine("_______________");
                // monster1 attacks monster2
                Console.WriteLine(_monster2.name + " Has taken " + Fight(_monster1, ref _monster2) + " damage!");

                //monster2 attacks monster1
                Console.WriteLine(_monster1.name + " Has taken " + Fight(_monster2, ref _monster1) + " damage!");

                PrintStats(_monster1);
                PrintStats(_monster2);
            }

            //pandoras box
            Monster monster = _monster1.health <= 0 ? _monster2 : _monster1;

            //solution 2
            Monster winningMonster;
            if (_monster1.health <= 0)
            {
                winningMonster = _monster2;
            }
            else if (_monster2.health <= 0)
            {
                winningMonster = _monster1;
            }

            // solution 1
            if (_monster1.health <= 0)
            {
                //Monster2 fights Gim

            }
            else if (_monster2.health <= 0)
            {
                //monster1 fights Gim
            }

            _gameOver = true;
        }
        //end of the game
        void End()
        {
            Console.ReadKey();
        }
        //how the game is going to run
        public void Run()
        {
            Start();

            while (!_gameOver)
            {
            Update();
            }

            End();

        }
        //giving monsters the ability to fight
        float Fight(Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker.attack, defender.defense);
            defender.health -= damageTaken;
            return damageTaken;
        }
        //calcuates the amount of damage each monster does to each other
        float CalculateDamage(float attack, float defense)
        {
            float damage = attack - defense;

            //damage clamp method 1
            if (damage <= 0)
            {
                damage = 0;
            }

            return damage;
        }
        //gives the monsters there stat line
        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name:    " + monster.name);
            Console.WriteLine("Health:  " + monster.health);
            Console.WriteLine("Attack:  " + monster.attack);
            Console.WriteLine("Defense: " + monster.defense);
        }
    }
}
