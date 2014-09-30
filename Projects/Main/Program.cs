using FIFA15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseURL = "http://www.futhead.com/15/players/";
            int id = 39941;
            //int id = 1;
            int gkId = 906;
            //Player player = new Player(12386, baseURL);
            PlayerBase basePlayer = PlayerFactory.CreatePlayer(id, baseURL);

            //SQLiteConnection connection = new SQLiteConnection("Data Source=fifa15.sqlite;Version=3;New=False;Compress=True;");
            //connection.Open();

            //connection.Close();
        }
    }
}
