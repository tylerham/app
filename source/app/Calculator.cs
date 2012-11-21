using System;
using System.Data;

namespace app
{
  public class Calculator
  {
    IDbConnection connection;
    IDbCommand command;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
      command = this.connection.CreateCommand();
    }

    public int add(int i, int i1)
    {
      if (i < 0 || i1 < 0)
        throw new ArgumentException("Dumb calculator cannot add negative numbers. Maybe try the smart calculator?");

      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }

      return i + i1;
    }

    public void shut_down()
    {
    }
  }
}