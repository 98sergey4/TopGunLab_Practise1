using Box.BL.Abstractions;
using Box.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.BL.Services
{
    public class FighterService : IFighterService
    {
        private List<Fighter> fighters = new List<Fighter>();
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
    }
}
