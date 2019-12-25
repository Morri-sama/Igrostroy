using Igrostroy.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrostroy.Skills
{
    public abstract class SkillBase
    {
        public string Name { get; set; }
        public SkillType Type { get; set; }
        public SkillTarget Target { get; set; }

        public abstract void Use(Character player, Character enemy);
    }
}
