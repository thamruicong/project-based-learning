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
        private readonly static List<GameItem> _gameItems;

        static ItemFactory()
        {
            _gameItems = new List<GameItem>
            {
                new Weapon(1001, "Pointy Stick", 1, 2),
                new Weapon(1002, "Rusty Sword", 2, 3, 5),
                new Craftable(9001, "Snakeskin", "The skin of a snake. Looks durable.", 2),
                new Craftable(9002, "Snake venom", "One drop can kill.", 10),
                new Craftable(9003, "Rat tail", "Looks gross.", 1),
                new Craftable(9004, "Rat meat", "Edible, but not very tasty.", 2),
                new Craftable(9005, "Spider fang", "Sharp and poisonous.", 5),
                new Craftable(9006, "Spider silk", "Strong and flexible.", 3),
            };
        }

        internal static GameItem CreateGameItem(int itemID)
        {
            GameItem item = _gameItems.FirstOrDefault(item => item.ItemID == itemID) 
                    ?? throw new ArgumentException(string.Format("Item ID {0} does not exist", itemID));
            
            return item.Clone();
        }

        internal static GameItemGroup CreateGameItemGroup(int itemID, int quantity)
        {
            GameItem item = CreateGameItem(itemID);
            return new GameItemGroup(item, quantity);
        }
    }
}