namespace OOP.Inheritance
{
    internal class Scout : AirUnit
    {
        public Scout() : base("스카웃", 80, 120, 40, 100)
        {
            Console.WriteLine("정찰용 공중 유닛");
        }

        public override void Attack()
        {
            Console.WriteLine("펄스 캐논 발사");
        }

        // 클래스 별로 새 항목을 만들어야 한다..?
        //  ㄴ 1. 묶을 수 있는건 전부 묶는다. (구체화 / 추상적 개념도 묶어 준다.) ↔ 객체"지향"이니 대부분의 것을 객체로 만든다.

    }
}