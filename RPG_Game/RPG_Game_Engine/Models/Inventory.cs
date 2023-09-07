using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Engine.Models.Items;
using System.Collections.Generic;
using System.Collections.Specialized;
using Engine.Factories;

namespace Engine.Models
{
    public class Inventory : BaseNotification
    {
        private readonly ObservableCollection<GameItemGroup> _items;

        public ObservableCollection<GameItemGroup> Items { get { return _items; } }

        #region Display Properties
        public List<GameItemGroup> Weapons { get; private set;}
        public List<GameItemGroup> Craftables { get; private set;}

        #endregion

        public Inventory()
        {
            _items = new ObservableCollection<GameItemGroup>();
            _items.CollectionChanged += UpdateDisplayProperties;
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
                _items.Remove(itemGroup);
                _items.Add(ItemFactory.CreateGameItemGroup(itemGroup.Item, itemGroup.Quantity + itemGroupToAdd.Quantity));
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
                _items.Remove(itemGroup);
                _items.Add(ItemFactory.CreateGameItemGroup(itemGroup.Item, itemGroup.Quantity - itemGroupToRemove.Quantity));
            }
        }

        private void UpdateDisplayProperties(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Weapons = new(_items.Where(item => item.Item is Weapon));
            this.Craftables = new(_items.Where(item => item.Item is Craftable));
        
            OnPropertyChanged(nameof(Weapons));
            OnPropertyChanged(nameof(Craftables));
        }
    }
}