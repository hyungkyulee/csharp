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

  struct GRADE
  {
    public int Eng, Math, Sci, Total;
    public int Avr;
  }

  struct Data
  {
    public int var1;
    public float var2;
  }
  
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("===== C# Basic Grammar =====");
/*
      Console.WriteLine("================================================== >> 11-2. as Data Type");
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
      
      Console.WriteLine("================================================== >> 12-1. Control - switch/case");
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
      
      Console.WriteLine("================================================== >> 12-3. Exception");
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
     
      Console.WriteLine("================================================== >> 13-1. 1st-Dimension Array");

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
     
      Console.WriteLine("================================================== >> 13-2. Multi-Dimension Array");

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

      Console.WriteLine("================================================== >> 15-1. Array methods");

      int[] nArrays = {1, 2, 3, 4, 5};
      Array.Clear(nArrays, 2, 3);
      foreach (int m in nArrays) // use for a readonly purpose 
        Console.Write("{0} ", m); 
      Console.Write("\n");

      var nArrayClone = (int[])nArrays.Clone(); // 'casting' is required because 'Clone' returns object
      foreach (int m in nArrayClone) // use for a readonly purpose 
        Console.Write("{0} ", m); 
      Console.Write("\n");


      Console.WriteLine("===== >> 16-1. File I/O - StreamWriter");
      int value = 12;
      float value2 = 3.14f;
      string str = "Hello";
      
      FileStream fs = new FileStream("test.txt", FileMode.Create);
      StreamWriter sw = new StreamWriter(fs);
      
      sw.WriteLine(value);
      sw.WriteLine(value2);
      sw.WriteLine(str);
      
      sw.Close();
 

      Console.WriteLine("================================================== >> 16-2. File I/O - using");
      int value = 12;
      float value2 = 3.14f;
      string str = "Hello";
      using StreamWriter sw = new StreamWriter(new FileStream("test1.txt", FileMode.Create));
      sw.WriteLine(value);
      sw.WriteLine(value2);
      sw.WriteLine(str);
      // Close method is not required

      Console.WriteLine("================================================== >> 17-1. File I/O - ");

      // Test 
      // string str = "English: 90 Math: 100 Science: 95";
      // string[] str_element = str.Split(new char[] {' '});
      // int Eng = int.Parse(str_element[1]);
      // int Math = int.Parse(str_element[3]);
      // int Sci = int.Parse(str_element[5]);
      // int Total = Eng + Math + Sci;
      // float Avr = Total / 3.0f;
      // Console.WriteLine("{0} {1} {2} {3} {4}", Eng, Math, Sci, Total, System.Math.Round(Avr));

      string str;
      float average;
      Console.Write("Please input the number of student to archive : ");
      int nCount = int.Parse(Console.ReadLine());

      Console.WriteLine("Input the score of Eng, Math, Sci in order with space");
      GRADE[] grade = new GRADE[nCount];
      StreamWriter sw = new StreamWriter("test.txt");
      sw.WriteLine("# of Student: {0}", nCount);

      for (int i = 0; i < nCount; i++)
      {
        str = Console.ReadLine();
        string[] dataString = str.Split(new char[] {' '});
        grade[i].Eng = int.Parse(dataString[0]);
        grade[i].Math = int.Parse(dataString[1]);
        grade[i].Sci = int.Parse(dataString[2]);
        grade[i].Total = grade[i].Eng + grade[i].Math + grade[i].Sci;
        average = grade[i].Total / 3.0f;
        grade[i].Avr = (int) Math.Round(average);
      }

      for (int i = 0; i < nCount; i++)
      {
        sw.WriteLine("{0} {1} {2} {3} {4:f1}", grade[i].Eng, grade[i].Math, grade[i].Sci, grade[i].Total, grade[i].Avr);
      }
      sw.Close();
      
      Console.Write("Input File Name to Load ");
      string filename = Console.ReadLine();
      StreamReader sr = new StreamReader(filename);
      str = sr.ReadLine();
      // To do : data processing with str
      Console.WriteLine(str);
      sr.Close();
*/
      Data[] DataArray = new Data[2];

      DataArray[0].var1 = 7;
      DataArray[0].var2 = 3.14f;
      
      DataArray[1].var1 = 13;
      DataArray[1].var2 = 0.5f;
      
      BinaryWriter bw = new BinaryWriter(File.Open("binText.txt", FileMode.Create));
      // using (BinaryWriter bw = new BinaryWriter(File.Open("binText.txt", FileMode.Create)))
      for (int i = 0; i < DataArray.Length; i++)
      {
        bw.Write(DataArray[i].var1);
        bw.Write(DataArray[i].var2);
      }
      bw.Close(); // it could be omitted if 'using' is used ; e.g. using (BinaryWriter bw = new BinaryWriter(File.Open("binText.txt", FileMode.Create)))

      int var1;
      float var2;
      
      BinaryReader br = new BinaryReader(File.Open("binText.txt", FileMode.Open));
      while (true)
      {
        try
        {
          var1 = br.ReadInt32();
          var2 = br.ReadSingle();
          Console.WriteLine("{0} {1}", var1, var2);
        }
        catch (EndOfStreamException e) // cast exeption when reaching to the end of file
        {
          br.Close();
          break;
        }
      }
    }
  }
}