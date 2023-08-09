using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.Items
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

        public override bool Equals(object? obj)
        {
            if (obj is Weapon weapon)
            {
                return base.Equals(weapon) && this.MinimumDamage == weapon.MinimumDamage && this.MaximumDamage == weapon.MaximumDamage;
            }
            else
            {
                return false;
            }
        }
    }
}