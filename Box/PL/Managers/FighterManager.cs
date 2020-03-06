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
                Console.WriteLine("1.Создать бойца;\n" + 
                                  "2.Показать список бойцов;\n" +
                                  "3.Удалить бойца;\n" +
                                  "4.Начать бой;\n");
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
                    case "4":
                        Fight();
                        break;

                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void Create()
        {
            Console.WriteLine("Имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Национальность: ");
            string nationality = Console.ReadLine();
            Console.WriteLine("Возраст: ");
            int age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Рост: ");
            int height = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Вес: ");
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
                    if (item != null)
                    {
                        Console.WriteLine($"Номер: {fighterService.GetNumber(item)}\n" +
                                          $"Имя: {item.Name}\n" +
                                          $"Национальность: {item.Nationality}\n" +
                                          $"Возраст: {item.Age}\n" +
                                          $"Рост: {item.Height}\n" +
                                          $"Вес: {item.Weight}\n");
                    }
                    else
                        break;
                }
            }
        }
        private void Remove()
        {
            Console.WriteLine("Введите номер бойца которго нужно удалить: ");
            if (!fighterService.RemuveFighter(Int32.Parse(Console.ReadLine())))
            {
                Console.WriteLine("Неверно введен номер бойца!");
            }
            else
                Console.WriteLine("Боец удален!");
        }
        public void Fight()
        {
            if (fighterService.CheckFighters())
            {
                Console.WriteLine("Введите номер вашего бойца: ");
                var myFighter = fighterService.ChooseFighter(Int32.Parse(Console.ReadLine()));
                Console.WriteLine($"Ваш боец:{myFighter.Name}");
                Console.WriteLine("Введите номер соперникаы: ");
                var enemyFighter = fighterService.ChooseFighter(Int32.Parse(Console.ReadLine()));
                fighterService.Winner += WhoWin;
                fighterService.StartFight(myFighter, enemyFighter);
            }
            else
                Console.WriteLine("Нужно создать не менее двух бойцов!");
        }

        public static void WhoWin(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
