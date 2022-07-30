using System;

namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int a = 14;
            int b = 6;
            int c = 0;

 

            /*
            * 산술 연산자: 더하기, 빼기, 곱하기, 나누기, 나머지
            */

            // 더하기
            c = a + b;
            Console.WriteLine(c);

            // 빼기
            c = a - b;
            Console.WriteLine(c);

            // 곱하기
            c = a * b;
            Console.WriteLine(c);

            // 나누기
            c = a / b;
            Console.WriteLine(c);
            // 정수 나눗셈은 소수점을 버린 정수를 반환

            //나머지
            c = a % b;
            Console.WriteLine(c);
            // 자료형에 관계없이 정수 나눗셈 후 나머지 결과를 반환

            // <증감연산자>
            // 증가 연산자, 감소 연산자
            // 증가 연산
            ++c; // 전위연산자: 연산을 먼저 수행한 뒤 명령 실행
            c++; // 후위연산자: 명령 실행 후 연산 수행

            c = 0;
            Console.WriteLine(c);   // 결과: 0
            Console.WriteLine(++c); // 결과: 1
            Console.WriteLine(c++); // 결과: 1
            Console.WriteLine(c);   // 결과: 2

            // 감소 연산
            --c;
            c--;
        
            // <관계 연산자>
            // 같음, 다름, 크기 등의 비교 연산자
            // 관계 연산자의 연산결과가 참이면 true, 거짓이면 false 반환

            Console.WriteLine("관계연산 출력");

            // 1. 같음을 비교
            Console.WriteLine(a==b); // 결과: false

            // 2. 다름을 비교
            Console.WriteLine(a!=b);

            // 3. 크기를 비교
            Console.WriteLine(a > b);  //결과: true
            Console.WriteLine(a >= b); //결과: true
            Console.WriteLine(a < b);  //결과: flase
            Console.WriteLine(a <= b); //결과: flase

            // <대입 연산자>
            c = 20;
            c += b; // c = c + b;
            c -= b; // c = c - b;
            c *= b; // c = c * b;
            c /= b; // c = c / b;
            c %= b; // c = c % b;

            // <논리 연산자>
            // OR, AND, XOR, NOT

            bool A = true;
            bool B = false;
            Console.WriteLine("논리 연산 출력");

            // 1. OR: 둘 중 하나라도 참이면 true 반환
            Console.WriteLine(A | B); // 결과: true [Shift + \]

            // 2. AND: 둘 다 참일때만 ture 반환
            Console.WriteLine(A & B); // 결과: false
            
            // 3. XOR: 둘 중 하나만 참일 때 true 반환
            Console.WriteLine(A ^ B); // 결과: true
           
            // 4. NOT: 피연산자가 ture이면 false, false이면 true 반환
            //       : 반환값이 바뀌는 것 뿐, 실제 A의 값이 바뀌지 않음
            Console.WriteLine(!A); // 결과: false
            Console.WriteLine(!B); // 결과: ture

            // 조건부 논리연산자
            // 조건부 OR, 조건부 AND
            // 1. 조건부 OR: 첫번째 피연산자가 true면 B와 비교하지 않고 바로 true 반환
            Console.WriteLine(A || B);
            // 1. 조건부 AND: 첫번째 피연산자가 false면 B와 비교하지 않고 바로 false 반환
            //              : B조건에 접근 불가능할 때 사용
            Console.WriteLine(A && B);

            // <비트 연산자>
            // OR, AND, XOR, NOT, SHIFT-LEFT, SHIFT-RIGHT
            // 정수형 연산할 때 사용

            // 1. OR
            // 기호는 같지만 동작하는 것은 다름
            Console.WriteLine(a | b);
            // a = 14 = 1110        => 2^3+2^2+2^1
            // b = 6 =   110        =>     2^2+2^1
            // a | b =  1110
            // 결과: 14
           
            // 2. AND
            Console.WriteLine(a & b);
            // a = 14 = 1110
            // b = 6 =   110
            // a & b =  0110
            // 결과: 6

            // 3. XOR
            Console.WriteLine(a ^ b);

            // 4. NOT
            Console.WriteLine(~a);
            //결과: -15

            int HowManyBitYouWantToShift = 1;
            // 5. Shift
            Console.WriteLine(a << HowManyBitYouWantToShift);
            // a = 14 = 1110
            // "<<" 적용 시, 1칸 왼쪽으로 이동
            // 0001 1100
            // 결과: 2^4 + 2^3 + 2^2 = 28
            Console.WriteLine(a >> HowManyBitYouWantToShift);
            // ">>" 적용 시, 1칸 오른쪽으로 이동 
            // 0000 0111
            // 결과: 2^2 + 2^1 + 2^0 = 7

        }

    }
}
