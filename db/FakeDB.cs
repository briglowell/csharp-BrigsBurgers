using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.db
{
  public class FakeDB
  {
    public static List<Burger> burgers { get; set; } = new List<Burger>()
    {
      // new Burger(1,"Chiabatta",true,true,true,true,"ketchup, mayo")
    };
  }
}