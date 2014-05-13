using FIFA2014;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA14
{
    public class Player : SearchableObject
    {
        public Player(int id, string url)
            : base(id, url)
        {
        }

        public string ShortName
        {
            get
            {
                string result = null;

                HtmlNode node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-name']/span");
                if (node != null)
                {
                    result = node.InnerText;
                }

                return result;
            }
        }

        public string FullName
        {
            get
            {
                string result = null;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = nodes[0].InnerText;
                }

                return result;
            }
        }

        public string Source
        {
            get
            {
                string result = null;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    if (nodes[7].InnerText == "Source")
                    {
                        result = nodes[8].InnerText;
                    }
                }

                return result;
            }
        }

        public PlayerPosition Position
        {
            get
            {
                PlayerPosition result = PlayerPosition.None;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = (PlayerPosition)Enum.Parse(typeof(PlayerPosition), nodes[10].InnerText);
                }

                return result;
            }
        }

        public int Age
        {
            get
            {
                int result = 0;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = int.Parse(nodes[12].InnerText);
                }

                return result;
            }
        }

        public int ClubId { get; set; }
        public int LeagueId { get; set; }
        public int NationId { get; set; }

        public int Height
        {
            get
            {
                int result = 0;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = int.Parse(nodes[14].InnerText.Substring(0, 3));
                }

                return result;
            }
        }

        public PlayerFoot Foot
        {
            get
            {
                PlayerFoot result = PlayerFoot.None;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = (PlayerFoot)Enum.Parse(typeof(PlayerFoot), nodes[16].InnerText);
                }

                return result;
            }
        }

        public PlayerLevel AttackWorkrate
        {
            get
            {
                PlayerLevel result = PlayerLevel.None;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = (PlayerLevel)Enum.Parse(typeof(PlayerLevel), nodes[18].InnerText);
                }

                return result;
            }
        }

        public PlayerLevel DefensiveWorkrate
        {
            get
            {
                PlayerLevel result = PlayerLevel.None;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = (PlayerLevel)Enum.Parse(typeof(PlayerLevel), nodes[20].InnerText);
                }

                return result;
            }
        }

        public int WeakFoot
        {
            get
            {
                int result = 0;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = int.Parse(nodes[22].InnerText.Trim());
                }

                return result;
            }
        }

        public int SkillMoves
        {
            get
            {
                int result = 0;

                HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div[@id='player-misc-stats']//td");
                if (nodes.Count > 0)
                {
                    result = int.Parse(nodes[24].InnerText.Trim());
                }

                return result;
            }
        }

        #region Skills

        public int BallControl { get; set; }
        public int Crossing { get; set; }
        public int Curve { get; set; }
        public int Dribbling { get; set; }
        public int Finishing { get; set; }
        public int FreeKickAcc { get; set; }
        public int HeadingAcc { get; set; }
        public int LongPassing { get; set; }
        public int LongShots { get; set; }
        public int Marking { get; set; }
        public int Penalties { get; set; }
        public int ShortPassing { get; set; }
        public int ShotPower { get; set; }
        public int SlidingTackle { get; set; }
        public int StandingTackle { get; set; }
        public int Volleys { get; set; }

        #endregion

        #region Physical

        public int Acceleration { get; set; }
        public int Agility { get; set; }
        public int Balance { get; set; }
        public int Jumping { get; set; }
        public int Reactions { get; set; }
        public int SprintSpeed { get; set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }

        #endregion

        #region Mental

        public int Aggression { get; set; }
        public int Positioning { get; set; }
        public int Interceptions { get; set; }
        public int Vision { get; set; }

        #endregion

        public int Overall { get; set; }

        public int PAC { get; set; }
        public int SHO { get; set; }
        public int PAS { get; set; }
        public int DRI { get; set; }
        public int DEF { get; set; }
        public int HEA { get; set; }

        public int TotalStats { get; set; }

        public int PriceOnPlayStation { get; set; }
        public int PriceOnXbox { get; set; }
        public int PriceOnPC { get; set; }

    }
}
