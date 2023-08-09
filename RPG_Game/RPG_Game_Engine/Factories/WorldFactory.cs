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
            World newWorld = new World();

            newWorld.AddLocation("Farmer's Field", 
                "There are rows of corn growing here, with giant rats hiding between them.", 
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/FarmFields.png");
            newWorld.AddLocation("Farmer's House",
                "This is the house of your neighbor, Farmer Ted.",
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/Farmhouse.png");
            newWorld.AddLocation("Home", 
                "This is your home", 
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/Home.png");
            newWorld.AddLocation("Town square",
                "You see a fountain here.",
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/TownSquare.png");
            newWorld.AddLocation("Town Gate",
                "There is a gate here, protecting the town from giant spiders.",
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/TownGate.png");
            newWorld.AddLocation("Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/SpiderForest.png");
            newWorld.AddLocation("Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/HerbalistsHut.png");
            newWorld.AddLocation("Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/HerbalistsGarden.png");

            newWorld.AddLocation("Shop", "Trading Shop",
                "The shop of Susan, the trader.",
                "pack://application:,,,/RPG_Game_Engine;component/Images/Locations/Trader.png");

            return newWorld;
        }
    }
}