using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritanceAndPolymorphism
{
    internal class Warrior : Player
    {
        public override void Attack()
        {
            Console.WriteLine($"Warrior {nickname} (이)가 공격했다.");
        }
        public void Smash()
        {
            Console.WriteLine($"{nickname} (이)가 휘둘렀다.");
        }
    }
}
