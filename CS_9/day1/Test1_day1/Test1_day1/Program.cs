using System.Globalization;

namespace Test1_day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("과제 : 연산자 활용");
            Console.WriteLine();
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("1. 2개의 정수를 입력 받아 사칙연산 + 나머지 결과물 출력");
            Console.WriteLine();
            Test1();
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("2. 3개의 정수를 입력받아 다음 연산의 결과를 출력");
            Console.WriteLine();
            Console.WriteLine("(num1 + num2) * (num3 + num1) % num1 = ?");
            Console.WriteLine("(num3 % num2) + (num1 * 2) = ?");
            Console.WriteLine("(num1 + num2 + num3) % (num3 + 1) = ?");
            Console.WriteLine();
            Test2();
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("3. 입력받은 두 정수를 나누었을 때 얻게 되는 몫과 나머지를 출력");
            Console.WriteLine();
            Test3();
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("4. 몫과 나머지를 이용해 원래 숫자 복원");
            Console.WriteLine();
            Test4();

        }

        static void Test1()
        {
            while (true)
            {
                Console.WriteLine("두 정수를 입력해주세요 (두번째 수는 0이 될 수 없습니다) : ");

                int numA = int.Parse(Console.ReadLine());
                int numB = int.Parse(Console.ReadLine());

                if (numB == 0)
                {
                    Console.WriteLine("두번째 수에 0은 올 수 없습니다. 다시 입력해 주세요.");
                    Console.WriteLine();
                    continue;
                }

                    Console.WriteLine($"({numA}) + ({numB}) = ({numA + numB})");
                Console.WriteLine($"({numA}) - ({numB}) = ({numA - numB})");
                Console.WriteLine($"({numA}) * ({numB}) = ({numA * numB})");
                Console.WriteLine($"({numA}) / ({numB}) = ({numA / numB})");
                Console.WriteLine($"({numA}) % ({numB}) = ({numA % numB})");

                break;
            }

            Console.WriteLine();
        }

        static void Test2()
        {
            while (true)
            {
                Console.WriteLine("0이 아닌 3개의 정수를 입력해주세요. (마지막 수는 -1이 될 수 없습니다)");

                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                int num3 = int.Parse(Console.ReadLine());

                if (num1 == 0 || num2  == 0 || num3 == 0 || num3 == -1)
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.WriteLine();
                    continue;
                }

                int resultA = (num1 + num2) * (num3 + num1) % num1;
                int resultB = (num3 % num2) + (num1 * 2);
                int resultC = (num1 + num2 + num3) % (num3 + 1);


                Console.WriteLine($"(({num1}) + ({num2})) * (({num3}) + ({num1})) % ({num1}) = {resultA}");
                Console.WriteLine($"(({num3}) % ({num2})) + (({num1}) * 2) = {resultB}");
                Console.WriteLine($"(({num1}) + ({num2}) + ({num3})) % (({num3}) + 1) = {resultC}");

                break;
            }

            Console.WriteLine();

        }

        static void Test3()
        {
            while (true)
            {
                Console.WriteLine("두 정수를 입력해주세요 (두번째 수는 0이 될 수 없습니다) : ");

                int numA = int.Parse(Console.ReadLine());
                int numB = int.Parse(Console.ReadLine());

                if (numB == 0)
                {
                    Console.WriteLine("두번째 수에 0은 올 수 없습니다. 다시 입력해 주세요.");
                    Console.WriteLine();
                    continue;
                }

                int quotient = numA / numB;
                int remainder = numA % numB;

                Console.WriteLine($"{numA}를 {numB}로 나누었을 때의 몫은 {quotient}이고 나머지는 {remainder}입니다.");
                Console.WriteLine();

                break;
            }

            Console.WriteLine();

        }

        static void Test4()
        {
            while (true)
            {
                Console.WriteLine("두 정수 numA와 numB를 입력해주세요 (두번째 수는 0이 될 수 없습니다) : ");

                int numA = int.Parse(Console.ReadLine());
                int numB = int.Parse(Console.ReadLine());

                if (numB == 0)
                {
                    Console.WriteLine("두번째 수에 0은 올 수 없습니다. 다시 입력해 주세요.");
                    Console.WriteLine();
                    continue;
                }

                int quotient = numA / numB;
                int remainder = numA % numB;

                int result = numB * quotient + remainder;

                Console.WriteLine($"{numA}를 {numB}로 나누었을 때의 몫은 {quotient}이고 나머지는 {remainder}입니다.");
                Console.WriteLine();
                Console.WriteLine("numA를 구하는 수식 : numB * quotient + remainder");
                Console.WriteLine();
                Console.WriteLine($"기존 numA = {numA}, 수식으로 구해낸 numA = {numB} * {quotient} + {remainder} = {result}");
                break;
            }

            Console.WriteLine();

        }
    }
}
