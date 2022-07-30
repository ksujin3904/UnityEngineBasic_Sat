using System;

namespace Statement_Loops
{
    internal class Program
    {
        static int i;
        static void Main(string[] args)
        {
            /*
              < 반복문 >
            */
            int[] tmpArr = { 1, 2, 3, 4, 5 };
            
            // 1. while문
            int count = 0;
            while (count < tmpArr.Length)
            {
                Console.WriteLine(tmpArr[count]);
                count++;
            }

            // 2. do~while
            //do
            //{
            //    Console.WriteLine(tmpArr[count]);
            //    count++;
            //
            //} while (count < tmpArr.Length);
            // 조건 확인 전에 1회 선실행

            // 3. break: 상위 반복문을 빠져나오는 분기문

            while (count < tmpArr.Length)
            {
                if (count == 3)
                {
                    break;
                }

                Console.WriteLine("1"+tmpArr[count]);
                count++;
                                
            }

            // 4. continue: 상위 반복문의 조건비교문으로 돌아가는 분기문
            while (count < tmpArr.Length)
            {
                if (count == 3)
                {
                    count++;
                    continue;
                }

                Console.WriteLine("2"+tmpArr[count]);
                count++;

            }

            // 5. return: 해당 함수 반환
            while (count < tmpArr.Length)
            {
                if (count == 3)
                    return;

                Console.WriteLine("3"+tmpArr[count]);
                count++;

            }

            // 5. for 문
            for (count = 0; count<tmpArr.Length; count++)
            {
                Console.WriteLine(tmpArr[count]);
            }

            int[,] mat2D = new int[3, 5]
            {
                { 1, 2, 3, 4, 5 },
                { 4, 5, 6 ,7 ,8 },
                { 5, 6, 7, 8, 4 }
            };

            for (int i = 0; i< mat2D.GetLength(0); i++)
            {
                for(int j = 0; j< mat2D.GetLength(1); j++)
                {
                    Console.Write(mat2D[i, j]+",");
                }
                Console.WriteLine();
            }

        }
    }
}
