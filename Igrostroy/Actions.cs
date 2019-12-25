using Igrostroy.Models;
using Igrostroy.Models.Characters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Igrostroy
{
    public class Actions
    {
        [Description("Создать персонажа")]
        public Character CreateCharacter()
        {
            Console.WriteLine("Начнём создание персонажа.");
            Console.WriteLine("Введите имя");

            string name = Console.ReadLine();

            Character character = new Character
            {
                Name = name,
                Characteristics = new Characteristics
                {
                    Agility = 8,
                    Charisma = 8,
                    Constitution = 8,
                    Dexterity = 8,
                    Intelligence = 8,
                    Perception = 8,
                    Strength = 8,
                    Willpower = 8
                },
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "MeleeHit"
                    }
                },
                Health = 300000
            };

            Console.WriteLine("Персонаж создан.");

            return character;
        }

        public Character GetCharacter()
        {
            using (GameDbContext context = new GameDbContext())
            {
                var characters = context.Characters.Include(c => c.Skills).Include(s => s.Characteristics).ToList();

                for (int i = 0; i < characters.Count; i++)
                {
                    Console.WriteLine($"{i}) {characters[i].Name}");
                }

                return characters.ElementAt(int.Parse(Console.ReadLine()));
            }
        }

        public Character GetCharacterExclude(Character character)
        {
            using (GameDbContext context = new GameDbContext())
            {
                var characters = context.Characters.Include(c => c.Skills).Include(s => s.Characteristics).Where(r => r.Id != character.Id).ToList();

                for (int i = 0; i < characters.Count; i++)
                {
                    Console.WriteLine($"{i}) {characters[i].Name}");
                }

                return characters.ElementAt(int.Parse(Console.ReadLine()));
            }
        }


        [Description("Начать игру с выбранными персонажами")]
        public void Play(Character player, Character enemy)
        {

        }
    }
}
