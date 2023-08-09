using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    
        public Location(string name, string description, string imageName)
        {
            this.Name = name;
            this.Description = description;
            this.ImageName = imageName;
        }
    }
}