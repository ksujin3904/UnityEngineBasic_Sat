using System;

// enum: 열거형 사용자정의 (정수)자료형
public enum State // 캐릭터의 상태 표현, 자동으로 0,1,2,3,4가 되며, 값을 넣어줄 수 있음
{
    Idle,   // ... 00000000
    Walk,   // ... 00000001
    Run,    // ... 00000010
    Jump,   // ... 00000011
    Attack, // ... 00000100
    Hurt,   // ... 00000101
    Die     // ... 00000110
}

//[Flags]
public enum StateFlags
{
    Idle = 0 << 0,   // ... 00000000
    Walk = 1 << 0,   // ... 00000001
    Run = 1 << 1,    // ... 00000010
    Attack = 1 << 2, // ... 00001000
    Hurt = 1 << 3,   // ... 00010000
    Die = 1 << 4,     // ... 00100000
    Runattck = Run | Attack // ...00001010
}

public enum MakingToastState
{
    PutFryPanOnInduction,
    InductionOn,
    PutButter,
    PutBread,
    ReverseBread,
    InductionOff,
    TranslateToastDish,
}

namespace Statement_SwitchCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //switch (조건변수)
            //{
            //    case 조건값1;
            //        break;
            //    case 조건값2;
            //        break;
            //    default:
            //        break;
            //}

            int stateNum = 0;
            switch (stateNum)
            {
                case 0:
                    Console.WriteLine("0 입니다.");
                    break;
                case 1:
                    Console.WriteLine("1 입니다.");
                    break;
                case 2:
                    Console.WriteLine("2 입니다.");
                    break;
                default:
                    break;
            }

            State state = State.Hurt; // State의 요소에 접근
            // switch -> tab 2번 -> switch_on을 state로 변경 -> enter
            switch (state)
            {
                case State.Idle:
                    Console.WriteLine("문도 가만히 있는다.");
                    break;
                case State.Walk:
                    Console.WriteLine("문도 걷는다.");
                    break;
                case State.Run:
                    Console.WriteLine("문도 뛴다.");
                    break;
                case State.Attack:
                    Console.WriteLine("문도 때린다.");
                    break;
                case State.Hurt:
                    Console.WriteLine("문도 아프다.");
                    break;
                case State.Die:
                    Console.WriteLine("문도 죽는다.");
                    break;
                default:
                    break;
            }

            // 유한 상태 머신 (FSM: Finite STate Machine)
            // 상태들이 정해진 일정한 동작을 수행하는 도구 등.
            MakingToastState makingToastState = MakingToastState.PutFryPanOnInduction;
            bool toastComplete = false;
            // toastComplete가 ture면 while문 종료
            while (toastComplete == false)
            {
                switch (makingToastState)
                {
                    case MakingToastState.PutFryPanOnInduction:
                        Console.WriteLine("프라이팬 올림");
                        makingToastState++;
                        break;
                    case MakingToastState.InductionOn:
                        Console.WriteLine("인덕션 켜기");
                        makingToastState++;
                        break;
                    case MakingToastState.PutButter:
                        Console.WriteLine("버터 넣기");
                        makingToastState++;
                        break;
                    case MakingToastState.PutBread:
                        Console.WriteLine("빵 넣기");
                        makingToastState++;
                        break;
                    case MakingToastState.ReverseBread:
                        Console.WriteLine("빵 뒤집기");
                        makingToastState++;
                        break;
                    case MakingToastState.InductionOff:
                        Console.WriteLine("인덕션 끄기");
                        makingToastState++;
                        break;
                    case MakingToastState.TranslateToastDish:
                        Console.WriteLine("토스트 접시에 옮기기");
                        makingToastState = MakingToastState.PutFryPanOnInduction;
                        toastComplete = true;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
