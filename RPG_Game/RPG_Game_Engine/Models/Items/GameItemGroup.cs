using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.Items
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