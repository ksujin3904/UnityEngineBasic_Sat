using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritanceAndPolymorphism
{

        internal class Player : Creature,ITwoLeggedWalkable //,뒤는 추상화로 인터페이스가 들어옴
                                                            // Player는 ITwoLeggedWalkable 인터페이스에 의존

         // dip 적용 전: 초보자용 칼, 중급자용 칼, 고급자용 칼에 의존
         // dip 적용 후: 칼 인터페이스에 의존하며, 칼 인터페이스는 초보자용 칼, 중급자용 칼, 고급자용 칼에 의존
        {
        public string nickname;

            public virtual void Attack()
            // virtual: 가상키워드, 해당 함수를 재정의 할 수 있도록 해줌.
            // virtual 함수가 호출되면 최하단에 override 된 함수를 호출.
            {
                Console.WriteLine($"{nickname} (이)가 공격했다!");
            }

            public void Jump()
            {
                Console.WriteLine($"{nickname} (이)가 점프했다!");
            }

        public void TwoLeggedWalk()
        {
            Console.WriteLine($"{nickname} (이)가 이족보행했다.");
        }

        public override void Grow()
        {
            throw new NotImplementedException();
        }
    }
    
}
