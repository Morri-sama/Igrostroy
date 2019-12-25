using Igrostroy.Combats;
using Igrostroy.Models;
using Igrostroy.Models.Characters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Igrostroy
{
    class Program
    {
        static void Main(string[] args)
        {
            Actions actions = new Actions();

            GameDbContext context = new GameDbContext();

            Console.WriteLine("Здравствуйте! \r\n С чего начнём?");

            Dictionary<int, string> menu = new Dictionary<int, string>
            {
                { 0, "Создать персонажа" },
                { 1, "Выбрать персонажа и начать играть" }
            };

            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Key}) {item.Value}");
            }

            bool cont = true;

            int? s = null;

            while (cont)
            {
                string k = Console.ReadLine();
                try
                {
                    s = int.Parse(k);
                }
                catch (FormatException ex)
                {

                }

                if (s != null)
                {
                    if (menu.ContainsKey(s ?? default))
                    {
                        cont = false;
                    }
                }
            }

            string ans = menu.GetValueOrDefault(s ?? default);

            switch (ans)
            {
                case "Создать персонажа":
                    {
                        context.Characters.Add(actions.CreateCharacter());
                        context.SaveChanges();
                        break;
                    }
                case "Выбрать персонажа и начать играть":
                    {
                        var character = actions.GetCharacter();
                        var enemy = actions.GetCharacterExclude(character);

                        Combat combat = new Combat(character, enemy);
                        combat.Start();

                        break;
                    }
            }

        }


    }
}
