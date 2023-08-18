using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Engine.Factories;

namespace Engine.Models.Items
{
    public class LootTable
    {
        private List<DropChance> DropChances { get; set; }

        public LootTable(List<DropChance> dropChances)
        {
            DropChances = dropChances;
        }

        internal Inventory RollLoot()
        {
            Inventory inventory = new();

            foreach (DropChance dropChance in DropChances)
            {
                if (RandomNumberGenerator.NumberBetweenInclusive(1, 100) <= dropChance.DropPercentage)
                {
                    inventory.AddItem(ItemFactory.CreateGameItemGroup(dropChance.ItemID, RandomNumberGenerator.NumberBetweenInclusive(dropChance.MinimumQuantity, dropChance.MaximumQuantity)));
                }
            }

            return inventory;
        }
    }
}