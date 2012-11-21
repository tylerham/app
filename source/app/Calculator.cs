using System;

namespace app
{
  public class Calculator
  {
    public int add(int i, int i1)
    {
        if (i <0 || i1 < 0)
            throw new ArgumentException("Dumb calculator cannot add negative numbers. Maybe try the smart calculator?");

        return i + i1;
    }
  }
}