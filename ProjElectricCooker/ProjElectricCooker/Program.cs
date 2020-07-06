using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace ProjElectricCooker
{
  partial class Program
  {
    enum CookerProcess { None, Riceing, Watering, Washing, Draining, Cooking, Completion, Warming };

    private struct RiceCookerInfo
    {
      public bool Cover; // 뚜껑 열기 닫기
      public bool Power;        
      public CookerProcess State;               
      public int Rice;   // 쌀의 양 g 기준, 출력 때 환산
      public int Water;  // 물의 양 미리 리터 기준, 출력때 환산
      public int Number; // 인원수

      public RiceCookerInfo(int _Rice, int _Water)
      {
        Rice = _Rice;
        Water = _Water;
        State = CookerProcess.None;           
        Cover = false;
        Power = false;           
        Number = 0;
      }
    }
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
        case CookerProcess.Riceing:
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
    
    static void PowerLine(bool Power)
    {
      if(Power)
      {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(4, 17);
        Console.Write("──────");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;               
      }
      else
      {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(4, 17);
        Console.Write("──────");
      }
    }
   
    static void Main(string[] args)
    {
      Console.SetWindowSize(99, 36);
      // RiceCookerInfo RCInfo = RiceCookerInfo(10000, 5000);
      RiceCookerInfo RCInfo = new RiceCookerInfo(10000, 5000);
  
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
        OutFrame();
        RiceCookerBox(16,11);
        Cover(RCInfo.Cover);
        RiceInfo(RCInfo);
        PowerLine(RCInfo.Power);
        RiceHeight(50, 2, RCInfo.Rice);
        WaterHeight(74, 2, RCInfo.Water);
        Menu(65, 25, menuItem);
        
        if(MainMenuIndex == 9)
          break;

        switch (MainMenuIndex)
        {
          case 0: // Power 
            RCInfo.Power = !RCInfo.Power;
            break;
          
          case 1: // Open 
            if (RCInfo.State == CookerProcess.Cooking)
            {
              MessageBox(51, 27, " It's not allowed to open the cover on cooking..");
              Console.ReadKey(true);
            }
            else
            {
              RCInfo.Cover = !RCInfo.Cover;
            }
            break;
          
          case 2: // 취사
            if (!RCInfo.Power)
            {
              MessageBox(51, 27, "Power is off");
              Console.ReadKey(true);
              break;
            }

            if (RCInfo.Cover)
            {
                // 밧데리로 일부 메시지 전달
                MessageBox(51, 27, "Cover is open");
                Console.ReadKey(true);
                break;
            }

            if (RCInfo.Number == 0)
            {
                // 밧데리로 일부 메시지 전달
                MessageBox(51, 27, "인원수를 입력해 주세요");
                Console.ReadKey(true);
                break;
            }
            
            int Rice = RCInfo.Rice - (RCInfo.Number * 160); // 쌀 일인분 160g
            if (Rice < 0)
            {
                MessageBox(51, 27, "  ??? 쌀 부족 ???");
                Console.ReadKey(true);
                break;
            }
            
            int Water;
            Water = RCInfo.Water - (RCInfo.Number * 170)*5;
            if (Water < 0)
            {
                MessageBox(51, 27, "  ??? 물 부족 ???");
                Console.ReadKey(true);
                break;
            }

            // Note: 취사 시작 부분, 쌀 넣기 -> 물 넣기 -> 쌀 씻기 -> 배수 -> 취사 -> 보온
            RCInfo.State = CookerProcess.Riceing;
            RiceInfo(RCInfo);

            Console.SetCursorPosition(24, 12);
            Console.Write("쌀 넣기");
            Console.SetCursorPosition(18, 13);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 14);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 15);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 16);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 17);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            RCInfo.Rice = RCInfo.Rice - (RCInfo.Number * 160); // 1인분 160g
            RiceHeight(50, 2, RCInfo.Rice);
            Thread.Sleep(3000); // 3초 정도                            
            
            for (int i = 0; i < 2; i++)
            {
                // Note: 물 넣기 --> 파란 색 보여 주기
                RCInfo.State = CookerProcess.Watering;
                RCInfo.Water = RCInfo.Water - (RCInfo.Number * 170 * 2);
                RiceInfo(RCInfo);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(24, 12);
                Console.Write("물 넣기");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(18, 13);
                Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
                Console.SetCursorPosition(18, 14);
                Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
                Console.SetCursorPosition(18, 15);
                Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
                Console.SetCursorPosition(18, 16);
                Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
                Console.SetCursorPosition(18, 17);
                Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");                            
                WaterHeight(74, 2, RCInfo.Water);
                Thread.Sleep(3000); // 3초 정도

                // Note: 쌀 씻기 
                RCInfo.State = CookerProcess.Washing;
                RiceInfo(RCInfo);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(24, 12);                           
                Console.Write("쌀 씻기");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(18, 13);
                Console.Write("~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
                Console.SetCursorPosition(18, 14);
                Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
                Console.SetCursorPosition(18, 15);
                Console.Write("~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
                Console.SetCursorPosition(18, 16);
                Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
                Console.SetCursorPosition(18, 17);
                Console.Write("~ ~ ~ ~ ~ ~ ~ ~ ~ ~");                          
                Thread.Sleep(3000); // 3초 정도

                // Note: 물 배수 
                RCInfo.State = CookerProcess.Draining;
                RiceInfo(RCInfo);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(24, 12);
                Console.Write(" 배수 ");
                for (int j = 0; j < 5; j++)
                {
                    // 지우기
                    Console.BackgroundColor = ConsoleColor.Black;
                    for (int k = 0; k < j; k++)
                    {
                        Console.SetCursorPosition(18, 13 + k);
                        Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
                    }

                    // 물 출력
                    Console.BackgroundColor = ConsoleColor.Blue;
                    for (int k = j; k < 5; k++)
                    {
                        Console.SetCursorPosition(18, 13 + k);
                        Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
                    }
                    Thread.Sleep(700);                               
                }
                
            }

            // Note: 취사용 물 공급
            RCInfo.Water = RCInfo.Water - (RCInfo.Number * 170);                        
            WaterHeight(74, 2, RCInfo.Water);
            RiceInfo(RCInfo);

            // Note: 취사 시작
            RCInfo.State = CookerProcess.Cooking;
            RiceInfo(RCInfo);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(24, 12);
            Console.Write("취사 중");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(18, 13);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 14);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 15);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 16);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 17);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Thread.Sleep(7000); // 7초 정도

            // Note: 완료 , 사운드 삐리릭...
            RCInfo.State = CookerProcess.Completion;
            RiceInfo(RCInfo);

            Thread.Sleep(7000); // 3초 정도

            Console.SetCursorPosition(24, 12);
            Console.Write("취사 완료");
            Thread.Sleep(3000); // 3초 정도
            
            // Note: 보온
            RCInfo.State = CookerProcess.Warming;
            RiceInfo(RCInfo);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(24, 12);
            Console.Write("보온 중  ");                        
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(18, 13);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 14);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 15);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 16);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Console.SetCursorPosition(18, 17);
            Console.Write("⊙ ⊙ ⊙ ⊙ ⊙ ⊙ ⊙");
            Thread.Sleep(3000); // 3초 정도
            Console.ForegroundColor = ConsoleColor.White;

            RCInfo.Number = 0; // Note: 인원수 초기화
            break;
        case 3: // Note:보온
            if (!RCInfo.Power)
            {
                // 밧데리로 일부 메시지 전달
                MessageBox(51, 27, "전원이 꺼져 있습니다");
                Console.ReadKey(true);
                break;
            }

            RCInfo.State = CookerProcess.Warming;
            RiceInfo(RCInfo);
            break;
        case 4: // 취소
            RCInfo.State = CookerProcess.None;                        
            RiceInfo(RCInfo);
            break;                   
        case 5: // 인원수
            if (!RCInfo.Power)
            {
                // 밧데리로 일부 메시지 전달
                MessageBox(51, 27, "전원이 꺼져 있습니다");
                Console.ReadKey(true);
                break;
            }

            MessageBox(51, 27, " 식사할 인원 수 : ");
            try {
                RCInfo.Number = int.Parse(Console.ReadLine());
            }catch(Exception e)
            {
                RCInfo.Number = 0;
            }
            break;

        case 6: // 쌀통 설정
            {                            
                string Message = "현재 쌀의 양(kg) : " + (RCInfo.Rice / 1000);
                MessageBox(51, 27, Message);                           
                Console.SetCursorPosition(63, 29);
                Console.Write("추가할 쌀 양(kg) : ");
                string Amount = Console.ReadLine();
                try
                {
                    RCInfo.Rice += int.Parse(Amount) * 1000; // kg 단위
                    if(RCInfo.Rice > 18000) // 18kg 최대
                    {
                        RCInfo.Rice -= int.Parse(Amount) * 1000;
                        MessageBox(51, 27, "양이 너무 많습니다");
                        Console.ReadKey(true);
                        break;
                    }
                }catch(Exception e)
                {
                    break;
                }                          
            }
            break;
        case 7: // 뭍통 설정
            {
                string Message = "현재 물의 양(리터) : " + (RCInfo.Water / 1000);
                MessageBox(51, 27, Message);
                string Amount = string.Empty;
                Console.SetCursorPosition(63, 29);
                Console.Write("추가할 물의 양(리터) : ");
                Amount = Console.ReadLine();
                try
                {
                    RCInfo.Water += int.Parse(Amount) * 1000; // 리터를 밀리리터로 
                    if(RCInfo.Water > 18000)
                    {
                        RCInfo.Water -= int.Parse(Amount) * 1000;
                        MessageBox(51, 27, "양이 너무 많습니다");
                        Console.ReadKey(true);
                        break;
                    }                                
                }catch(Exception e)
                {
                    break;
                }                            
            }
            break;
        }
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