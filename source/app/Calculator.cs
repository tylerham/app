using System;
using System.Data;

namespace app
{
  public class Calculator
  {
    readonly IDbConnection connection;

    public Calculator(IDbConnection connection) { this.connection = connection; }

    public int add(int i, int i1)
    {
      if (i < 0 || i1 < 0)
        throw new ArgumentException("Dumb calculator cannot add negative numbers. Maybe try the smart calculator?");

      connection.Open();
      var command = connection.CreateCommand();
      command.ExecuteNonQuery();
      return i + i1;
    }
  }
}