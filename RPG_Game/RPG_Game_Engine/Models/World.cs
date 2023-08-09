using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();
        private Dictionary<string, Location> _special_locations = new Dictionary<string, Location>();
        public World() {}

        internal void AddLocation(string name, string description, string imageName)
        {
            _locations.Add(new Location(name, description, imageName));
        }

        internal void AddLocation(string key, string name, string description, string imageName)
        {
            _special_locations.Add(key, new Location(name, description, imageName));
        }

        internal Location GetLocation(Location prev)
        {
            while (true)
            {
                Random random = new Random();
                int index = random.Next(0, _locations.Count);
                if (0 <= index && index < _locations.Count && _locations[index] != prev)
                {
                    return _locations[index];
                }
            }
        }

        internal Location GetLocation(string key)
        {
            try
            {
                return _special_locations[key];
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException(string.Format("Key not found in {0} dictionary", nameof(_special_locations)), e);
            }
        }
    }
}