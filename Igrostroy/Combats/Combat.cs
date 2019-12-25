using Igrostroy.Models.Characters;
using Igrostroy.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Igrostroy.Combats
{
    public class Combat
    {
        public Combat(Character playerCharacter, Character enemy)
        {
            Player = playerCharacter;
            Enemy = enemy;

            PlayerCharacterHp = Player.Health;
            EnemyHp = Enemy.Health;

            Turn = Turn.Player;
        }

        public void Start()
        {
            do
            {
                ExecuteAction();
            } while (Player.Health >= 0 && Enemy.Health >= 0);
        }

        private void ExecuteAction()
        {
            Console.WriteLine("Выберите, какой скилл использовать на противнике.");
            if (Turn == Turn.Player)
            {
                for (int i = 0; i < Player.Skills.Count; i++)
                {
                    Console.WriteLine($"{i}) {Player.Skills[i].Name}");
                }

                int skillId = int.Parse(Console.ReadLine());

                string skillName = Player.Skills[skillId].Name;
                SkillBase skillBase = (SkillBase)Activator.CreateInstance(Type.GetType("Igrostroy.Skills." + skillName));


                skillBase.Use(Player, Enemy);


                Turn = Turn.Enemy;
                Console.WriteLine($"Наступает черёд {Enemy.Name}");

            }
            else
            {
                for (int i = 0; i < Enemy.Skills.Count; i++)
                {
                    Console.WriteLine($"{i}) {Enemy.Skills[i].Name}");
                }

                int skillId = int.Parse(Console.ReadLine());

                string skillName = Enemy.Skills[skillId].Name;
                SkillBase skillBase = (SkillBase)Activator.CreateInstance(Type.GetType("Igrostroy.Skills." + skillName));

                skillBase.Use(Enemy, Player);


                Turn = Turn.Player;
                Console.WriteLine($"Наступает черёд {Player.Name}");
            }

            Console.WriteLine($"{Player.Name}: hp = {Player.Health};");
            Console.WriteLine($"{Enemy.Name}: hp = {Enemy.Health};");
        }

        public Turn Turn { get; set; }

        public Character Player { get; set; }
        public Character Enemy { get; set; }

        public int PlayerCharacterHp { get; set; }
        public int EnemyHp { get; set; }
    }
}
