using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Controllers;
using Engine.Factories;

namespace Engine.Models.Items.Item
{
    public class Consumable : GameItem
    {
        public Consumable(int itemID, string name, int? price = null) : base(itemID, name, price) {}

        public override Consumable Clone()
        {
            return new Consumable(this.ItemID, this.Name, this.Price);
        }

        private void Consume(Inventory inventory)
        {
            inventory.RemoveItem(ItemFactory.CreateGameItemGroup(this, 1));
        }

        public override void Use(GameSession gameSession)
        {
            gameSession.CurrentPlayer.CurrentHitPoints = Math.Min(gameSession.CurrentPlayer.CurrentHitPoints + 5, gameSession.CurrentPlayer.MaximumHitPoints);
            this.Consume(gameSession.CurrentPlayer.Inventory);
        }
    }
}