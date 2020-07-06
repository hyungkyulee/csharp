using System;
using System.Data;

namespace ProjElectricCooker
{
  class Program
  {
    public static int MainMenuIndex = 0;

    static void RiceCookerBox(int x, int y)
    {
      int height = 20;
      Console.SetCursorPosition(x, y);
      Console.Write("-----------------------------------------------");
      for (int i = 1; i < height; i++)
      {
        Console.SetCursorPosition(x, y+i);
        Console.Write("|                                             |");
      }
      Console.SetCursorPosition(x,y+height);
      Console.Write("------------------------------------------------");
    }
    
    static void RiceOrWaterBox(int x, int y)
    {
      int height = 20;
      Console.SetCursorPosition(x, y);
      Console.Write("----------------------");
      for (int i = 1; i < height; i++)
      {
        Console.SetCursorPosition(x, y+i);
        Console.Write("|                    |");
      }
      Console.SetCursorPosition(x,y+height);
      Console.Write("----------------------");
    }

    static void RiceHeight(int x, int y, int Amount)
    {
      int height = Amount / 1000;
      Console.BackgroundColor = ConsoleColor.Black;
      for (int i = 0; i < 10; i++)
      {
        Console.SetCursorPosition(x, 2+i);
        Console.Write("                      ");
      }
      
      for (int i = 0; i < height; i++)
      {
        Console.SetCursorPosition(x, 19-i);
        Console.Write("O  O  O  O  O  O  O  O");
      }
    }
    
    static void WaterHeight(int x, int y, int Amount)
    {
      int height = Amount / 1000;
      Console.BackgroundColor = ConsoleColor.Black;
      for (int i = 0; i < 18; i++)
      {
        Console.SetCursorPosition(x, 2+i);
        Console.Write("                      ");
      }
      
      for (int i = 0; i < height; i++)
      {
        Console.SetCursorPosition(x, 19-i);
        Console.Write("O  O  O  O  O  O  O  O");
      }
    }
    
    static void InfoOrMenuBox(int x, int y)
    {
      int height = 13;
      Console.SetCursorPosition(x, y);
      Console.Write("-----------------------------------------------");
      for (int i = 1; i < height; i++)
      {
        Console.SetCursorPosition(x, y+i);
        Console.Write("|                                             |");
      }
      Console.SetCursorPosition(x,y+height);
      Console.Write("------------------------------------------------");
    }

    static void Cover(bool bOpen)
    {
      const int x = 16;
      if (bOpen)
      {
        Console.SetCursorPosition(x, 2);
        Console.Write("---");
        for (int i = 0; i < 7; i++)
        {
          Console.SetCursorPosition(x, 3+i);
          Console.Write("| |");
        }
        Console.SetCursorPosition(x, 10);
        Console.Write("---");
      }
      else
      {
        Console.SetCursorPosition(x, 9);
        Console.Write("----------------------");
        Console.SetCursorPosition(x, 10);
        Console.Write("----------------------");
      }
    }

    static void RiceInfo(RiceCookerInfo Info)
    {
      Console.BackgroundColor = ConsoleColor.Black;
      Console.SetCursorPosition(3,25);
      if(Info.Power)
        Console.Write("Power Status : ON");
      else
        Console.Write("Power Status : OFF");
      
      Console.SetCursorPosition(3,26);
      if(Info.Cover)
        Console.Write("Cover Status : Open");
      else
        Console.Write("Cover Status : Closed");
      
      Console.SetCursorPosition(3,27);
      switch (Info.State)
      {
        case CookerProcess.None:
          Console.Write("Cooker Status : Ready");
          break;
        case CookerProcess.Ricing:
          Console.Write("Cooker Status : Ricing");
          break;
        case CookerProcess.Watering:
          Console.Write("Cooker Status : Watering");
          break;
        case CookerProcess.Washing:
          Console.Write("Cooker Status : Washing");
          break;
        case CookerProcess.Draining:
          Console.Write("Cooker Status : Draining");
          break;
        case CookerProcess.Cooking:
          Console.Write("Cooker Status : Cooking");
          break;
        case CookerProcess.Completion:
          Console.Write("Cooker Status : Completed");
          break;
        case CookerProcess.Warming:
          Console.Write("Cooker Status : Warming");
          break;
      }
      
      Console.SetCursorPosition(3, 28 );
      Console.Write(" No. of Person: {0}", Info.Number);
      Console.SetCursorPosition(3, 29 );
      Console.Write(" Rice: {0:f1} kg", Info.Rice / 1000.0f);
      Console.SetCursorPosition(3, 30 );
      Console.Write(" Water: {0:f1}", Info.Water / 1000.0f);
    }

    static void MessageBox(int x, int y, string Message)
    {
      int height = 3;
      Console.SetCursorPosition(x, y);
      Console.Write("-----------------------------------------------");
      for (int i = 1; i < height; i++)
      {
        Console.SetCursorPosition(x, y+i);
        Console.Write("|                                             |");
      }
      Console.SetCursorPosition(x,y+height);
      Console.Write("------------------------------------------------");
      Console.SetCursorPosition(x+2, y+1);
      Console.Write(Message);
    }

    static void OutFrame()
    {
      RiceCookerBox(0, 0);
      RiceOrWaterBox(48, 0);
      RiceOrWaterBox(72, 0);
      InfoOrMenuBox(0, 21);
      InfoOrMenuBox(48, 21);
      Console.SetCursorPosition(17,1);
      Console.Write("Smart Cooker");
      Console.SetCursorPosition(58,1);
      Console.Write("Rice Tin");
      Console.SetCursorPosition(17,1);
      Console.Write("Water Tin");
      Console.SetCursorPosition(17,1);
      Console.Write("Cooker Info");
      Console.SetCursorPosition(17,1);
      Console.Write("[[ Menu ]]");
      
    }
   
    static void Main(string[] args)
    {
      // Console.SetWindowSize(99, 36);
      // RiceCookerInfo RCInfo = RiceCookerInfo(10000, 5000);
      // SoundPlayer Sound = new SoundPlayer();

      string[] menuItem =
      {
        "  Power  ",
        "  Open   ",
        "  Cook   ",
        "  Warm   ",
        "  Cancel ",
        "  Person ",
        "  Rice   ",
        "  Water  "
      };

      while (true)
      {
        Menu(65, 25, menuItem);
        if(MainMenuIndex == 9)
          break;
      }
    }

    static void Menu(int x, int y, string[] menuItem)
    {
      while (true)
      {
        for (int i = 0; i < menuItem.Length; i++)
        {
          if (MainMenuIndex == i)
          {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y + i);
            Console.Write(menuItem[i]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
          }
          else
          {
            Console.SetCursorPosition(x,y+i);
            Console.Write(menuItem[i]);
          }
        }

        var inputKey = Console.ReadKey(true);
        if(inputKey.Key == ConsoleKey.Enter)
        {
          break;
        }
        else if (inputKey.Key == ConsoleKey.UpArrow)
        {
          MainMenuIndex--;
          if (MainMenuIndex < 0)
            MainMenuIndex = 0;
        }
        else if (inputKey.Key == ConsoleKey.DownArrow)
        {
          MainMenuIndex++;
          if (MainMenuIndex == menuItem.Length)
            MainMenuIndex = menuItem.Length - 1;
        }
      }
    }

  }
}