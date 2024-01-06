using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models.Items.Item;

namespace Engine.Models.Items.Misc
{
    public class GameItemGroup : BaseNotification
    {
        private int _quantity;
        public GameItem Item { get; set; }
        public int Quantity 
        {
            get { return _quantity; }
            set 
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        
        public GameItemGroup(GameItem item, int quantity)
        {
            this.Item = item;
            this.Quantity = quantity;
        }

        public int IncrementQuantity(int quantity)
        {
            this.Quantity += quantity;
            return this.Quantity;
        }

        public int DecrementQuantity(int quantity)
        {
            if (this.Quantity < quantity)
            {
                throw new ArgumentException(string.Format("Item {0} does not have enough quantity", this.Item.Name));
            }

            this.Quantity -= quantity;
            return this.Quantity;
        }
    }
}