namespace OOP.Inheritance
{
    internal class Wraith : AirUnit
    {
        // 은신 능력을 가지고 있기 때문에 특성 부여
        private bool isCloaked;

        public Wraith() : base("Wraith", 120, 200, 20, 100)
        {
            isCloaked = false;
            Console.WriteLine("은폐 공중 유닛");
        }

        // 공격 재정의
        public override void Attack()    // 부모 클래스인 AirUnit에 없기때문에 그 위의 부모 클래스인 Unit에서 확인
        {
            Console.WriteLine("레이저 발사");

        }

        public void Cloak()
        {
            if (mp <= 0)
            {
                Console.Write($"{name}은 마나가 부족해 은신할 수 없다.");
                return;
            }

            isCloaked = true;
            mp -= 25;

            Console.WriteLine($"{name}이(가) 은신 상태에 돌입했다");
        }

        public void UnCloak()
        {
            isCloaked = false;
            Console.WriteLine($"{name}이(가) 은신 상태를 해제했다.");
        }
    }
}