using System;
using System.Data;

namespace app
{
  public class Calculator
  {
  	private readonly IDbConnection _connection;

  	public Calculator(IDbConnection connection)
  	{
  		_connection = connection;
  	}

  	public int add(int i, int i1)
    {
        if (i <0 || i1 < 0)
            throw new ArgumentException("Dumb calculator cannot add negative numbers. Maybe try the smart calculator?");

		_connection.Open();
        return i + i1;
    }
  }
}