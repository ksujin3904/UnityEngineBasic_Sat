//메모리 구조
// 컴파일 과정: 프로그래밍 언어 코드 -> 중간언어 -> 어셈블리어 -> 기계어
//
using System;

namespace ClassUseageBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new SwordMan().lv);
            //스택영역          //힙영역
            //        //변수    //인스턴스
            SwordMan swordMan = new SwordMan(); // new 키워드: (참조형식에 대해서) 힙영역에 동적할당하는 키워드
            swordMan.SayName();// .연산자: 멤버 접근 연산자
        }
    }

    // 값 타입 VS 참조 타입

    // 값 타입: 값을 복사해서 직접 할당 (int, float, double, struct ...)
    // 참조 타입: 해당 힙 영역의 참조(주소)를 할당 (class, string)

    // 클래스는 참조타입
    // 클래스의 멤버들은 기본적으로 접근이 제한되어있음 (private)

    //접근 제한자
    // private: 외부 접근 불가
    // public: 외부 접근 가능
    // protected: 자식객체만 접근 가능
    // internal: 동일 어셈블링에서 접근 가능
    public class SwordMan
    {
        public int lv = 1;
        public float exp;
        public bool isAvailable;
        public char gender;
        public string name;
   
        // 생성자와 소멸자도 멤버함수

        // 생성자
        // 객체를 힙영역에 할당하는 함수, 
        public SwordMan()
        {
                     
        }

        // 소멸자
        // 객체를 메모리에서 해제하는 함수
        //-SwordMan()
        //{

        //}

        public void SayName()
        {
            Console.WriteLine(name);
        }
    }
}

