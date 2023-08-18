using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Engine.Models
{
    internal class World
    {
        private readonly List<Location> _locations = new();
        private readonly Dictionary<string, Location> _special_locations = new();
        internal World() {}

        internal void AddLocation(string name, string description, string imageName)
        {
            _locations.Add(new Location(name, description, imageName));
        }

        internal void AddLocation(string key, string name, string description, string imageName)
        {
            _special_locations.Add(key, new Location(name, description, imageName));
        }

        internal Location GetRandomLocation(Location? prev)
        {
            while (true)
            {
                int index = RandomNumberGenerator.NumberBetweenExclusive(_locations.Count);
                if (_locations[index] != prev)
                {
                    return _locations[index];
                }
            }
        }

        internal Location GetSpecialLocation(string key)
        {
            if (!_special_locations.ContainsKey(key))
            {
                throw new KeyNotFoundException(string.Format("Key {0} not found in {1} dictionary", key, nameof(_special_locations)));
            }
            
            return _special_locations[key];
        }
    }
}