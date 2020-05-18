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
    }
  }
}