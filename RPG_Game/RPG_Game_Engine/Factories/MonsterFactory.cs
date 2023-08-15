using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Engine.Models.Monsters;
using Engine.Models.Items;
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
                {4001, new Monster(
                    monsterID: 4001,
                    name: "Snake", 
                    imageName: "Snake", 
                    maximumHitPoints: 8, 
                    minimumDamage: 1, 
                    maximumDamage: 2, 
                    rewardExperiencePoints: 10, 
                    rewardGold: 10, 
                    lootTable: new(new() {
                        new DropChance(9001, 100, 1, 3),
                        new DropChance(9002, 25, 1, 1),
                    })
                )},
                {4002, new Monster(
                    monsterID: 4002, 
                    name: "Rat", 
                    imageName: "Rat", 
                    maximumHitPoints: 5, 
                    minimumDamage: 2,
                    maximumDamage: 2, 
                    rewardExperiencePoints: 5, 
                    rewardGold: 5, 
                    lootTable: new(new() {
                        new DropChance(9003, 100, 1, 1),
                        new DropChance(9004, 75, 1, 1),
                    })
                )},
                {4003, new Monster(
                    monsterID: 4003, 
                    name: "Spider", 
                    imageName: "Spider", 
                    maximumHitPoints: 10, 
                    minimumDamage: 1, 
                    maximumDamage: 5, 
                    rewardExperiencePoints: 10, 
                    rewardGold: 10, 
                    lootTable: new(new() {
                        new DropChance(9005, 50, 1, 2),
                        new DropChance(9006, 100, 1, 1),
                    })
                )},
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