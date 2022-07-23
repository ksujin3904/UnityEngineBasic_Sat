using System;

// Method < Fuction
// 객체를 통해서 호출하는 함수를 Method 라고함

namespace Method
{
    internal class Program
    {
        //멤버 함수
        // 클래스 내에 정의된 함수

        static void Main(string[] args)
        {

            // 함수호출
            // 함수이름(인자, 인자);
            // 인자: 매개변수에 넣어줄 값
            PrintHelloWorld();
            PrintString("안녕");
            int num = PrintStringWithReturnLength("안녕못해");
        }
        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World");
        }

        static void PrintString(String target)
        {
            Console.WriteLine(target);
        }

        static int PrintStringWithReturnLength(String target)
        {
            // 지역변수
            int tmpLenght = target.Length;
            Console.WriteLine(target);
            return tmpLenght;
        }
    }
}
