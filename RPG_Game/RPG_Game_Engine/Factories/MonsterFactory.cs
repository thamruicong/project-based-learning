using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Engine.Models.Monsters;
using Engine.Models.Items.Misc;
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
                        new DropChance(itemID: 9001, dropPercentage: 100, minimumQuantity: 1, maximumQuantity: 3),
                        new DropChance(itemID: 9002, dropPercentage: 25, minimumQuantity: 1, maximumQuantity: 1),
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
                        new DropChance(itemID: 9003, dropPercentage: 100, minimumQuantity: 1, maximumQuantity: 1),
                        new DropChance(itemID: 9004, dropPercentage: 75, minimumQuantity: 1, maximumQuantity: 1),
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
                        new DropChance(itemID: 9005, dropPercentage: 50, minimumQuantity: 1, maximumQuantity: 2),
                        new DropChance(itemID: 9006, dropPercentage: 100, minimumQuantity: 1, maximumQuantity: 1),
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
            int randomMonsterKeyID = RandomNumberGenerator.NumberBetweenExclusive(_monsters.Count);

            return CreateMonster(_monsters.Keys.ElementAt(randomMonsterKeyID));
        }
    }
}