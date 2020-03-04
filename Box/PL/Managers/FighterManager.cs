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
                                  "2.Show;\n");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Create();
                        break;
                    case "2":
                        Show();
                        break;
                    case "3":
                        Remove();
                        break;

                }
                Console.ReadKey();
                Console.Clear();
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
            fighterService.CreateFighter(name, nationality, height, weight, age);
        }
        private void Show()
        {
            var collect = fighterService.ShowFighters();
            if (collect.Count == 0)
            {
                Console.WriteLine("Сначала создайте бойца");
            }
            else
            {
                foreach (var item in collect)
                {
                    Console.WriteLine($"Имя: {item.Name}\n" +
                                      $"Национальность: {item.Nationality}\n" +
                                      $"Возраст: {item.Age}\n" +
                                      $"Рост: {item.Height}\n" +
                                      $"Вес: {item.Weight}\n");
                }
            }
        }
        private void Remove()
        {
            Console.WriteLine("Введите номер бойца которго нужно удалить: ");
            fighterService.RemuveFighter(Int32.Parse(Console.ReadLine()));
        }
        public void Fight()
        {
            Console.WriteLine("Введите номер вашего бойца: ");
            var myFighter = fighterService.ChooseFighter(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Введите номер соперникаы: ");
            var enemyFighter = fighterService.ChooseFighter(Int32.Parse(Console.ReadLine()));
            fighterService.StartFight(myFighter,enemyFighter);
        }


    }
}
