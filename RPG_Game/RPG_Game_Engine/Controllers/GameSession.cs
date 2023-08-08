using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Controllers
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }

        public GameSession() 
        {
            this.CurrentPlayer = new Player("Scott", "Fighter", 10, 0, 1, 100000);
        }
    }
}