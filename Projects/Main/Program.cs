using FIFA15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseURL = "http://www.futhead.com/15/players/";
            //int id = 39941;
            int id = 1;
            int gkId = 906;
            //Player player = new Player(12386, baseURL);
            PlayerBase basePlayer = PlayerFactory.CreatePlayer(id, baseURL);
        }
    }
}
