using FIFA15;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FIFA15
{
    public class Player : PlayerBase
    {
        public Player(int id, string url)
            : base(id, url)
        {
            LoadProperties();
        }

        public Player(int id, string url, HtmlDocument document)
            : base(id, url, document)
        {
            LoadProperties();
        }

        #region Skills

        public int? BallControl { get; set; }
        public int? Crossing { get; set; }
        public int? Curve { get; set; }
        public int? Dribbling { get; set; }
        public int? Finishing { get; set; }
        public int? FreeKickAccuracy { get; set; }
        public int? HeadingAccuracy { get; set; }
        public int? LongPassing { get; set; }
        public int? LongShots { get; set; }
        public int? Marking { get; set; }
        public int? Penalties { get; set; }
        public int? ShortPassing { get; set; }
        public int? ShotPower { get; set; }
        public int? SlidingTackle { get; set; }
        public int? StandingTackle { get; set; }
        public int? Volleys { get; set; }

        #endregion

        #region Physical

        public int? Acceleration { get; set; }
        public int? Agility { get; set; }
        public int? Balance { get; set; }
        public int? Jumping { get; set; }
        public int? Reactions { get; set; }
        public int? SprintSpeed { get; set; }
        public int? Stamina { get; set; }
        public int? Strength { get; set; }

        #endregion

        #region Mental

        public int? Aggression { get; set; }
        public int? Positioning { get; set; }
        public int? Interceptions { get; set; }
        public int? Vision { get; set; }

        #endregion

        #region Overall Stats

        public int? PAC { get; set; }
        public int? SHO { get; set; }
        public int? PAS { get; set; }
        public int? DRI { get; set; }
        public int? DEF { get; set; }
        public int? PHY { get; set; }

        #endregion

        protected override void LoadProperties()
        {
            base.LoadProperties();

            PAC = Attribute1;
            SHO = Attribute2;
            PAS = Attribute3;
            DRI = Attribute4;
            DEF = Attribute5;
            PHY = Attribute6;

            HtmlNodeCollection nodeCollection = null;

            // load player stats (skill, mental and physical)
            nodeCollection = _document.DocumentNode.SelectNodes("//div[@class='igs-list']/div");
            foreach (var item in nodeCollection)
            {
                string itemName = item.SelectSingleNode("span").InnerText.Replace(" ", string.Empty);
                int itemValue = int.Parse(item.SelectSingleNode("p").InnerText.Trim());
                SetPropertyValue(itemName, itemValue);
            }
        }

    }
}
