namespace Test1_day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            
            int[] comArray = new int[3];
            int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] playerArray = new int[3];

            int comTotal = 0;
            int playerTotal = 0;

            

            Console.WriteLine("업다운 게임을 시작하겠습니다!");
            Console.WriteLine();

            Shuffle(number, rand); // 1 ~ 10인 number 배열의 순서를 섞어 앞의 3개의 인덱스를 comArray에 넣어줌

            for (int i = 0; i < comArray.Length; i++)
            {
                comArray[i] = number[i];
                comTotal += comArray[i];
            }

            while (true)
            {
                Console.WriteLine("서로 다른 숫자 3개를 입력해주세요!");
                Console.WriteLine();

                for (int i = 0; i < playerArray.Length; )
                {
                    Console.Write($"{i + 1}번째 숫자를 입력해주세요 : ");
                    string? playerInput = Console.ReadLine()!;

                    if (playerInput == "치트")
                    {
                        CheatShow(comArray, number);
                        Console.WriteLine($"컴퓨터의 총합은 : {comTotal}");
                        continue;
                    }

                    if (!int.TryParse(playerInput, out playerArray[i]))
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시입력해주세요!");
                        continue;
                    }

                    i++;
                }

                playerTotal = 0;
                for (int i = 0; i < playerArray.Length; i++)
                {
                    playerTotal += playerArray[i];
                }

                Console.WriteLine();
                Console.WriteLine($"입력한 수의 총합 : {playerTotal}");
                Console.Write("결과는 ");

                if (playerTotal < comTotal)
                {
                    Console.WriteLine("UP!");
                    Console.WriteLine();
                }
                else if (playerTotal > comTotal)
                {
                    Console.WriteLine("DOWN!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("축하합니다! 정답입니다!");
                    break;
                }

                Console.WriteLine();
            }
            
        }


        static void Shuffle(int[] array, Random rand) // 배열 셔플 함수
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);

                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        static void CheatShow(int[] comArray, int[] number)
        {
            for (int i = 0; i < comArray.Length; i++)
            {
                comArray[i] = number[i];
                Console.Write($"{comArray[i]} ");
            }

            Console.WriteLine();
        }

        static void DivideLine()
        {
            Console.WriteLine("======================================");
        }

        static void PrintTextColor(string text, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            ConsoleColor oldFont = Console.ForegroundColor;
            ConsoleColor oldBackGround = Console.BackgroundColor;

            Console.ForegroundColor = fontColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(text);

            Console.ForegroundColor = oldFont;
            Console.BackgroundColor = oldBackGround;

        }
    }
}
