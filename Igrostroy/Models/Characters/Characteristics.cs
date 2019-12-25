using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Igrostroy.Models.Characters
{
    public class Characteristics
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Strength { get; set; }
        public int Constitution { get; set; }
        public int Agility { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Perception { get; set; }
        public int Willpower { get; set; }
        public int Charisma { get; set; }
             
        [ForeignKey("Character")]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
    }
}
