using System;

// 구조체
// 값타입 (기본적으로 힙 영역에 할당되지 않음)
// 클래스와 마찬가지로 멤버 변수, 함수 연산자 오버로딩 등을 할 수 있음.

// 언제 클래스 대신 구조체를 쓰는가?
// 값의 변화가 빈번하지 않게 일어날 때 &&
// 멤버필드 크기의 합이 *16 Byte*를 넘지 않을 때 &&
// 박싱이 거의 일어나지 않을때 (박싱: 기본 타입을 object 타입으로 변환하는 과정)
//                             (언박싱: object 타입을 다른 자료형으로 변화하는 과정)
// 기본적인 자료형들로 단일 값들을 나타낼때 (int, float, double 등)

public struct Stats
{
    public int STR;
    public int DEX;
    public int INT;
    public int LUK;

    public Stats(int STR, int DEX, int INT, int LUK)
    {
        this.STR = STR;
        this.DEX = DEX;
        this.INT = INT;
        this.LUK = LUK;
    }

    public int GetCombatScore()
    {
        return STR + DEX + INT + LUK;
    }
}

namespace Structure // 구조체
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stats stats = new Stats(1,2,3,4); // * 구조체 생성자는 멤버필드 초기화에 사용할 뿐, 힙 영역에 할당하거나 참조를 반환하지 않는다. *
            
            Console.WriteLine(stats.GetCombatScore());

            Player player = new Player();
            player.stats.STR = 1;
            player.stats = new Stats(4, 4, 4, 4); // 두가지 방법
            Console.WriteLine(player.stats.STR);

            PrintCombatScore(player);  // 클래스로 만든 함수 출력, player 주소 참조로 // 출력: 16
            PrintCombatScore(player);  // 출력: 3996 (새로 입력한 값 출력)

            PlayerStruct playerStruct = new PlayerStruct(); //구조체로 만든 함수 출력
            playerStruct.stats = new Stats(2, 3, 4, 6);
            PrintCombatScore(playerStruct); // 출력: 16
            PrintCombatScore(playerStruct); // 출력: 16
        }

        public static void PrintCombatScore(Player player) // 클래스로 만든 함수, player 주소 참조
        {
            Console.WriteLine(player.stats.GetCombatScore());
            player.stats = new Stats(999, 999, 999, 999);
        }

        public static void PrintCombatScore(PlayerStruct player) // 구조체로 만든 함수, player 값을 복사
        {
            Console.WriteLine(player.stats.GetCombatScore());
            player.stats = new Stats(999, 999, 999, 999);
        }
    }
        public class Player
    {
        public Stats stats;
        public float HP;
        public float MP;
    
        public void Attack()
        {
            Console.WriteLine("공격!");
        }
    }

    public struct PlayerStruct
    {
        public Stats stats;
        public float HP;
        public float MP;
    }


}
