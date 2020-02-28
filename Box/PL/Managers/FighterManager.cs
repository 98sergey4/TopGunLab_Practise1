using Box.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.PL.Managers
{
    public class FighterManager
    {
        private readonly FighterService fighterService = new FighterService();

        public void Start()
        {
            for (; ; )
            {
                Console.WriteLine("1.Create fighter;\n" + 
                                  "2.Show smth\n");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Create();
                        break;
                }
            }
        }
        private void Create()
        {
            Console.WriteLine("Input name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input nationality: ");
            string nationality = Console.ReadLine();
            Console.WriteLine("Input age: ");
            int age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input height: ");
            int height = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input weight: ");
            int weight = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input health: ");
            int health = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input maximal damage: ");
            int maxDamage = Int32.Parse(Console.ReadLine());
            fighterService.CreateFighter(name, nationality, height, weight, health, maxDamage, age);
        }
    }
}
