using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Engine.Models.Items;

namespace Engine.Factories
{
    internal static class ItemFactory
    {
        private readonly static Dictionary<int, GameItem> _gameItems;

        static ItemFactory()
        {
            _gameItems = new Dictionary<int, GameItem>
            {
                {1001, new Weapon(1001, "Pointy Stick", 1, 2)},
                {1002, new Weapon(1002, "Rusty Sword", 2, 3, 5)},
                {9001, new Craftable(9001, "Snakeskin", "The skin of a snake. Looks durable.", 2)},
                {9002, new Craftable(9002, "Snake venom", "One drop can kill.", 10)},
                {9003, new Craftable(9003, "Rat tail", "Looks gross.", 1)},
                {9004, new Craftable(9004, "Rat meat", "Edible, but not very tasty.", 2)},
                {9005, new Craftable(9005, "Spider fang", "Sharp and poisonous.", 5)},
                {9006, new Craftable(9006, "Spider silk", "Strong and flexible.", 3)},
            };
        }

        internal static GameItem CreateGameItem(int itemID)
        {
            if (!_gameItems.ContainsKey(itemID))
            {
                throw new ArgumentException(string.Format("Item ID {0} does not exist", itemID));
            }
            
            return _gameItems[itemID].Clone();
        }

        internal static GameItemGroup CreateGameItemGroup(int itemID, int quantity)
        {
            GameItem item = CreateGameItem(itemID);
            return new GameItemGroup(item, quantity);
        }
    }
}