using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new();

            newWorld.AddLocation("Farmer's Field", 
                "There are rows of corn growing here, with giant rats hiding between them.", 
                "FarmFields");
            newWorld.AddLocation("Farmer's House",
                "This is the house of your neighbor, Farmer Ted.",
                "Farmhouse");
            newWorld.AddLocation("Home", 
                "This is your home", 
                "Home");
            newWorld.AddLocation("Town square",
                "You see a fountain here.",
                "TownSquare");
            newWorld.AddLocation("Town Gate",
                "There is a gate here, protecting the town from giant spiders.",
                "TownGate");
            newWorld.AddLocation("Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "SpiderForest");
            newWorld.AddLocation("Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "HerbalistsHut");
            newWorld.AddLocation("Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "HerbalistsGarden");

            newWorld.AddLocation("Shop", "Trading Shop",
                "The shop of Susan, the trader.",
                "Trader");

            return newWorld;
        }
    }
}