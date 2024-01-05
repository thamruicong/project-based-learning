using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Engine.Models.Items.Item;
using Engine.Models.Items.Misc;

namespace Engine.Factories
{
    internal static class ItemFactory
    {
        private readonly static Dictionary<int, GameItem> _gameItems;

        static ItemFactory()
        {
            _gameItems = new Dictionary<int, GameItem>
            {
                {1001, new Weapon(
                    itemID: 1001, 
                    name: "Pointy Stick", 
                    minimumDamage: 1, 
                    maximumDamage: 2
                )},
                {1002, new Weapon(
                    itemID: 1002, 
                    name: "Rusty Sword", 
                    minimumDamage: 2, 
                    maximumDamage: 3, 
                    price: 5
                )},
                {9001, new Craftable(
                    itemID: 9001, 
                    name: "Snakeskin", 
                    description: "The skin of a snake. Looks durable.",
                    price: 2
                )},
                {9002, new Craftable(
                    itemID: 9002, 
                    name: "Snake Venom", 
                    description: "One drop can kill.", 
                    price: 10
                )},
                {9003, new Craftable(
                    itemID: 9003, 
                    name: "Rat Tail", 
                    description: "Looks gross.", 
                    price: 1
                )},
                {9004, new Craftable(
                    itemID: 9004, 
                    name: "Rat Meat", 
                    description: "Edible, but not very tasty.", 
                    price: 2
                )},
                {9005, new Craftable(
                    itemID: 9005, 
                    name: "Spider Fang", 
                    description: "Sharp and poisonous.", 
                    price: 5
                )},
                {9006, new Craftable(
                    itemID: 9006, 
                    name: "Spider Silk", 
                    description: "Strong and flexible.", 
                    price: 3
                )},
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

        internal static GameItemGroup CreateGameItemGroup(GameItem item, int quantity)
        {
            return new GameItemGroup(item, quantity);
        }
    }
}