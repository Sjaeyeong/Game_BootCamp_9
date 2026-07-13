using System;
using System.Linq;
using System.Collections.Generic;

namespace HelloWold;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("무기의 이름과 공격력을 설정해주세요.");
        Console.WriteLine();

        Console.Write("무기 이름 : ");
        string? weaponName = Console.ReadLine();
        int weaponDamage = 0;

        while (true)
        {
            Console.Write("무기 공격력 : ");
            string? playerInput = Console.ReadLine();
            

            if (!int.TryParse(playerInput, out weaponDamage))
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해 주세요");
                continue;
            }

            break;
        }
        

        Console.WriteLine($"무기의 이름은 {weaponName}이고 무기의 공격력은 {weaponDamage}입니다");
        Console.WriteLine("이제 강화를 시작합니다. 총 5회 강화합니다.");
        Console.WriteLine();

        int upgradePoint = 0;
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            int rand = random.Next(1, 101);
            Console.WriteLine($"강화를 시작합니다. {i + 1}번째 시도");

            if (rand < 11) // 대성공 10%
            {
                Console.WriteLine("대성공입니다! 공격력 +5");
                weaponDamage += 5;
                upgradePoint += 1;
            }
            else if (rand < 71) // 성공 60%
            {
                Console.WriteLine("성공입니다. 공격력 +1");
                weaponDamage += 1;
                upgradePoint += 1;
            }
            else // 실패 30%
            {
                Console.Write("실패입니다.. ");

                if (weaponDamage < 1)
                {
                    Console.WriteLine("공격력 0");
                }
                else
                {
                    Console.WriteLine("공격력 -1");
                    weaponDamage -= 1;
                }

                if (upgradePoint < 1)
                {
                }
                else
                {
                    upgradePoint -= 1;
                }
            }

            Console.WriteLine($"현재 무기 공격력 : {weaponDamage}, 강화수치 : {upgradePoint}강");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("최종 결과물");
        Console.WriteLine($"{weaponName}의 총 공격력 : {weaponDamage}, 총 강화수치 : {upgradePoint}");
    }
}