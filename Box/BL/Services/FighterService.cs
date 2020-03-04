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
        public FighterCollection<Fighter> ShowFighters()
        {
            return fighters;
        }

        public void RemuveFighter(int index)
        {
            fighters.RemoveAt(index);
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
        public void StartFight(Fighter myFighter,Fighter enemyFighter)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 10);
            if (value < 5)
            {

            }
        }
    }
}
