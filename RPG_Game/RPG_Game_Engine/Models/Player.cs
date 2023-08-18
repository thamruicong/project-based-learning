using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Controllers;
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
        public GameItemGroup? ItemInHand { get; set; }
    
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

        internal GameSession.AttackResult Attack(Monster monster)
        {
            if (this.ItemInHand == null || !(this.ItemInHand.Item is Weapon) || this.ItemInHand.Quantity == 0)
            {
                GameMessage.RaiseMessage(this, "You must select a weapon to attack.");
                return GameSession.AttackResult.ATTACK_FAILURE;
            }

            Weapon Weapon = (Weapon)this.ItemInHand.Item;

            int damageToMonster = RandomNumberGenerator.NumberBetweenInclusive(Weapon.MinimumDamage, Weapon.MaximumDamage);

            // Hit the monster
            monster.TakeDamage(damageToMonster);

            return GameSession.AttackResult.ATTACK_SUCCESS;
        }

        internal void TakeDamage(Monster monster, int damageToPlayer)
        {
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