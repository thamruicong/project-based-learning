using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.Items
{
    public abstract class GameItem
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }

        public GameItem(int itemID, string name, int? price = null)
        {
            this.ItemID = itemID;
            this.Name = name;
            this.Price = price;
        }

        public abstract GameItem Clone();

        public override bool Equals(object? obj)
        {
            if (obj is GameItem item)
            {
                return this.ItemID == item.ItemID;
            }
            else
            {
                return false;
            }
        }
    }
}