using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Engine.Models.Items;

namespace Engine.Models
{
    public class Inventory
    {
        private ObservableCollection<GameItemGroup> _items;

        public ObservableCollection<GameItemGroup> Items { get { return _items; } }

        public Inventory()
        {
            _items = new ObservableCollection<GameItemGroup>();
        }

        public void AddItem(GameItem itemToAdd)
        {
            GameItemGroup? itemGroup = _items.FirstOrDefault(item => item.Item.Equals(itemToAdd));

            if (itemGroup == null)
            {
                _items.Add(new GameItemGroup(itemToAdd, 1));
            }
            else
            {
                itemGroup.Quantity++;
            }
        }

        public void RemoveItem(GameItem itemToRemove)
        {
            GameItemGroup? itemGroup = _items.FirstOrDefault(item => item.Item.Equals(itemToRemove));

            if (itemGroup == null)
            {
                throw new ArgumentException(string.Format("Item {0} not found in inventory", itemToRemove));
            }
            else if (itemGroup.Quantity == 1)
            {
                _items.Remove(itemGroup);
            }
            else
            {
                itemGroup.Quantity--;
            }
        }
    }
}