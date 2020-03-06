using Box.BL.Abstractions;
using Box.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box.MyCollections;

namespace Box.BL.Services
{
    public class FighterService : IFighterService
    {
        private const int health = 100;

        public delegate void FightHandler(string msg);
        public event FightHandler Winner;
        private FighterCollection<Fighter> fighters = new FighterCollection<Fighter>();
        public void CreateFighter(string name, string nationality, int height, int weight, int age)
        {
            Fighter fighter = new Fighter
            {
                Health = health,
                Name = name,
                Nationality = nationality,
                Height = height,
                Weight = weight,
                Age = age
            };
            fighters.Add(fighter);
        }

        public int GetNumber(Fighter f)
        {
            return fighters.IndexOf(f);
        }
        public FighterCollection<Fighter> ShowFighters()
        {
            return fighters;
        }

        public bool RemuveFighter(int index)
        {
            if (index < 0 || index > fighters.Count)
            {
                return false;
            }
            else
            fighters.RemoveAt(index);
            return true;
        }
        public Fighter ChooseFighter(int fighter)
        {
            return fighters.Choose(fighter);
        }
        public static int FighterDamage()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 10);
            return value;
        }
        public bool CheckFighters()
        {
            if (fighters.Count < 2)
            {
                return false;
            }
            else
                return true;
        }
        public void StartFight(Fighter myFighter,Fighter enemyFighter)
        {
            myFighter.Health = health;
            enemyFighter.Health = health;
            do
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 10);
                
                if (value < 5)
                {
                    myFighter.Health -= FighterDamage();
                }
                else 
                {
                    enemyFighter.Health -= FighterDamage();
                }
            } while (myFighter.Health > 0 || enemyFighter.Health > 0);
            if (myFighter.Health <= 0 || enemyFighter.Health <= 0)
            {
                if (myFighter.Health <= 0)
                {
                    Winner?.Invoke("Ваш боец поражен!");
                }
                else
                    Winner?.Invoke("Ваш боец победил!");
            }
        }
    }
}
