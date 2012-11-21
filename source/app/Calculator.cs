using System;
using System.Data;

namespace app
{
  public class Calculator
  {
  	private readonly IDbConnection _connection;
	private readonly IDbCommand _command;

  	public Calculator(IDbConnection connection)
  	{
  		_connection = connection;
		_command = _connection.CreateCommand();
  	}

  	public int add(int i, int i1)
    {
        if (i <0 || i1 < 0)
            throw new ArgumentException("Dumb calculator cannot add negative numbers. Maybe try the smart calculator?");

		_connection.Open();
		_command.ExecuteNonQuery();

        return i + i1;
    }
  }
}