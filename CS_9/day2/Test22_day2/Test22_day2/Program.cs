using System;
using System.Linq;

namespace Test2;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("캐릭터 뽑기샵에 오신것을 환영합니다. 총 5번 뽑기를 진행합니다.");
        Console.WriteLine();

        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            int rand = random.Next(1, 101);
            Console.WriteLine($"{i + 1}번째 뽑기를 진행합니다.");

            if (rand < 6) // 전설 5%
            {
                LegendaryPet();
            }
            else if (rand < 16) // 에픽 10%
            {
                EpicPet();
            }
            else if (rand < 41) // 레어 25%
            {
                RarePet();
            }
            else // 일반 60%
            {
                CommonPet();
            }

            Console.WriteLine();
        }
    }

    static void LegendaryPet()
    {
        string pet1 = "그 누구도 쫒아갈 수 없는 검성";
        string pet2 = "그 누구도 얼굴을 본적없는 어쌔신";
        string petName = "";

        int atk1 = 150;
        int atk2 = 200;
        int def1 = 150;
        int def2 = 80;
        int petAtk = 0;
        int petDef = 0;

        Random randomPet = new Random();
        int petNum = randomPet.Next(1, 3);

        switch (petNum)
        {
            case 1:
                petName = pet1;
                petAtk = atk1;
                petDef = def1;
                break;
            case 2:
                petName = pet2;
                petAtk = atk2;
                petDef = def2;
                break;
        }

        Console.WriteLine($"축하드립니다! 레전더리등급 캐릭터 [{petName}]를 뽑았습니다!");
        Console.WriteLine($"[☆☆☆☆]공격력 : {petAtk}, 방어력 : {petDef}");
    }

    static void EpicPet()
    {
        string pet1 = "겁이없는 버서커";
        string pet2 = "정의감을 불태우는 성기사";
        string petName = "";

        int atk1 = 100;
        int atk2 = 60;
        int def1 = 30;
        int def2 = 70;
        int petAtk = 0;
        int petDef = 0;

        Random randomPet = new Random();
        int petNum = randomPet.Next(1, 3);

        switch (petNum)
        {
            case 1:
                petName = pet1;
                petAtk = atk1;
                petDef = def1;
                break;
            case 2:
                petName = pet2;
                petAtk = atk2;
                petDef = def2;
                break;
        }

        Console.WriteLine($"축하드립니다! 에픽등급 캐릭터 [{petName}]를 뽑았습니다!");
        Console.WriteLine($"[☆☆☆]공격력 : {petAtk}, 방어력 : {petDef}");
    }

    static void RarePet()
    {
        string pet1 = "밥을 든든하게 먹은 모험가";
        string pet2 = "산꼭대기 저격수";
        string petName = "";

        int atk1 = 30;
        int atk2 = 60;
        int def1 = 50;
        int def2 = 10;
        int petAtk = 0;
        int petDef = 0;

        Random randomPet = new Random();
        int petNum = randomPet.Next(1, 3);

        switch (petNum)
        {
            case 1:
                petName = pet1;
                petAtk = atk1;
                petDef = def1;
                break;
            case 2:
                petName = pet2;
                petAtk = atk2;
                petDef = def2;
                break;
        }

        Console.WriteLine($"축하드립니다! 레어등급 캐릭터 [{petName}]를 뽑았습니다!");
        Console.WriteLine($"[☆☆]공격력 : {petAtk}, 방어력 : {petDef}");
    }

    static void CommonPet()
    {
        string pet1 = "초보 모험가";
        string pet2 = "겁에 질린 방패";
        string petName = "";

        int atk1 = 20;
        int atk2 = 5;
        int def1 = 20;
        int def2 = 40;
        int petAtk = 0;
        int petDef = 0;

        Random randomPet = new Random();
        int petNum = randomPet.Next(1, 3);

        switch (petNum)
        {
            case 1:
                petName = pet1;
                petAtk = atk1;
                petDef = def1;
                break;
            case 2:
                petName = pet2;
                petAtk = atk2;
                petDef = def2;
                break;
        }

        Console.WriteLine($"축하드립니다! 일반등급 캐릭터 [{petName}]를 뽑았습니다!");
        Console.WriteLine($"[☆]공격력 : {petAtk}, 방어력 : {petDef}");
    }
}