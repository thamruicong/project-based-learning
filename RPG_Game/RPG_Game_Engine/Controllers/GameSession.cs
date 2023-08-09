using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;

namespace Engine.Controllers
{
    public class GameSession : BaseNotification
    {
        private Location _currentLocation;
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set 
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }
        internal World CurrentWorld { get; set; }

        public GameSession()
        {
            this.CurrentPlayer = new Player("Scott", "Fighter", 10, 0, 1, 100000);
            this.CurrentWorld = WorldFactory.CreateWorld();
            this.CurrentLocation = this.CurrentWorld.GetLocation(this.CurrentLocation);

            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1001, 1));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1001, 2));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1002, 1));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(9002, 5));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(9006, 8));
        }

        public void OnClick_Move()
        {
            this.CurrentLocation = this.CurrentWorld.GetLocation(this.CurrentLocation);
        }

        public void OnClick_Shop()
        {
            this.CurrentLocation = this.CurrentWorld.GetLocation("Shop");
        }
    }
}