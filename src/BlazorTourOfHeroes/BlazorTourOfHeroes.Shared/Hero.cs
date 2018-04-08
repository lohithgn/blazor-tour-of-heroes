using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorTourOfHeroes.Shared
{
    public class Hero
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
