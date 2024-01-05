using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models.Items.Item;

namespace Engine.Models.Items.Misc
{
    public class GameItemGroup
    {
        public GameItem Item { get; set; }
        public int Quantity { get; set; }

        public GameItemGroup(GameItem item, int quantity)
        {
            this.Item = item;
            this.Quantity = quantity;
        }
    }
}