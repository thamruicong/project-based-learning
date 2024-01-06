using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Engine.Models.Items.Item;
using Engine.Models.Items.Misc;
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
        public List<GameItemGroup> Consumables { get; private set;}
        public List<GameItemGroup> Usables { get; private set;}

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
                _items[_items.IndexOf(itemGroup)].IncrementQuantity(itemGroupToAdd.Quantity);
            }
        }

        public void RemoveItem(GameItemGroup itemGroupToRemove)
        {
            GameItemGroup itemGroup = _items.FirstOrDefault(item => item.Item.IsSameItem(itemGroupToRemove.Item)) 
                    ?? throw new ArgumentException(string.Format("Item {0} not found in inventory", itemGroupToRemove.Item.Name));
            
            int newQuantity = _items[_items.IndexOf(itemGroup)].DecrementQuantity(itemGroupToRemove.Quantity);

            if (newQuantity == 0)
            {
                _items.Remove(itemGroup);
            }
        }

        private void UpdateDisplayProperties(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Weapons = new(_items.Where(item => item.Item is Weapon));
            this.Craftables = new(_items.Where(item => item.Item is Craftable));
            this.Consumables = new(_items.Where(item => item.Item is Consumable));
            this.Usables = new[] { this.Weapons, this.Consumables}.SelectMany(item => item).ToList();

            OnPropertyChanged(nameof(Weapons));
            OnPropertyChanged(nameof(Craftables));
            OnPropertyChanged(nameof(Consumables));
            OnPropertyChanged(nameof(Usables));
        }
    }
}