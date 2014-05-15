using FIFA2014;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA2014
{
    public class PlayerFactory
    {
        public static PlayerBase CreatePlayer(int id, string url)
        {
            PlayerBase player = new PlayerBase(id, url);
            if (player.Position != PlayerPosition.GK)
            {
                player = new Player(id, url, player.Document);
            }
            else
            {
                player = new GoalKeeper(id, url, player.Document);
            }
            return player;
        }
    }
}
