using System;
using System.Linq;
using System.Diagnostics;

namespace Test1_0708;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("게임은 잘 즐겨주셨나요? 플레이어님의 게임에 대한 점수를 각 항목에 맞게 평가해주세요! (0점 ~ 5점)");
        Console.WriteLine();

        string[] reviewList = { "캐릭터", "배경", "퀘스트", "아이템", "과금", "레이드" };
        int[] reviewScore = new int[reviewList.Length];
        int totalScore = 0;

        for (int i = 0; i < reviewList.Length;)
        {
            Console.Write($"{reviewList[i]} : ");
            string? playerInput = Console.ReadLine();
            
            if (!int.TryParse(playerInput, out int inputScore))
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                Console.WriteLine();
                continue;
            }
            reviewScore[i] = inputScore;
            if (reviewScore[i] < 0 || reviewScore[i] > 5)
            {
                Console.WriteLine("잘못된 입력입니다. 0 ~ 5 사이의 숫자를 입력해주세요.");
                Console.WriteLine();
                continue;
            }

            totalScore += reviewScore[i];
            i++;
        }

        Console.WriteLine();

        int averageScore = totalScore / reviewList.Length;
        Console.WriteLine("최종 점수표");
        for (int i = 0; i < reviewList.Length; i++)
        {
            Console.WriteLine($"{reviewList[i]} : {reviewScore[i]}");
        }
        Console.Write($"점수 총합 : {totalScore}, 점수 평균 : {averageScore}, 최종 결과 : ");
        ReviewRecommend(averageScore);
    }

    static void ReviewRecommend(int averageScore)
    {
        switch (averageScore)
        {
            case 0:
            case 1:
                Console.WriteLine("[비추천]");
                break;
            case 2:
            case 3:
                Console.WriteLine("[추천]");
                break;
            default:
                Console.WriteLine("[강력 추천]");
                break;
        }
    }
}
