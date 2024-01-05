using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Controllers;
using Engine.Models.Monsters;
using Engine.EventArgs;

namespace Engine.Models.Items.Item
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int itemID, string name, int minimumDamage, int maximumDamage, int? price = null) : base(itemID, name, price)
        {
            this.MinimumDamage = minimumDamage;
            this.MaximumDamage = maximumDamage;
        }

        public override Weapon Clone()
        {
            return new Weapon(this.ItemID, this.Name, this.MinimumDamage, this.MaximumDamage, this.Price);
        }

        public int RollDamage()
        {
            return RandomNumberGenerator.NumberBetweenInclusive(this.MinimumDamage, this.MaximumDamage);
        }

        public override void Use(GameSession gameSession)
        {
            if (gameSession.CurrentPlayer.Attack(gameSession.CurrentMonster!) == GameSession.AttackResult.ATTACK_FAILURE)
            {
                return;
            }

            if (gameSession.CurrentMonster!.CurrentHitPoints <= 0)
            {
                GameMessage.RaiseMessage(this, "");
                GameMessage.RaiseMessage(this, $"You defeated the {gameSession.CurrentMonster.Name}!");

                gameSession.CurrentMonster.ReleaseRewards(gameSession.CurrentPlayer);
                gameSession.CurrentMonster = null;

                return;
            }

            gameSession.CurrentMonster.Attack(gameSession.CurrentPlayer);

            if (gameSession.CurrentPlayer.CurrentHitPoints <= 0)
            {
                GameMessage.RaiseMessage(this, "");
                GameMessage.RaiseMessage(this, $"You were defeated by the {gameSession.CurrentMonster.Name}!");
            }
        }
    }
}