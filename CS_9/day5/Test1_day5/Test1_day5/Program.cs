using System.Collections.Specialized;
using System.Drawing;

namespace Test1_day5
{
    internal class Program
    {
        static Random rand = new Random(); // 클래스 내부에 Random rand를 전역으로 사용하여 main뿐만 아니라 모든 함수에서 굳이 따로 선언할 필요를 없앰
        static void Main(string[] args)
        {
            string[] powerUp = { "ATK", "DEF", "H P", "A S", "SPD" }; // ATK : 공격력, DEF : 방어력, HP : 체력, AS : 공격속도, SPD : 이동속도


            while (true)
            {
                

                Console.Write("임시 레벨업(치트) 아무키나 눌러주세요!");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("레벨업을 하였습니다. 강화를 선택해주세요!");

                SelectEffect(powerUp);

                Console.WriteLine();
                

            }
            

            
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

            ConsoleColor color1 = GetStatColor(stat1);
            ConsoleColor color2 = GetStatColor(stat2);
            ConsoleColor color3 = GetStatColor(stat3);

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

        static string[] SelectBox(string statName, string statValue)
        {
            string[] lines = new string[12];

            string paddedName = statName.PadLeft(8).PadRight(15); 
            string paddedValue = $"+{statValue}".PadLeft(9).PadRight(15);

            lines[0] = "┌───────────────────┐";
            lines[1] = "│                   │";
            lines[2] = "│                   │";
            lines[3] = "│                   │";
            lines[4] = $"│   {paddedName} │";
            lines[5] = "│                   │";
            lines[6] = "│                   │";
            lines[7] = $"│  {paddedValue}  │";
            lines[8] = "│                   │";
            lines[9] = "│                   │";
            lines[10] = "│                   │";
            lines[11] = "└───────────────────┘";

            return lines;
        }

        static ConsoleColor GetStatColor(string statName)
        {
            switch (statName)
            {
                case "ATK":
                    return ConsoleColor.Red;
                case "DEF":
                    return ConsoleColor.Cyan;
                case "H P":
                    return ConsoleColor.Green;
                case "A S":
                    return ConsoleColor.Yellow;
                case "SPD":
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.White;
            }
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

        static void RandomConsole(string[] powerUp, int selectRandom)
        {
            switch (selectRandom)
            {
                case 0:
                    Console.Write(powerUp[selectRandom]);
                    break;
                case 1:
                    Console.Write(powerUp[selectRandom]);
                    break;
                case 2:
                    Console.Write(powerUp[selectRandom]);
                    break;
                case 3:
                    Console.Write(powerUp[selectRandom]);
                    break;
                case 4:
                    Console.Write(powerUp[selectRandom]);
                    break;
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

        static void PrintTextColor(string text, ConsoleColor fontColor) // 텍스트 색상 적용
        {
            // 기존 색상 저장
            ConsoleColor oldFont = Console.ForegroundColor;
            // ConsoleColor oldBackGround = Console.BackgroundColor;

            // 새 색상 적용
            Console.ForegroundColor = fontColor;
            // Console.BackgroundColor = backgroundColor;

            // 출력
            Console.Write(text);

            // 색상 복원
            Console.ForegroundColor = oldFont;
            // Console.BackgroundColor = oldBackGround;

        }
    }
}


