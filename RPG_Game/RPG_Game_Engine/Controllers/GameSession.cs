using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Models.Monsters;
using Engine.Factories;
using Engine.EventArgs;

namespace Engine.Controllers
{
    public class GameSession : BaseNotification
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        #region Properties

        private Location _currentLocation;
        private Monster? _currentMonster;
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
        public Monster? CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));
                OnPropertyChanged(nameof(IsInBattle));
            }
        }
        public bool HasMonster => CurrentMonster != null;
        public bool IsInBattle => HasMonster && CurrentMonster?.CurrentHitPoints > 0;
        internal World CurrentWorld { get; set; }

        #endregion

        public GameSession()
        {
            this.CurrentPlayer = new Player("Scott", "Fighter", 10, 0, 1, 100000);
            this.CurrentWorld = WorldFactory.CreateWorld();

            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1001, 1));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1001, 2));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1002, 1));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(9002, 5));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(9006, 8));
        }

        public void OnClick_Move()
        {
            this.CurrentLocation = this.CurrentWorld.GetLocation(this.CurrentLocation);
            this.CurrentMonster = MonsterFactory.GetRandomMonster();
            
            RaiseMessage($"You see a {this.CurrentMonster.Name} here!");
        }

        public void OnClick_Shop()
        {
            this.CurrentLocation = this.CurrentWorld.GetLocation("Shop");
            this.CurrentMonster = null;
            
            RaiseMessage($"You have entered the shop!");
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}