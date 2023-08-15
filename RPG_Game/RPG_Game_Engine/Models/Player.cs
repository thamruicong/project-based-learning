using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.EventArgs;
using Engine.Models.Items;
using Engine.Models.Monsters;

namespace Engine.Models
{
    public class Player : BaseNotification
    {
        private string _characterClass;
        private int _currentHitPoints;
        private int _maximumHitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        public string Name { get; private set; }
        public string CharacterClass 
        {
            get { return _characterClass; }
            set 
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }
        public int CurrentHitPoints 
        {
            get { return _currentHitPoints; }
            set 
            {
                _currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
            }
        }
        public int MaximumHitPoints 
        {
            get { return _maximumHitPoints; }
            set 
            {
                _maximumHitPoints = value;
                OnPropertyChanged(nameof(MaximumHitPoints));
            }
        }
        public int ExperiencePoints 
        {
            get { return _experiencePoints; }
            set 
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public int Level 
        {
            get { return _level; }
            set 
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Gold 
        {
            get { return _gold; }
            set 
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public Inventory Inventory { get; private set; }
        public GameItemGroup Weapon { get; set; }
    
        public Player(string name, string characterClass, int hitPoints, int experiencePoints, int level, int gold)
        {
            this.Name = name;
            this.CharacterClass = characterClass;
            this.CurrentHitPoints = hitPoints;
            this.MaximumHitPoints = hitPoints;
            this.ExperiencePoints = experiencePoints;
            this.Level = level;
            this.Gold = gold;
            this.Inventory = new Inventory();
        }

        public void Attack(Monster monster)
        {
            if (this.Weapon == null || !(this.Weapon.Item is Weapon) || this.Weapon.Quantity == 0)
            {
                GameMessage.RaiseMessage(this, "You must select a weapon, to attack.");
                return;
            }

            Weapon Weapon = (Weapon)this.Weapon.Item;

            int damageToMonster = RandomNumberGenerator.NumberBetween(Weapon.MinimumDamage, Weapon.MaximumDamage);

            // Hit the monster
            if (damageToMonster == 0)
            {
                GameMessage.RaiseMessage(this, $"You missed the {monster.Name}.");
            }
            else
            {
                monster.CurrentHitPoints -= damageToMonster;
                GameMessage.RaiseMessage(this, $"You hit the {monster.Name} for {damageToMonster} points.");
            }

            // Check if the monster is dead
            if (monster.CurrentHitPoints <= 0)
            {
                GameMessage.RaiseMessage(this, "");
                GameMessage.RaiseMessage(this, $"You defeated the {monster.Name}!");

                this.ExperiencePoints += monster.RewardExperiencePoints;
                GameMessage.RaiseMessage(this, $"You receive {monster.RewardExperiencePoints} experience points.");

                this.Gold += monster.RewardGold;
                GameMessage.RaiseMessage(this, $"You receive {monster.RewardGold} gold.");

                foreach (GameItemGroup gameItemGroup in monster.Inventory?.Items ?? Enumerable.Empty<GameItemGroup>())
                {
                    this.Inventory.AddItem(gameItemGroup);
                    GameMessage.RaiseMessage(this, $"You receive {gameItemGroup.Quantity} {gameItemGroup.Item.Name}.");
                }

                // Raise the OnKilled event to set CurrentMonster to null
            }
            else
            {
                int damageToPlayer = RandomNumberGenerator.NumberBetween(monster.MinimumDamage, monster.MaximumDamage);

                if (damageToPlayer == 0)
                {
                    GameMessage.RaiseMessage(this, $"The {monster.Name} attacks, but misses you.");
                }
                else
                {
                    this.CurrentHitPoints -= damageToPlayer;
                    GameMessage.RaiseMessage(this, $"The {monster.Name} hit you for {damageToPlayer} points.");
                }
            }
        }
    }
}