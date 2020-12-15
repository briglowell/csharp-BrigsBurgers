using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger
  {

    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string Title { get; set; }

    [Required]
    [Range(1, 4)]
    public int Patties { get; set; }
    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    // public Burger(int id, string title, int patties, string description)
    // {
    //   Id = id;
    //   Title = title;
    //   Patties = patties;
    //   Description = description;
    // }
  }
}