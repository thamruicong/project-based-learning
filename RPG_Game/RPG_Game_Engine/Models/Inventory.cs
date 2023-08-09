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
        private readonly ObservableCollection<GameItemGroup> _items;

        public ObservableCollection<GameItemGroup> Items { get { return _items; } }

        public Inventory()
        {
            _items = new ObservableCollection<GameItemGroup>();
        }

        public void AddItem(GameItemGroup itemGroupToAdd)
        {
            GameItemGroup? itemGroup = _items.FirstOrDefault(item => item.Item.IsSameItem(itemGroupToAdd.Item));

            if (itemGroup == null)
            {
                _items.Add(itemGroupToAdd);
            }
            else
            {
                itemGroup.Quantity += itemGroupToAdd.Quantity;
            }
        }

        public void RemoveItem(GameItemGroup itemGroupToRemove)
        {
            GameItemGroup itemGroup = _items.FirstOrDefault(item => item.Item.IsSameItem(itemGroupToRemove.Item)) 
                    ?? throw new ArgumentException(string.Format("Item {0} not found in inventory", itemGroupToRemove.Item.Name));
            
            if (itemGroup.Quantity < itemGroupToRemove.Quantity)
            {
                throw new ArgumentException(string.Format("Item {0} does not have enough quantity", itemGroup.Item.Name));
            }

            if (itemGroup.Quantity == itemGroupToRemove.Quantity)
            {
                _items.Remove(itemGroup);
            }
            else if (itemGroup.Quantity > itemGroupToRemove.Quantity)
            {
                itemGroup.Quantity -= itemGroupToRemove.Quantity;
            }
        }
    }
}