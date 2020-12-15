using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;
    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Burger> GetAll()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }

    public Burger Create(Burger burger)
    {
      string sql = @"INSERT INTO burgers
            (title, patties, description)
            VALUES
            (@Title, @Patties, @Description);
            SELECT LAST_INSERT_ID();";
      burger.Id = _db.ExecuteScalar<int>(sql, burger);
      return burger;
    }

    public Burger GetById(int id)
    {
      string sql = "SELECT * FROM burgers WHERE id = @Id";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    // NOTE return bool for error handling in service
    public bool Delete(int id)
    {
      string sql = "DELETE FROM burgers WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    public Burger Edit(int index, Burger editedBurger)
    {
      string sql = @"UPDATE burgers SET title = @Title, patties = @Patties, description = @Description WHERE id = @Id;
      SELECT * FROM burgers WHERE id = @Id";
      editedBurger.Id = _db.ExecuteScalar<int>(sql, editedBurger);
      return editedBurger;
      //   return _db.QueryFirstOrDefault<Burger>(sql, editedBurger);

    }
  }
}