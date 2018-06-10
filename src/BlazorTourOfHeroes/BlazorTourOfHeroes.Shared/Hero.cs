using System.ComponentModel.DataAnnotations;

namespace BlazorTourOfHeroes.Shared
{
    public class Hero
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
