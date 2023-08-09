using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Monster : BaseNotification, ICloneable
    {
        private int _currentHitPoints;
        public int ID { get; private set; }
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

        public Monster(int id, string name, string imageName, int maximumHitPoints, int rewardExperiencePoints, int rewardGold)
        {
            this.ID = id;
            this.Name = name;
            this.ImageName = string.Format("pack://application:,,,/RPG_Game_Engine;component/Images/Monsters/{0}.png", imageName);
            this.MaximumHitPoints = maximumHitPoints;
            this.CurrentHitPoints = maximumHitPoints;
            this.RewardExperiencePoints = rewardExperiencePoints;
            this.RewardGold = rewardGold;
            this.LootTable = new Inventory();
        }

        public Monster Clone()
        {
            return new Monster(this.ID, this.Name, this.ImageName, this.MaximumHitPoints, this.RewardExperiencePoints, this.RewardGold);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}