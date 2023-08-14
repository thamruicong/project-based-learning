using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
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
        public int RewardExperiencePoints { get; private set; }
        public int RewardGold { get; private set; }
        public Inventory LootTable { get; private set; }

        public Monster(int monsterID, string name, string imageName, int maximumHitPoints, int rewardExperiencePoints, int rewardGold)
        {
            this.MonsterID = monsterID;
            this.Name = name;
            this.ImageName = string.Format("pack://application:,,,/RPG_Game_Engine;component/Images/Monsters/{0}.png", imageName);
            this.MaximumHitPoints = maximumHitPoints;
            this.CurrentHitPoints = maximumHitPoints;
            this.RewardExperiencePoints = rewardExperiencePoints;
            this.RewardGold = rewardGold;
            this.LootTable = new Inventory();
        }

        private Monster(int monsterID, string name, int maximumHitPoints, int rewardExperiencePoints, int rewardGold, string imageName)
        {
            this.MonsterID = monsterID;
            this.Name = name;
            this.ImageName = imageName;
            this.MaximumHitPoints = maximumHitPoints;
            this.CurrentHitPoints = maximumHitPoints;
            this.RewardExperiencePoints = rewardExperiencePoints;
            this.RewardGold = rewardGold;
            this.LootTable = new Inventory();
        }

        public Monster Clone()
        {
            return new Monster(this.MonsterID, this.Name, this.MaximumHitPoints, this.RewardExperiencePoints, this.RewardGold, this.ImageName);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}