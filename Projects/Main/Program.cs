using FIFA14;
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
            string baseURL = "http://www.futhead.com/14/players/";
            Player player = new Player(12386, baseURL);
        }
    }
}
