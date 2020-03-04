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
        private FighterCollection<Fighter> fighters = new FighterCollection<Fighter>();
        public void CreateFighter(string name, string nationality, int height, int weight, int health, int maxDamage, int age)
        {
            Fighter fighter = new Fighter
            {
                Name = name,
                Nationality = nationality,
                Height = height,
                Weight = weight,
                Health = health,
                MaxDamage = maxDamage,
                Age = age
            };
            fighters.Add(fighter);
        }
        public void ShowFighters()
        {
            foreach (Fighter fighter in fighters)
            {
                Console.WriteLine(fighter.Name +" "+ fighter.Age);
            }
        }
    }
}
