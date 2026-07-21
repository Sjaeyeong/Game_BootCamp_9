using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class GameManager
    {
        private Player _player;
        private Monster _monster;
        public int round = 1;
        private GameState _state;
        private int _frameCount;

        private static Random rand = new Random();

        public void Play()
        {
            while (_state != GameState.GameOver)        // 0.5초마다 화면 변경
            {






                Thread.Sleep(500);
            }

        }

        public void LevelUpSelectPlzzzz()                   // 레벨업시 선택지 출력
        {

        }

        public void GameEnd()                   // 플레이어의 체력이 0보다 작아지면 게임 종료
        {

        }

        #region 4일차 과제활용 부분 (렙업시 선택창 뜨는 로직)

        static void ConsoleLine()
        {
            Console.WriteLine("=====================================================================================");
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

        static string[] SelectBox(string statName, string statValue)            // 레벨업시 뜨는 선택장
        {
            string[] lines = new string[12];

            string paddedName = statName.PadLeft(8).PadRight(12);
            string paddedValue = $"+ {statValue}".PadLeft(8).PadRight(13);

            lines[0] = "┌───────────────────┐";
            lines[1] = "│                   │";
            lines[2] = "│                   │";
            lines[3] = "│                   │";
            lines[4] = $"│   {paddedName}    │";
            lines[5] = "│                   │";
            lines[6] = "│                   │";
            lines[7] = $"│   {paddedValue}   │";
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

        static void Shuffle(string[] array)
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

        #endregion

    }




}

