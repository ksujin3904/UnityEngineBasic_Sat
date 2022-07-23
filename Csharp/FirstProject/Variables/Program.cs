using System;

// Variable(변수) :
// 아직 값을 모르는 상징적인 이름(식별 문자)
//int a = 3; // 전역변수

namespace Methods
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            // 자료형 (Data type): 
            // 데이터의 종류를 식별하기 위한 분류
            
            }
        //함수 정의
        //접근제한자 (static) 반환형 함수이름 (매개변수자료형 매개변수이름, 매개변수자료형, 매개변수이름)
        // {
        //     return 반환값;
        // }
        

    }
}

class SwordMan
{
    //bite: 한자리 이진수 (0과 1, 정보 처리의 최소단위) [2의 1승]
    //byte: 8 bit == 1byte (CPU의 데이터 처리 최소단위) [2의 8승]
    //4byte == 32bit [2의 32승]

    //초기화: 변수 선언과 동시에 값을 넣는 것
    int lv; // 4byte 크기의 부호가 있는 정수 자료형 명시 키워드 [(-2^31)~(2^31 - 1) 갯수의 숫자표현 가능]
    uint ulv; // unsigned int로, 4byte 크기의 부호가 없는 정수 자료형 0~2^32
    float exp; // 4byte 크기의 실수
    double dexp; // 8byte 크기의 실수
    bool isAvailable; // 논리형, true와 false로 구분함. 1 byte로 ture는 0이 아닌 수, false는 0
                      // bit가 아닌 byte를 쓰는 이유는 데이터의 처리 최소 단위는 bit가 아닌 byte기 때문.
    char gender; // 문자형, 2byte,  ASCII 코드형식으로 정수형 저장
    char[] name1; // 배열형, 연속된 자료형 타입
    String name2 = new String('c', 3); // String 객체 참조형
    String name; //문자열형
}

