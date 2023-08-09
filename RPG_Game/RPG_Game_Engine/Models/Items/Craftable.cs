using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.Items
{
    public class Craftable : GameItem
    {
        public string Description { get; set; }

        public Craftable(int itemID, string name, string description, int? price = null) : base(itemID, name, price)
        {
            this.Description = description;
        }

        public override Craftable Clone()
        {
            return new Craftable(this.ItemID, this.Name, this.Description, this.Price);
        }
    }
}