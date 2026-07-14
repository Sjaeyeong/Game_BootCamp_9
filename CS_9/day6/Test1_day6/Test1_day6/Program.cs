using System;

namespace Test1_day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintLine();
            Console.WriteLine();
            Console.WriteLine("과제 C# 문자열 활용\n");

            PrintLine();
            Console.WriteLine("A. 문자열을 입력받아 거꾸로 출력, B. 문자열을 입력받아 짝수번째만 순서를 거꾸로 출력\n");
            Test_1_2();
            Console.WriteLine();

            PrintLine();
            Console.WriteLine("C. 문자열과 문자 하나를 입력받아 문자열 안에 해당 문자가 몇개 있는지 출력\n");
            Test_3();
            Console.WriteLine();

            PrintLine();
            Console.WriteLine("D. 문자열을 입력받아 숫자만 추출하여 출력\n");
            Test_4();
            Console.WriteLine();

            PrintLine();
            Console.WriteLine("E. 문자열과 제거할 문자 하나를 입력받아 해당 문자를 제거한 결과를 출력\n");
            Test_5();
            Console.WriteLine();

            PrintLine();
            Console.WriteLine("F. 맛보기 도전 → 부분 문자열 직접 찾기\n");
            Test_6();
            Console.WriteLine();

            PrintLine();
            Console.WriteLine("G. 가상의 주민번호를 입력받아 '-' 를 제거한 결과를 출력한다.\n");
            Test_7();
            Console.WriteLine();



        }

        static void PrintLine()
        {
            Console.WriteLine("=================================================================================================");
        }

        static void PrintArray(char[] c, int num)
        {
            Console.Write($"{num}. 출력된 문자열 : ");
            for (int i = 0; i < c.Length; i++)
            {
                Console.Write(c[i]);
            }
        }

        static void Test_1_2()
        {
            Console.Write("문자열을 입력해 주세요. : ");
            string inputA = Console.ReadLine()!;
            char[] charA = inputA.ToCharArray(); // ToCharArray()를 활용하여 문자열의 모든 문자를 char[] 배열로 변환
            char[] charB = inputA.ToCharArray();

            for (int i = 0; i < charA.Length / 2; i++)
            {   // 튜플 스왑 활용
                (charA[i], charA[charA.Length - 1 - i]) = (charA[charA.Length - 1 - i], charA[i]);
            }

            for (int i = 1; i < charB.Length / 2; i += 2)
            {   // 배열인덱스 1번 (짝수인 2번째부터)과 배열의 짝수번쨰의 끝이랑 튜플 스왑 - 짝수번째인덱스를 뒤에서 부터 구하는 식 =charB.Length - i - charB.Length%2 --- 짝수일 경우 0을 빼고 홀수일 경우 1을 빼주기
                (charB[i], charB[charB.Length - i - charB.Length % 2]) = (charB[charB.Length - i - charB.Length % 2], charB[i]);
            }

            Console.WriteLine();
            PrintArray(charA, 1);
            Console.WriteLine();
            PrintArray(charB, 2);
            Console.WriteLine();

        }

        static void Test_3()
        {
            Console.Write("문자열을 입력해 주세요. : ");
            string inputC = Console.ReadLine()!;
            char[] charC = inputC.ToCharArray();
            char c;
            int num = 0;
            Console.WriteLine();

            while (true)
            {
                Console.Write("문자 하나를 입력해 주세요. : ");
                string cInput = Console.ReadLine()!;
                if (cInput.Length != 1)
                {
                    Console.WriteLine("잘못된 입력입니다. 문자 하나만 입력해주세요.");
                    Console.WriteLine();
                    continue;
                }
                c = cInput[0];
                break;
            }

            for (int i = 0; i < charC.Length; i++)
            {
                if (charC[i] == c) num += 1;
            }

            Console.WriteLine();
            PrintArray(charC, 3);
            Console.WriteLine($" → 문자 : {c}, 숫자 : {num}");
            Console.WriteLine();
        }

        static void Test_4()
        {
            Console.Write("문자열을 입력해 주세요. : ");
            string inputD = Console.ReadLine()!;
            char[] charD = inputD.ToCharArray();
            char[] resultD = new char[charD.Length];

            for (int i = 0; i < charD.Length; i++)
            {
                if (charD[i] >= 48 && charD[i] <= 57)
                {
                    resultD[i] = charD[i];
                }
            }

            Console.WriteLine();
            PrintArray(resultD, 4);
            Console.WriteLine();

        }

        static void Test_5()
        {
            Console.Write("문자열을 입력해 주세요. : ");
            string inputE = Console.ReadLine()!;
            char[] charE = inputE.ToCharArray();
            char e;

            while (true)
            {
                Console.Write("문자 하나를 입력해 주세요. : ");
                string eInput = Console.ReadLine()!;
                if (eInput.Length != 1)
                {
                    Console.WriteLine("잘못된 입력입니다. 문자 하나만 입력해주세요.");
                    Console.WriteLine();
                    continue;
                }
                e = eInput[0];
                break;
            }

            Console.WriteLine();
            Console.Write($"5. 출력된 문자열 : ");
            for (int i = 0; i < charE.Length; i++)
            {
                if (charE[i] != e)
                {
                    Console.Write(charE[i]);
                }
            }
            Console.WriteLine();

        }

        static void Test_6()
        {
            Console.Write("문자열을 입력해 주세요. : ");
            string inputF = Console.ReadLine()!;
            char[] firstF = inputF.ToCharArray();
            Console.Write("찾을 문자열을 입력해 주세요. : ");
            string findF = Console.ReadLine()!;
            char[] secondF = findF.ToCharArray();

            Console.Write("출력 : ");
            bool isFirst = true;

            for (int i = 0; i <= firstF.Length - secondF.Length; i++)
            {
                bool isCorrect = true;

                for (int j = 0; j < secondF.Length; j++)
                {
                    if (firstF[i + j] != secondF[j])
                    {
                        isCorrect = false;
                        break;
                    }
                }

                if (isCorrect)
                {
                    if (!isFirst)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(i);
                    isFirst = false;
                }
            }
            Console.WriteLine();

        }

        static void Test_7()
        {
            Console.Write("주민번호를 입력해주세요. (Ex: 123456-1234567) : ");
            string inputG = Console.ReadLine()!;
            char[] charG = inputG.ToCharArray();

            string result = "";

            for (int i = 0; i < charG.Length; i++)
            {
                if (charG[i] != '-')
                {
                    result += charG[i];
                }
            }

            Console.WriteLine($"출력 : {result}");

        }
            
    }
}
