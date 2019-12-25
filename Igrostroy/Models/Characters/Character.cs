using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Igrostroy.Models.Characters
{
    public class Character
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }

        public int Health { get; set; }

        [ForeignKey("Characteristics")]
        public int CharacteristicsId { get; set; }
        public virtual Characteristics Characteristics { get; set; }

        public virtual List<Skill> Skills { get; set; }
    }
}
