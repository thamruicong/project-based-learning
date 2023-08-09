using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Engine.Models.Items;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _gameItems;

        static ItemFactory()
        {
            _gameItems = new List<GameItem>
            {
                new Weapon(1001, "Pointy Stick", 1, 2),
                new Weapon(1002, "Rusty Sword", 2, 3, 5)
            };
        }

        public static GameItem CreateGameItem(int itemID)
        {
            GameItem? item = _gameItems.FirstOrDefault(item => item.ItemID == itemID);

            if (item == null)
            {
                throw new ArgumentException(string.Format("Item ID {0} does not exist", itemID));
            }

            return item.Clone();
        }
    }
}