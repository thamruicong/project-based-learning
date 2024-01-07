using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Location
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageName { get; private set; }

        public Location(string name, string description, string imageName)
        {
            this.Name = name;
            this.Description = description;
            this.ImageName = string.Format("pack://application:,,,/RPG_Game_Engine;component/Images/Locations/{0}.png", imageName);
        }
    }
}