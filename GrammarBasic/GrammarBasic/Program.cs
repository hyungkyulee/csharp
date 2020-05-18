using System;

namespace GrammarBasic
{
  class A
  {
    
  }

  class B
  {
    
  }
  
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("===== C# Basic Grammar =====");

      Console.WriteLine("===== >> 11-2. as Data Type");
      string str1 = "123";
      object obj = str1; // boxing
      string str2 = obj as string;
      Console.WriteLine(str2);

      A test1 = new A();
      object obj1 = test1;
      B test2 = obj1 as B;
      if(test2 == null)
      {
        Console.WriteLine("Failed to change the data type.");
      }
      else
      {
        Console.WriteLine("Success to change the data type.");
      }
      
      Console.WriteLine("===== >> 11-3. bit and null operator");

      int? x = null; // nullable
      int y = x ?? -1;
      Console.WriteLine(y);
      x = 10;
      y = x ?? -1;
      Console.WriteLine(y);
      
      Console.WriteLine("===== >> 12-1. Control");
      // if/Else - false(0), true(other than 0)
      // switch/case - string is allowed in c#, and 'case' without 'break' is not allowed.
      // int nNum = 1;
      string name = "kyu";
      switch (name)
      {
        case "kyu":
          Console.WriteLine("kye is selected..");
          break; // in 'C/C++', all of the cases before the next 'break' are executable without break. 
        case "lee":
          Console.WriteLine("lee is selected..");
          break;
      }
    }
  }
}