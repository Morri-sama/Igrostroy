using System;
using System.Collections.Generic;
using System.Text;
using Igrostroy.Models.Characters;

namespace Igrostroy.Skills
{
    public class MeleeHit : SkillBase
    {
        public MeleeHit()
        {
            Name = "MeleeHit";
            Target = SkillTarget.Ememy;
            Type = SkillType.Active;
        }


        public override void Use(Character player, Character enemy)
        {
            int damage = player.Characteristics.Strength * 100;

            enemy.Health -= 1000;
            Console.WriteLine($"Персонажу {enemy.Name} нанесён урон в рамере {damage}");
        }
    }
}
