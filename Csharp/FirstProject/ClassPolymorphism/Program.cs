using System;
// 클래스의 상속과 다형성
namespace ClassInheritanceAndPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creature creature = new Creature(); : 추상화하면 불가능
            Player player = new Player();
            // creature.Breath(); : 추상화하면 불가능
            player.Breath();

            Warrior warrior = new Warrior();
            Wizard wizard = new Wizard();
            Knight knight = new Knight();

            warrior.Smash();
            wizard.FireBall();
            knight.Dash();

            // 3명 모두 다 동시에 player의 attack 호출
            Player[] players = new Player[3];
            // Player test = new Warrior(); => 공간성
            // Player는 부모 클래스 타입, Warrior는 자식 클래스 타입
            // warrior를 Players 참조에 등록
            // ** 즉, 자식객체를 부모타입으로 참조할 수 있다. **
            players[0] = warrior;
            players[1] = wizard;
            players[2] = knight;
            // but, 부모타입으로 참조시 자식객체만의 멤버에는 접근할 수 없다.
            // players[0].Smash(); => 불가능

            for (int i = 0; i < players.Length; i++)
            {
                players[i].Attack();
            }

            ITwoLeggedWalkable[] twoLeggedWalkables = new ITwoLeggedWalkable[3];
            twoLeggedWalkables[0] = new Warrior();
            twoLeggedWalkables[1] = new EnemyTwoLeggedWalkable();
            twoLeggedWalkables[2] = new Wizard();

            for (int i = 0; i<twoLeggedWalkables.Length; i++)
            {
                twoLeggedWalkables[i].TwoLeggedWalk();
            }


        }
    }
}
