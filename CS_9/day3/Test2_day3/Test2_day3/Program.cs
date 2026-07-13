using System;
using System.Linq;

namespace Test2_0708;

public static class Program
{
    public static void Main()
    {
        int[] comNum = new int[3];
        int[] playerNum = new int[3];
        int count = 1;
        Random rand = new Random();

        while (true)
        {
            for (int i = 0; i < comNum.Length;)
            {
                int comRand = rand.Next(0, 10);
                comNum[i] = comRand;
                i++;
            }

            if (comNum[0] == comNum[1] || comNum[0] == comNum[2] || comNum[1] == comNum[2])
            {
                continue;
            }

            break;
        }


        Console.WriteLine("숫자야구게임을 시작합니다. 3개의 정수를 입력해 컴퓨터를 이겨보세요!");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine($"치트 : {comNum[0]} {comNum[1]} {comNum[2]}");
            Console.WriteLine($"{count}회시도 3개의 정수를 순서대로 입력해주세요!");
            for (int i = 0; i < playerNum.Length;)
            {
                Console.Write($"{i + 1}번째 정수를 입력해주세요. : ");
                string? playerInput = Console.ReadLine();

                if (!int.TryParse(playerInput, out int inputNum))
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.WriteLine();
                    continue;
                }

                playerNum[i] = inputNum;

                if ((i > 0 && (playerNum[i] == playerNum[i - 1])) || (i > 1 && (playerNum[i] == playerNum[i - 2])))
                {
                    Console.WriteLine("기존에 입력한 수와 같은 수를 입력할 수 없습니다. 다시 입력해주세요.");
                    continue;
                }

                i++;
            }

            Console.WriteLine();
            Console.WriteLine($"현재 입력하신 숫자 : {playerNum[0]} {playerNum[1]} {playerNum[2]}");
            if (Numbaseball(comNum, playerNum) == 3)
            {
                break;
            }

            count += 1;

        }

        Console.WriteLine("축하드립니다! 승리하였습니다!");
        Console.WriteLine($"총 시도한 횟수 : {count}");
    }

    static int Numbaseball(int[] comNum, int[] playerNum)
    {
        int strike = 0;
        int ball = 0;
        int outBall = 0;

        for (int i = 0; i < comNum.Length; i++)
        {
            if (comNum[i] == playerNum[i])
            {
                strike += 1;
            }
            else if (playerNum[0] == comNum[i] || playerNum[1] == comNum[i] || playerNum[2] == comNum[i])
            {
                ball += 1;
            }
        }

        if (strike == 0 && ball == 0)
        {
            outBall += 1;
        }

        Console.WriteLine($"결과 : [{strike}]S | [{ball}]B | [{outBall}]O");
        Console.WriteLine();

        return strike;
    }
}
