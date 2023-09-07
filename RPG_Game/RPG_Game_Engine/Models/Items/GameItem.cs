using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.Items
{
    public abstract class GameItem : ICloneable
    {
        public int ItemID { get; set; }
        public string Name { get; set; }

        // Untradable items will have a null price
        public int? Price { get; set; }

        public GameItem(int itemID, string name, int? price = null)
        {
            this.ItemID = itemID;
            this.Name = name;
            this.Price = price;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public abstract GameItem Clone();

        public bool IsSameItem(GameItem otherItem)
        {
            return this.ItemID == otherItem.ItemID;
        }
    }
}