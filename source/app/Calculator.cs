using System;
using System.Data;

namespace app
{
  public class Calculator
  {
    readonly IDbConnection database;

    public Calculator(IDbConnection db) { database = db; }

    public int add(int i, int i1)
    {
      if (i < 0 || i1 < 0)
        throw new ArgumentException("Dumb calculator cannot add negative numbers. Maybe try the smart calculator?");
      database.Open();
      database.Dispose();

      return i + i1;
    }
  }
}