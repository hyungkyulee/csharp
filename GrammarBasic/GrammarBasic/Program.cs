using System;
using System.Collections;
using System.IO;
using System.Threading;

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
/*
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
      
      Console.WriteLine("===== >> 12-1. Control - switch/case");
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
      
      Console.WriteLine("===== >> 12-2. Control - for loop");
      // for(;;) - same as c/c++ indefinite loop
      // while(1) is not allowed in C# => while(true)
      int[] array1 = {1, 2, 3, 4};
      foreach (int nValue in array1) // variable inside foreach is read-only
      {
        Console.WriteLine(nValue);
      }

      var list = new ArrayList();
      list.Add(1);
      list.Add(2);
      list.Add(3);

      foreach (int m in list)
      {
        Console.WriteLine(m);
      }
      
      Console.WriteLine("===== >> 12-3. Exception");
      // exception is important in C# comparing to C++ (no exception in C)
      // System.Exception (derived objects in the below)
      //  - OverFlowException
      //  - FormatException
      //  - DivideByZeroException
      //  - FileNotFoundException
      // a variable should not be uninitialised inside try-catch as an uninitialised variable cannot be referred by outside of try-catch 
      // when 'throw' is used, the usage is - throw new [objects from System.Exception]
      try
      {
        array1[4] = 10;
      }
      catch (IndexOutOfRangeException e)
      {
        Console.WriteLine(e); // = Console.WriteLine(e.ToString());
        // throw;
        array1[3] = 99;
      }
      finally
      {
        Console.WriteLine("finally section is executing all the time regardless 'catch' of exception");
        // it can be useful like closing a opened network socket which should be all the time happening
      }

      for (int i = 0; i < array1.Length; i++)
      {
        Console.Write("{0} ", array1[i]);
      }
     
      Console.WriteLine("===== >> 13-1. 1st-Dimension Array");

      int[] nArray = {1, 2, 3, 4, 5};
      for (int i = 0; i<nArray.Length; i++)
      {
        Console.Write("{0} ", nArray[i]);
      }
      Console.Write("\n");
      foreach (int m in nArray) // use for a readonly purpose 
        Console.Write("{0} ", m);
      Console.Write("\n");
      string[] Days = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};
      foreach (string str in Days) // use for a readonly purpose 
        Console.Write(str + " ");
     
      Console.WriteLine("===== >> 13-2. Multi-Dimension Array");

      int[,] nArray = {{1, 2, 3}, {4, 5, 6}};
      for (int i = 0; i<2; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          Console.Write(nArray[i, j] + " "); 
        }
      }
      Console.Write("\n");
      
      
      foreach (int m in nArray) // use for a readonly purpose 
        Console.Write("{0} ", m);
      
      
      Console.Write("\n");
      string[,,] abc =
      {
        {{"a1","a2"}, {"a3","a4"}, {"a5","a6"}},
        {{"b1","b2"}, {"b3","b4"}, {"a5","a6"}},
        {{"c1","c2"}, {"c3","c4"}, {"a5","a6"}},
        {{"c1","c2"}, {"c3","c4"}, {"a5","a6"}}
      };
      for (int i = 0; i<4; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          for (int k = 0; k < 2; k++)
          {
            Console.Write(abc[i, j, k] + " ");
          }
        }
      }
      Console.Write("\n");

      Console.WriteLine("===== >> 15-1. Array methods");

      int[] nArrays = {1, 2, 3, 4, 5};
      Array.Clear(nArrays, 2, 3);
      foreach (int m in nArrays) // use for a readonly purpose 
        Console.Write("{0} ", m); 
      Console.Write("\n");

      var nArrayClone = (int[])nArrays.Clone(); // 'casting' is required because 'Clone' returns object
      foreach (int m in nArrayClone) // use for a readonly purpose 
        Console.Write("{0} ", m); 
      Console.Write("\n");

*/
      Console.WriteLine("===== >> 16-1. File I/O");
      
      FileStream fs = new FileStream("test.txt", FileMode.Create);
      StreamWriter sw = new StreamWriter(fs);
      sw.Close();
    }
  }
  
}