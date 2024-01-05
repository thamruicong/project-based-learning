using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.Items.Misc
{
    public class DropChance
    {
        public int ItemID { get; private set; }
        
        // Out of 100
        public int DropPercentage { get; private set; }
        public int MinimumQuantity { get; private set; }
        public int MaximumQuantity { get; private set; }

        public DropChance(int itemID, int dropPercentage, int minimumQuantity, int maximumQuantity)
        {
            this.ItemID = itemID;
            this.DropPercentage = dropPercentage;
            this.MinimumQuantity = minimumQuantity;
            this.MaximumQuantity = maximumQuantity;
        }
    }
}