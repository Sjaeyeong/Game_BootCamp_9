using System.Collections.Specialized;
using System.Drawing;
using System.Security.Cryptography;

namespace Test1_day4
{
    internal class Program
    {
        static Random rand = new Random(); // 클래스 내부에 Random rand를 전역으로 사용하여 main뿐만 아니라 모든 함수에서 굳이 따로 선언할 필요를 없앰
        static void Main(string[] args)
        {
            string[] powerUp = { "ATK", "DEF", "H P", "A S", "SPD" }; // ATK : 공격력, DEF : 방어력, HP : 체력, AS : 공격속도, SPD : 이동속도

            int count = 0;

            while (count < 5) // 임시로 5회만 돌아가게 설정했음
            {

                Console.Write("임시 레벨업(치트) 아무키나 눌러주세요!");
                Console.ReadKey();
                Console.Clear();

                ConsoleLine();
                Console.WriteLine($"[{count + 1} / 5 회차]레벨업을 하였습니다. 강화를 선택해주세요! (넘패드 1 ~ 3번을 눌러주세요)");
                ConsoleLine();
                SelectEffect(powerUp);

                Console.WriteLine();

                Thread.Sleep(1000); // 그냥 이렇게 하니 딜레이 중에 숫자를 계속 누르면 선입력? 되는 현상이 발생했음!!
                Console.Clear();

                count++;

            }

            ConsoleLine();
            Console.WriteLine("5회의 임시 레벨업 및 강화를 마쳤습니다. 프로그램 종료.".PadLeft(45));
            ConsoleLine();

        }

        static void SelectEffect(string[] powerUp)
        {
            Shuffle(powerUp); // 7월 10일 강의때 배운 셔플을 활용해 서로 다른 무작위 스탯 생성

            string power1 = powerUp[0];
            string power2 = powerUp[1];
            string power3 = powerUp[2];

            string stat1 = StatRandom();
            string stat2 = StatRandom();
            string stat3 = StatRandom();

            string[] box1 = SelectBox(power1, stat1);
            string[] box2 = SelectBox(power2, stat2);
            string[] box3 = SelectBox(power3, stat3);

            ConsoleColor color1 = GetStatColor(power1);
            ConsoleColor color2 = GetStatColor(power2);
            ConsoleColor color3 = GetStatColor(power3);

            BoxColor(box1, box2, box3, color1, color2, color3);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // ReadKey()안에 true를 넣으면 콘솔창에 넘패드를 누른 숫자가 나타나지 않는다고 함!

                switch (keyInfo.Key)
                {
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        ConsoleLine();
                        Console.WriteLine("1번을 선택했습니다!".PadLeft(45));
                        ConsoleLine();
                        BoxColor(box1, box2, box3, color1, GetStatColor(""), GetStatColor(""));
                        break;
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        ConsoleLine();
                        Console.WriteLine("2번을 선택했습니다!".PadLeft(45));
                        ConsoleLine();
                        BoxColor(box1, box2, box3, GetStatColor(""), color2, GetStatColor(""));
                        break;
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        ConsoleLine();
                        Console.WriteLine("3번을 선택했습니다!".PadLeft(45));
                        ConsoleLine();
                        BoxColor(box1, box2, box3, GetStatColor(""), GetStatColor(""), color3);
                        break;
                    default:
                        continue;
                }

                break;
            }

        }

        static void ConsoleLine()
        {
            Console.WriteLine("=====================================================================================");
        }

        static string[] SelectBox(string statName, string statValue)
        {
            string[] lines = new string[12];

            string paddedName = statName.PadLeft(8).PadRight(12); // 모든 statName을 3글자로 맞춰서 PadLeft(8)을 하면 좌측 공백 5개, PadRight(12)를 하면 statName.PadLeft(8)이 8칸이므로 오른쪽 공백이 4개, lines[4]번 {paddedName} 좌공백 3, 우공백 5 이므로 네모 박스 중앙에 위치함!!
            string paddedValue = $"+ {statValue}".PadLeft(8).PadRight(13); // 위에 설정처럼 중앙에 맞추도록 수치 설정! 

            lines[0] =  "┌───────────────────┐"; // 21칸
            lines[1] =  "│                   │";
            lines[2] =  "│                   │";
            lines[3] =  "│                   │";
            lines[4] = $"│   {paddedName}    │";
            lines[5] =  "│                   │";
            lines[6] =  "│                   │";
            lines[7] = $"│   {paddedValue}   │";
            lines[8] =  "│                   │";
            lines[9] =  "│                   │";
            lines[10] = "│                   │";
            lines[11] = "└───────────────────┘";

            return lines;
        }

        /* 기존에 이 방식을 사용하려고 헀지만, 따로 활용할 방법이 제한적이고 가시성이 떨어져 보여서 위의 방식을 채택함
        
        static void SelectEffect(string[] powerUp, int powerRandom)
        {


            Console.Write("┌───────────────────┐  "); Console.Write("┌───────────────────┐  "); Console.WriteLine("┌───────────────────┐");
            Console.Write("│                   │  "); Console.Write("│                   │  "); Console.WriteLine("│                   │");
            Console.Write("│                   │  "); Console.Write("│                   │  "); Console.WriteLine("│                   │");
            Console.Write("│        "); RandomConsole(powerUp, powerRandom); Console.Write("        │  "); Console.Write("│        "); RandomConsole(powerUp, powerRandom); Console.Write("        │  "); Console.Write("│        "); RandomConsole(powerUp, powerRandom); Console.WriteLine("        │");
            Console.Write("│                   │  "); Console.Write("│                   │  "); Console.WriteLine("│                   │");
            Console.Write("│                   │  "); Console.Write("│                   │  "); Console.WriteLine("│                   │");
            Console.Write("│        "); Console.Write(StatRandom()); Console.Write("         │  "); Console.Write("│        "); Console.Write(StatRandom()); Console.Write("         │  "); Console.Write("│        "); Console.Write(StatRandom()); Console.WriteLine("         │");
            Console.Write("│                   │  "); Console.Write("│                   │  "); Console.WriteLine("│                   │");
            Console.Write("│                   │  "); Console.Write("│                   │  "); Console.WriteLine("│                   │");
            Console.Write("└───────────────────┘  "); Console.Write("└───────────────────┘  "); Console.WriteLine("└───────────────────┘");
        }
        */

        static ConsoleColor GetStatColor(string statName)
        {
            switch (statName)
            {
                case "ATK":
                    return ConsoleColor.DarkRed;
                case "DEF":
                    return ConsoleColor.DarkGreen;
                case "H P":
                    return ConsoleColor.Red;
                case "A S":
                    return ConsoleColor.Yellow;
                case "SPD":
                    return ConsoleColor.Cyan;
                default:
                    return ConsoleColor.White;
            }
        }

        static string StatRandom() // 출력할때 PadLeft와 PadRight를 사용하기 위해 미리 string으로 반환
        {
            int statNum = rand.Next(10, 31);

            return statNum.ToString();
        }

        static void Shuffle(string[] array) // 피셔-에이츠 셔플
        {
            for (int i = array.Length - 1; i > 0; i--)
            {

                int j = rand.Next(0, i + 1);

                string temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        static void PrintTextColor(string text, ConsoleColor fontColor)
        {
            ConsoleColor oldFont = Console.ForegroundColor;

            Console.ForegroundColor = fontColor;

            Console.Write(text);

            Console.ForegroundColor = oldFont;

        }

        static void BoxColor(string[] box1, string[] box2, string[] box3, ConsoleColor color1, ConsoleColor color2, ConsoleColor color3)
        {
            for (int i = 0; i < 12; i++)
            {
                PrintTextColor(box1[i], color1);
                Console.Write("   ");

                PrintTextColor(box2[i], color2);
                Console.Write("   ");

                PrintTextColor(box3[i], color3);

                Console.WriteLine();
            }
        }
    }
}


