using System;

namespace Array2Dimension
{
    internal class Program
    {
        // 2차원 배열: 연속적 데이터
        static int[,] map = //new int[5, 5] (생략가능)
        {
            { 0, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0 },
            { 0, 1, 1, 0, 0 }
        };

        static void Main(string[] args)
        {
            Player player = new Player(3, 0, map);
            //player.MoveLeft(map);
            //player.MoveDown(map);

            // 배열의 배열
            int[][] testArr = new int[3][];
            testArr[0] = new int[3];
            testArr[0][2] = 1;
            testArr[0][1] = 0;
            testArr[0][0] = 0;
            testArr[1] = new int[3];
            testArr[2] = new int[4];

            Console.WriteLine(testArr.Length);
            Console.WriteLine(testArr[0].Length);

            while (true)
            {
                Console.WriteLine($"플레이어 이동 방향을 입력하세요: Left / Right / Up / Down");
                string input = Console.ReadLine();
                if (input.Equals("Left"))
                {
                    player.MoveLeft(map);
                    DisplayMap();
                }
                else if (input.Equals("Right"))
                {
                    player.MoveRight(map);
                    DisplayMap();
                }
                else if (input.Equals("Up"))
                {
                    player.MoveUP(map);
                    DisplayMap();
                }
                else if (input.Equals("Down"))
                {
                    player.MoveDown(map);
                    DisplayMap();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. Left / Right / Up / Down 중에 하나 입력하세요");
                }
            }


            static void DisplayMap()
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++ ){
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }

}




    public class Player
    {
        private int _x;
        private int _y;

        public Player(int x, int y, int[,]map)
        {
            _x = x;
            _y = y;
            map[_y, _x] = 2;
        }

        public void MoveLeft(int[,] map)
        {
            if (_x - 1 < 0)
            {
                Console.WriteLine($"플레이어 왼쪽 이동 실패. (맵의 경계입니다)");
            }
            else if (map[_y, _x - 1] == 1)
            {
                Console.WriteLine($"플레이어 왼쪽 이동 실패. (벽이 있습니다)");
            }
            else if (map[_y, _x - 1] == 0)
            {
                // 원래 있던 공간
                map[_y, _x] = 0;
                _x--;
                // 새로 이동한 공간
                map[_y, _x] = 2;
                Console.WriteLine($"플레이어 왼쪽 이동. 현재 좌표 : {_x}, {_y}");

            }
        }
        public void MoveRight(int[,] map)
        {
            // GetLength: x축의 배열의 크기 = 5
            // 배열은 0~4까지 있고, 4 초과면 오류
            if (_x + 1 > map.GetLength(1) - 1)
            {
                Console.WriteLine($"플레이어 오른쪽 이동 실패. (맵의 경계입니다)");
            }
            else if (map[_y, _x + 1] == 1)
            {
                Console.WriteLine($"플레이어 오른쪽 이동 실패. (벽이 있습니다)");
            }
            else if (map[_y, _x + 1] == 0)
            {
                // 원래 있던 공간
                map[_y, _x] = 0;
                _x++;
                // 새로 이동한 공간
                map[_y, _x] = 2;
                Console.WriteLine($"플레이어 오른쪽 이동. 현재 좌표 : {_x}, {_y}");

            }
        }

        public void MoveDown(int[,] map)
        {
            if (_y + 1 > map.GetLength(0) + 1)
            {
                Console.WriteLine($"플레이어 아래쪽 이동 실패. (맵의 경계입니다)");
            }
            else if (map[_y + 1, _x] == 1)
            {
                Console.WriteLine($"플레이어 아래쪽 이동 실패. (벽이 있습니다)");
            }
            else if (map[_y + 1, _x] == 0)
            {
                // 원래 있던 공간
                map[_y, _x] = 0;
                _y--;
                // 새로 이동한 공간
                map[_y, _x] = 2;
                Console.WriteLine($"플레이어 아래쪽 이동. 현재 좌표 : {_x}, {_y}");

            }
        }
        public void MoveUP(int[,] map)
        {
            // GetLength: x축의 배열의 크기 = 5
            // 배열은 0~4까지 있고, 4 초과면 오류
            if (_y - 1 < 0 )
            {
                Console.WriteLine($"플레이어 위쪽 이동 실패. (맵의 경계입니다)");
            }
            else if (map[_y - 1, _x] == 1)
            {
                Console.WriteLine($"플레이어 위쪽 이동 실패. (벽이 있습니다)");
            }
            else if (map[_y - 1, _x] == 0)
            {
                // 원래 있던 공간
                map[_y, _x] = 0;
                _y--;
                // 새로 이동한 공간
                map[_y, _x] = 2;
                Console.WriteLine($"플레이어 위쪽 이동. 현재 좌표 : {_x}, {_y}");

            }
        }


    }


