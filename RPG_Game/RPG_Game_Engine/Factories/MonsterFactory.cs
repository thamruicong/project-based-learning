using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Engine.Models;

namespace Engine.Factories
{
    internal static class MonsterFactory
    {
        private readonly static Dictionary<int, Monster> _monsters;

        static MonsterFactory()
        {
            _monsters = new Dictionary<int, Monster>
            {
                {4001, new Monster(4001, "Snake", "Snake", 8, 10, 10)},
                {4002, new Monster(4002, "Rat", "Rat", 5, 5, 5)},
                {4003, new Monster(4003, "Spider", "Spider", 10, 10, 10)},
            };
        }
        
        internal static Monster CreateMonster(int monsterID)
        {
            if (!_monsters.ContainsKey(monsterID))
            {
                throw new ArgumentException(string.Format("Monster ID {0} does not exist", monsterID));
            }
            
            return _monsters[monsterID].Clone();
        }

        internal static Monster GetRandomMonster()
        {
            Random random = new();
            int randomMonsterKeyID = random.Next(_monsters.Count);

            return CreateMonster(_monsters.Keys.ElementAt(randomMonsterKeyID));
        }
    }
}