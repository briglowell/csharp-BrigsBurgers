using System;
using System.Collections.Generic;
using System.Reflection;
using BurgerShack.db;
using BurgerShack.Models;
using BurgerShack.repositories;

namespace BurgerShack.Services
{
  public class BurgerService
  {
    private readonly BurgerRepository _br;

    public BurgerService(BurgerRepository br)
    {
      _br = br;
    }
    public IEnumerable<Burger> GetALL()
    {
      return _br.GetAll();
    }

    internal object GetById(int index)
    {
      return _br.GetById(index);
    }

    public Burger Create(Burger newBurger)
    {
      return _br.Create(newBurger);
    }

    public string Delete(int index)
    {
      if (_br.Delete(index))
      {
        return "Burger deleted!";
      }
      else return "not deleted";
    }

    public Burger Edit(int index, Burger editedBurger)
    {

      Burger oldBurger = _br.GetById(index);

      // Burger OldBurger = Mapper.Map<Burger>(_br.GetById(index));

      //NOTE looping through an object and compares

      // foreach (PropertyInfo prop in oldBurger.GetType().GetProperties())
      // {
      //   object oldValue = prop.GetValue(oldBurger, null);
      //   object newValue = prop.GetValue(editedBurger, null);
      //   if (!object.Equals(oldValue, newValue) && newValue != null)
      //   {
      //     oldValue = newValue;
      //     prop.SetValue(oldBurger, newValue);
      //   }
      // }

      //NOTE same function basically
      if (editedBurger.Title != null)
      {
        oldBurger.Title = editedBurger.Title;
      }
      if (editedBurger.Patties != 0)
      {
        oldBurger.Patties = editedBurger.Patties;
      }
      if (editedBurger.Description != null)
      {
        oldBurger.Description = editedBurger.Description;
      }

      return _br.Edit(index, oldBurger);

      // FakeDB.burgers[index] = editedBurger;
      // return editedBurger;

    }


  }
}