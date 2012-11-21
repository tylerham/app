using System;

namespace app
{
  public class Calculator
  {
    public int add(int i, int i1)
    {
      if(i1 < 0)
        throw new ArgumentException("Can not add negative number to positive.", "i1");
        return i + i1;
    }
  }
}