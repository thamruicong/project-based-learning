using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Models.Monsters;
using Engine.Factories;
using Engine.EventArgs;
using Engine.Models.Items.Misc;

namespace Engine.Controllers
{
    public class GameSession : BaseNotification
    {
        #region Properties

        private Location? _currentLocation;
        private Monster? _currentMonster;
        public Player CurrentPlayer { get; private set; }
        public Location? CurrentLocation
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
        public static ShopKeeper ShopKeeper => ShopKeeper.GetInstance();
        public bool HasMonster => CurrentMonster != null;
        public bool IsInBattle => HasMonster && CurrentMonster?.CurrentHitPoints > 0;
        private World CurrentWorld { get; set; }

        #endregion

        #region Game Variables

        internal enum AttackResult
        {
            ATTACK_SUCCESS,
            ATTACK_FAILURE
        }

        #endregion

        public GameSession()
        {
            this.CurrentPlayer = new Player("Scott", "Fighter", 10, 0, 1, 100000);
            this.CurrentWorld = WorldFactory.CreateWorld();

            //temp
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1001, 1));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1001, 2));
            this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1002, 1));

            if (!CurrentPlayer.Inventory.Weapons.Any())
            {
                this.CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItemGroup(1001, 1));
            }
        }

        public void OnClick_Move()
        {
            this.CurrentLocation = this.CurrentWorld.GetRandomLocation(this.CurrentLocation);
            this.CurrentMonster = MonsterFactory.GetRandomMonster();
            
            GameMessage.RaiseMessage(this, $"You see a {this.CurrentMonster.Name} here!");
        }

        public void OnClick_Attack()
        {
            if (this.CurrentPlayer.Attack(this.CurrentMonster!) == AttackResult.ATTACK_FAILURE)
            {
                return;
            }

            if (this.CurrentMonster!.CurrentHitPoints <= 0)
            {
                GameMessage.RaiseMessage(this, "");
                GameMessage.RaiseMessage(this, $"You defeated the {this.CurrentMonster.Name}!");

                this.CurrentMonster.ReleaseRewards(this.CurrentPlayer);
                this.CurrentMonster = null;

                return;
            }

            this.CurrentMonster.Attack(this.CurrentPlayer);

            if (this.CurrentPlayer.CurrentHitPoints <= 0)
            {
                GameMessage.RaiseMessage(this, "");
                GameMessage.RaiseMessage(this, $"You were defeated by the {this.CurrentMonster.Name}!");
            }
        }

        public void OnClick_Sell(GameItemGroup item)
        {
            if (item.Item.Price is null)
            {
                return;
            }

            this.CurrentPlayer.Inventory.RemoveItem(item);
            this.CurrentPlayer.Gold += (int) item.Item.Price;
            GameMessage.RaiseMessage(this, $"You sold 1 {item.Item.Name} for {item.Item.Price} gold.");
        }

        public void OnClick_Buy(GameItemGroup item)
        {
            if (item.Item.Price is null)
            {
                return;
            }

            if (this.CurrentPlayer.Gold < (int) item.Item.Price)
            {
                GameMessage.RaiseMessage(this, $"You do not have enough gold to buy {item.Item.Name}.");
                return;
            }

            this.CurrentPlayer.Inventory.AddItem(item);
            this.CurrentPlayer.Gold -= (int) item.Item.Price;
            GameMessage.RaiseMessage(this, $"You bought 1 {item.Item.Name} for {item.Item.Price} gold.");
        }
    }
}