using System;

namespace Statement_if
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool condition1 = true;
            bool condition2 = false;
            bool condition3 = false;

            /* <if문 형식>
             if (조건)
                {
                    조건이 참일 때 실행할 내용
                }             
             */
            
            if (condition1)
            {
                Console.WriteLine("조건1이 참");
            }
            else if (condition2)
            {
                Console.WriteLine("조건1이 거짓이면서 조건2가 참");
            }
            else if (condition3)
            {
                Console.WriteLine("조건1,2가 거짓이면서 조건3이 참");
            }
            else
            {
                Console.WriteLine("조건1,2,3 모두 거짓");
            }
        }
    }
}
