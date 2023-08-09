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
        public World CurrentWorld { get; set; }

        public GameSession() 
        {
            this.CurrentPlayer = new Player("Scott", "Fighter", 10, 0, 1, 100000);
            this.CurrentWorld = new WorldFactory().CreateWorld();
            this.CurrentLocation = this.CurrentWorld.GetNewLocation(this.CurrentLocation);
        }

        public void OnClick_Move()
        {
            this.CurrentLocation = this.CurrentWorld.GetNewLocation(this.CurrentLocation);
        }

        public void OnClick_Shop()
        {
            this.CurrentLocation = this.CurrentWorld.GetLocation("Shop");
        }
    }
}