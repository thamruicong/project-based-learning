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
        private readonly static List<Monster> _monsters;

        static MonsterFactory()
        {
            _monsters = new List<Monster>
            {
                new Monster(4001, "Snake", "Snake", 8, 10, 10),
                new Monster(4002, "Rat", "Rat", 5, 5, 5),
                new Monster(4003, "Spider", "Spider", 10, 10, 10),
            };
        }
        
        internal static Monster GetMonster(int monsterID)
        {
            Monster monster = _monsters.FirstOrDefault(monster => monster.ID == monsterID) 
                    ?? throw new ArgumentException(string.Format("Monster ID {0} does not exist", monsterID));
            
            return monster.Clone();
        }
    }
}