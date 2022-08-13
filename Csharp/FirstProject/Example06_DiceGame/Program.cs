using System;

namespace Example06_RollADice
{
    internal class Program
    {
        static private int totalDiceNumber = 20; // 전체 주사위 개수
        static Random random = new Random();
        static private int currentPos;
        static private int previousPos;
        static private int totalMapsize = 20;
        static private int totalStarPoint = 0;
        static void Main(string[] args)
        {
            int currentDiceNumber = totalDiceNumber;
            // 맵 불러오기
            TileMap map = new TileMap();
            map.MapSetUp(20);

            // 엔터키가 입력되면 주사위 굴림

            while(currentDiceNumber > 0)
            {
                int diceValue = RollADice();
                // 주사위 갯수 차감
                currentDiceNumber--;
                // 플레이어 전진
                currentPos += diceValue;

                // 샛별 획득
                EarnStarValue(map, currentPos, previousPos);

                // 주사위 눈금만큼 플레이어 전진
                // if (플레이어위치 > 전체 맵 타일 갯수)
                //          플레이어 위치 -= 전체 맵 타일 갯수
                if (currentPos > totalMapsize)
                    currentPos -= totalMapsize;

                if (map.TryGetTileInfo(currentPos,out TileInfo tileInfo))
                {
                    tileInfo.OnTile();
                }
                else
                {
                    throw new Exception("플레이어가 맵을 이탈했습니다.");
                }

                previousPos = currentPos;
                Console.WriteLine($"현재 샛별점수: {totalStarPoint}");
                Console.WriteLine($"남은 주사위 갯수: {currentDiceNumber}");
                
            }
            // 주사위를 전부 사용함

            Console.WriteLine($"게임 끝! 총 샛별점수: {totalStarPoint}");

        }

        static private int RollADice()
        {
            string userinput = "Default";
            while (userinput != "")
            {
                Console.WriteLine("주사위를 굴리려면 엔터키를 누르세요");
                userinput = Console.ReadLine();
                if (userinput != "")
                    Console.WriteLine("엔터키만 누르세요");
                else
                    break;
            }

            int diceValue = random.Next(1, 7);
            // 주사위 눈금 표시
            DisplayDice(diceValue);
            return diceValue;
        }

        static private void EarnStarValue(TileMap map, int currnetPos, int previousPos)
        {
            // 플레이어가 샛별칸 몇개 지났는지 체크
            int passedStarTileNum = currentPos / 5 - previousPos / 5;
            // 지난 샛별칸 갯수 = 플레이어위치 / 5 - 이전 플레이어 위치 / 5
            // for (i=0, i < 지난 샛별칸 갯수만큼, i++)
            // {
            //      지난 샛별칸 인덱스 = (플레이어위치 / 5 - i ) * 5
            //      지난 샛별칸 인덱스에 해당하는 TileInfo 가져오기
            //      해당 샛별칸의 starValue 만큼 샛별점수 누적
            // }

            for (int i = 0; i < passedStarTileNum; i++)
            {
                
                int starTileindex = (currentPos / 5 - i) * 5;

                if(starTileindex > totalMapsize)
                    starTileindex -= totalMapsize;

                if (map.TryGetTileInfo(starTileindex, out TileInfo tileInfo_star))
                {
                    totalStarPoint += (tileInfo_star as TileInfo_Star).starValue;
                }
                else
                {
                    throw new Exception("샛별 칸 정보를 가져오는데 실패했습니다.");
                }
            }
        }


        static private void DisplayDice (int diceValue)
        {
            switch (diceValue)
            {
                case 1:
                    Console.WriteLine($"주사위 눈금은  {diceValue}");
                    Console.WriteLine("┌────-─-┐");
                    Console.WriteLine("│            │");
                    Console.WriteLine("│            │");
                    Console.WriteLine("│     ●     │");
                    Console.WriteLine("│            │");
                    Console.WriteLine("│            │");
                    Console.WriteLine("└──---──-┘");
                    break;
                case 2:
                    Console.WriteLine($"주사위 눈금은  {diceValue}");
                    break;
                case 3:
                    Console.WriteLine($"주사위 눈금은  {diceValue}");
                    break;
                case 4:
                    Console.WriteLine($"주사위 눈금은  {diceValue}");
                    break;
                case 5:
                    Console.WriteLine($"주사위 눈금은  {diceValue}");
                    break;
                case 6:
                    Console.WriteLine($"주사위 눈금은  {diceValue}");
                    break;
                default:
                    break;
            }
        }
    }
}
