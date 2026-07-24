#region C# 상속 구조
/*
▶ 다중 상속 

- C#은 하나의 클래스 상속 + 인터페이스 구현을 원칙으로 한다.
 ㄴ 다중 상속이 안된다!


● 다중 상속

- 다중 상속이란 둘 이상의 클래스를 동시에 상속하는 것을 말한다.

- goto → 보통 득보다 실이 크다.
 ㄴ 기본적으로 스파게티 코드에 일조한다.

- 구조상 다이아몬드 구조를 대부분 만들어서 서로 참조간 안전성이 보장되지 않는다.




*/
#endregion


namespace OOP.Inheritance
{
    internal class MainGame
    {
        // 관리자 성향 (XX Manager)
        // 인풋이나 입력 키 관련 관리자 → KeyManager
        // 사운드 관련 관리자 → SoundManager
        // 유닛을 직접 제어하지 않고 흐름만 관리
        public static void ExampleFunction()
        {
            ConsolePrint.Section("전장 입장");

            Console.WriteLine("단일 유닛 생성");
            ConsolePrit.Line();

            // 된다.
            // 스택 → 힙으로 넣어주고 있음
            // 정찰용 공중
            Scout scout = new Scout();
            // 은폐용 공중
            Wraith wraith = new Wraith();

            ConsolePrint.Line();

            Console.WriteLine("== 초기 상태 ==");
            scout.PrintStatus();
            wraith.PrintStatus();

            ConsolePrint.Line();

            Console.WriteLine("== 이동 ==");
            scout.Move();
            wraith.Move();

            ConsolePrint.Line();

            Console.WriteLine("== 공격 ==");
            scout.Attack();
            wraith.Attack();

            ConsolePrint.Line();

            Console.WriteLine("== 스카웃 격추 ==");
            scout.Kill();
            scout.PrintStatus();

            ConsolePrint.Line();

            // 상속.. 이놈.. 이렇게 보니 잘 쓰면 매우 유용할것 같은데..?
            // 위에 보다 조금 더 효율적으로..

            ConsolePrint.Section("편대 구성");
            ConsolePrint.Line();

            Unit[] airUnits =
            {
                new Scout(),        // 정찰용 공중 유닛
                new Wraith(),       // 은폐 공중 유닛
                new Wraith()        // 은폐 공중 유닛
            };

            ConsolePrint.Line();

            Console.WriteLine("== 편대 행동 개시 ==");

            // 순회 목적이기 때문에 foreach사용
            foreach(Unit unit in airUnits)
            {
                unit.Move();            // 공통 동작
                unit.Attack();          // 공격 (다형성)
                unit.PrintStatus();     // 상태 출력
                ConsolePrint.Line();
            }

            // --------------------------

            //// 클래스는 값? 참조? 참조이다
            //// 여기서는 확인이 안된다
            //Unit[] units = new Unit[2];
            //units[0] = new Scout();
            //units[1] = new Wraith();
            //units[2] = new Wraith();        // 배열갯수는 2개인데 3번째가 들어가서 오류가 남

            //for (int i = 0; i < units.Length; i++)
            //{
            //    units[i].Attack();
            //}



        }



    }
}