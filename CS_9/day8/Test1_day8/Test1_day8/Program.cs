namespace Test1_day8
{
    internal class Program
    {
        enum SpawnArea : byte       // 스폰지역을 열거형으로 정리
        {
            None = 0,
            Dungeon,
            Plains,
            Desert,
            Swamp,
            Cave,
            Ocean
        }

        enum DangerLevel : byte     // 위험도를 열거형으로 정리
        {
            None = 0,
            Peaceful,
            Easy,
            Normal,
            Hard,
            Hell
        }


        class Monster
        {
            private string _name;
            private SpawnArea _spawnArea;
            private DangerLevel _dangerLevel;
            private string _monsterInfo;

            public Monster(string name, SpawnArea spawnArea, DangerLevel dangerLevel, string monsterInfo)
            {
                _name = name;
                _spawnArea = spawnArea;
                _dangerLevel = dangerLevel;
                _monsterInfo = monsterInfo;
            }

            public void PrintInfo(int num)
            {
                Console.WriteLine($"No.{num + 1} 몬스터 입니다");
                Console.WriteLine($"몬스터 이름 : {_name}");
                Console.WriteLine($"몬스터 등장 지역 : {_spawnArea}");
                Console.WriteLine($"몬스터 위험도 : {_dangerLevel}");
                Console.WriteLine($"몬스터 설명 : {_monsterInfo}");
                PrintLine();
            }
        }


        static void Main(string[] args)
        {
            Monster[] monsters = StoreData();

            PrintLine();
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].PrintInfo(i);
            }
        }

        static Monster[] StoreData()        // 함수를 통해 Monster클래스 배열을 초기화시킴
        {
            Monster[] monsters = new Monster[]
            {
                new Monster
                (
                    "슬라임",
                    SpawnArea.Dungeon,
                    DangerLevel.Peaceful,
                    "물컹거린다"
                ),
                new Monster
                (
                    "좀비",
                    SpawnArea.Plains,
                    DangerLevel.Normal,
                    "느리지만 끝까지 쫓아온다"
                ),
                new Monster
                (
                    "선인장 괴물",
                    SpawnArea.Desert,
                    DangerLevel.Easy,
                    "가까이 가면 찔릴 수 있다"
                ),
                new Monster
                (
                    "크로커다일",
                    SpawnArea.Swamp,
                    DangerLevel.Hard,
                    "턱힘이 강하니 물리지 않도록 조심하자"
                ),
                new Monster
                (
                    "거대 박쥐",
                    SpawnArea.Cave,
                    DangerLevel.Hell,
                    "초음파 공격을 조심하자"
                ),
                new Monster
                (
                    "죠습니다",
                    SpawnArea.Ocean,
                    DangerLevel.Hell,
                    "정말 죠습니다"
                )

            };

            return monsters;
            
        }

        static void PrintLine()
        {
            Console.WriteLine("--------------------------------------------------");
        }

    }
}
