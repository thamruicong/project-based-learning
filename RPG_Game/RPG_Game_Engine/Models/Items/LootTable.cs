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
        public List<DropChance> DropChances { get; private set; }

        public LootTable(List<DropChance> dropChances)
        {
            DropChances = dropChances;
        }

        public Inventory RollLoot()
        {
            Inventory inventory = new();
            Random random = new();

            foreach (DropChance dropChance in DropChances)
            {
                if (random.Next(1, 101) <= dropChance.DropPercentage)
                {
                    inventory.AddItem(ItemFactory.CreateGameItemGroup(dropChance.ItemID, random.Next(dropChance.MinimumQuantity, dropChance.MaximumQuantity + 1)));
                }
            }

            return inventory;
        }
    }
}