using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    public class ShopKeeper
    {
        #region Singleton Pattern
        private static readonly ShopKeeper _shopKeeper = new();
        public static ShopKeeper GetInstance()
        {
            return _shopKeeper;
        }
        #endregion

        private readonly Inventory _inventory = new();
        private ShopKeeper()
        {
            _inventory.AddItem(ItemFactory.CreateGameItemGroup(3001, 1));
            _inventory.AddItem(ItemFactory.CreateGameItemGroup(9001, 1));
            _inventory.AddItem(ItemFactory.CreateGameItemGroup(9002, 1));
            _inventory.AddItem(ItemFactory.CreateGameItemGroup(9003, 1));
            _inventory.AddItem(ItemFactory.CreateGameItemGroup(9004, 1));
            _inventory.AddItem(ItemFactory.CreateGameItemGroup(9005, 1));
            _inventory.AddItem(ItemFactory.CreateGameItemGroup(9006, 1));
        }

        public Inventory Inventory 
        {
            get { return _inventory; } set {}
        }
    }
}