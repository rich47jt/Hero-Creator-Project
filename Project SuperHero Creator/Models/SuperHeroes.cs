using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_SuperHero_Creator.Models
{
    public class SuperHeroes
    {
        [Key]
        public int Id { get; set; }
        public string HeroName { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility { get; set; }

        public static implicit operator DbSet<object>(SuperHeroes v)
        {
            throw new NotImplementedException();
        }
    }
}
