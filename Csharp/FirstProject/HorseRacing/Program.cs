using System;
using System.Threading;
//프로그램 시작시
//말 다섯마리를 만들고
//각 다섯마리는 초당 10~20 (정수형) 범위 거리를 랜덤하게 움직임
//각각의 말이 거리 200에 도달하면 말의 이름과 등수를 출력
//
//말은 이름, 달린거리를 멤버변수로
//달리기를 멤버 함수로 가짐.
//달리기 멤버함수는 입력받은 거리를 달린거리에 더해주어서 달린거리를 누적시키는 역할을 함.
//
//매초 달릴 때 마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌.
//경주가 끝나면 1,2,3,4,5,등 말의 이름을 등수 순서대로 콘솔창에 출력해줌.

namespace Example02_HorseRacing
{
    internal class Program
    {
        static int totalHorses = 5;
        static Random random;
        static int minSpped = 10;
        static int maxSpped = 20;
        static bool isFinished = false;
        static int finishDistance = 50;
        static void Main(string[] args)
        {
            // 말 5마리의 배열 생성

            int[] finishHorsesIndex = new int[totalHorses];
            Horse[] horses = new Horse[totalHorses];
                int grade = 0;
                // 말 5마리 인스턴스화
                for (int i = 0; i < horses.Length; i++)
                {
                    horses[i] = new Horse($"horse{i + 1}", 0, true); // 달리기가 가능하면 true
                }

                Console.WriteLine("경주 시작!");
                int count = 0;

                while (!isFinished)
                {
                    Console.WriteLine($"====================={count} 초 경과 =====================");
                    for (int i = 0;i < horses.Length; i++)
                    {
                    if (horses[i].enabled)
                    {
                        // 난수 생성
                        random = new Random();
                        int tmpMoveDistance = random.Next(minSpped, maxSpped + 1);
                        // 말이 난수만큼 달림
                        horses[i].Run(tmpMoveDistance);
                        Console.WriteLine($"{horses[i].name}이 달린거리: {horses[i].distance}");
                        // 말이 최종거리 200을 넘으면 enabled = false처리하며 랭크 +1 
                        if (horses[i].distance >= finishDistance)
                        {
                            horses[i].enabled = false;
                            finishHorsesIndex[grade] = i;
                            grade++;
                            Console.WriteLine($"{grade} 등으로 도착");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"{horses[i].name}는 도착");
                    }
                    }
                
                    if (grade >= horses.Length)
                    {
                    isFinished = true;
                    Console.WriteLine("경주 끝!");
                    break;
                      
                    }

                count++;
                Thread.Sleep(1000);

            }
            Console.WriteLine("착순표");
            for (int i = 0; i < finishHorsesIndex.Length; i++)
            {
                Console.WriteLine($"{horses[finishHorsesIndex[i]]}는 ");
            }
        }
    }

    public class Horse
    {
        public string name;
        public int distance;
        public bool enabled;

        public Horse(string name, int distance, bool enabled)
        {
            this.name = name;
            this.distance = distance;
            this.enabled = enabled;
            
        }


        public void Run(int moveDistance)
        {
            distance += moveDistance;
        }
    }
}
