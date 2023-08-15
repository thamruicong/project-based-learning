using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Engine.Models.Items;

namespace Engine.Models.Monsters
{
    public class Monster : BaseNotification, ICloneable
    {
        private int _currentHitPoints;
        public int MonsterID { get; private set; }
        public string Name { get; private set; }
        public string ImageName { get; private set; }
        public int MaximumHitPoints { get; private set; }
        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set
            {
                _currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
            }
        }
        public int MinimumDamage { get; private set; }
        public int MaximumDamage { get; private set; }
        public int RewardExperiencePoints { get; private set; }
        public int RewardGold { get; private set; }
        public LootTable LootTable { get; private set;}
        public Inventory? Inventory { get; private set; }

        // Constructor for initializing a monster with a loot table
        public Monster(int monsterID, string name, string imageName, int maximumHitPoints, int minimumDamage, int maximumDamage, int rewardExperiencePoints, int rewardGold, LootTable lootTable)
        {
            this.MonsterID = monsterID;
            this.Name = name;
            this.ImageName = string.Format("pack://application:,,,/RPG_Game_Engine;component/Images/Monsters/{0}.png", imageName);
            this.MaximumHitPoints = maximumHitPoints;
            this.CurrentHitPoints = maximumHitPoints;
            this.MinimumDamage = minimumDamage;
            this.MaximumDamage = maximumDamage;
            this.RewardExperiencePoints = rewardExperiencePoints;
            this.RewardGold = rewardGold;
            this.LootTable = lootTable;
            this.Inventory = null;
        }

        // Constructor for cloning a monster
        private Monster(int monsterID, string name, int maximumHitPoints, int minimumDamage, int maximumDamage, int rewardExperiencePoints, int rewardGold, string imageName, LootTable lootTable)
        {
            this.MonsterID = monsterID;
            this.Name = name;
            this.ImageName = imageName;
            this.MaximumHitPoints = maximumHitPoints;
            this.CurrentHitPoints = maximumHitPoints;
            this.MinimumDamage = minimumDamage;
            this.MaximumDamage = maximumDamage;
            this.RewardExperiencePoints = rewardExperiencePoints;
            this.RewardGold = rewardGold;
            this.LootTable = lootTable;
            this.Inventory = LootTable.RollLoot();
        }

        public Monster Clone()
        {
            return new Monster(this.MonsterID, this.Name, this.MaximumHitPoints, this.MinimumDamage, this.MaximumDamage, this.RewardExperiencePoints, this.RewardGold, this.ImageName, this.LootTable);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}