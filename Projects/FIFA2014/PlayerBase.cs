﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Reflection;
using System.Net;
using Newtonsoft.Json;

namespace FIFA15
{
    public class PlayerBase
    {
        private const string SOURCE = "Source";
        private const string PRICES_URL = "http://www.futhead.com/15/players/{0}/prices/all/";

        protected string _url;
        protected HtmlDocument _document;

        public HtmlDocument Document { get { return _document; } }

        #region Personal Features

        public int Id { get; private set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string ClubName { get; set; }
        public string LeagueName { get; set; }
        public string NationName { get; set; }
        public string Source { get; set; }
        public PlayerType Type { get; set; }
        public bool IsRare { get; set; }
        public bool IsInForm { get; set; }
        public PlayerPosition Position { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public PlayerFoot Foot { get; set; }
        public Level AttackWorkrate { get; set; }
        public Level DefensiveWorkrate { get; set; }
        public int? WeakFoot { get; set; }
        public int? SkillMoves { get; set; }
        public string ImageUrl { get; set; }
        public string ClubImageUrl { get; set; }
        public string NationImageUrl { get; set; }
        public int ClubId { get; set; }
        public int NationId { get; set; }
        public int LeagueId { get; set; }
        
        #endregion

        #region Prices

        public int? PriceOnPlayStation { get; set; }
        public int? PriceOnXbox { get; set; }
        public int? PriceOnPC { get; set; }

        #endregion

        #region Overall Stats

        public int? OverallRating { get; set; }

        public int? Attribute1 { get; set; }
        public int? Attribute2 { get; set; }
        public int? Attribute3 { get; set; }
        public int? Attribute4 { get; set; }
        public int? Attribute5 { get; set; }
        public int? Attribute6 { get; set; }

        #endregion

        public PlayerBase(int id, string baseUrl)
        {
            Id = id;
            _url = baseUrl + id;
            LoadDocument();
            LoadProperties();
        }

        public PlayerBase(int id, string baseUrl, HtmlDocument document)
        {
            Id = id;
            _url = baseUrl + id;
            _document = document;
            LoadProperties();
        }

        protected void LoadDocument()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            htmlWeb.OverrideEncoding = Encoding.UTF8;
            _document = htmlWeb.Load(_url);
        }

        protected virtual void LoadProperties()
        {
            HtmlNode node = null;
            HtmlNodeCollection nodeCollection = null;

            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-rating']");
            if (node != null)
            {
                OverallRating = int.Parse(node.InnerText);
            }

            // load player overall stats
            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr1']");
            if (node != null)
            {
                Attribute1 = int.Parse(node.InnerText.Split(null)[0]);
            }
            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr2']");
            if (node != null)
            {
                Attribute2 = int.Parse(node.InnerText.Split(null)[0]);
            }
            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr3']");
            if (node != null)
            {
                Attribute3 = int.Parse(node.InnerText.Split(null)[0]);
            }
            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr4']");
            if (node != null)
            {
                Attribute4 = int.Parse(node.InnerText.Split(null)[0]);
            }
            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr5']");
            if (node != null)
            {
                Attribute5 = int.Parse(node.InnerText.Split(null)[0]);
            }
            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr6']");
            if (node != null)
            {
                Attribute6 = int.Parse(node.InnerText.Split(null)[0]);
            }

            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-name']/span");
            if (node != null)
            {
                ShortName = node.InnerText;
            }

            node = _document.DocumentNode.SelectSingleNode("//*[@id='player-overview-card']/a/div");
            string data = node.Attributes[0].Value;
            IsRare = !data.Contains("non-rare");
            IsInForm = data.Contains("if");
            this.Type = data.Contains("gold") ? PlayerType.Gold : 
                data.Contains("silver") ? PlayerType.Silver : 
                data.Contains("bronze") ? PlayerType.Bronze : 
                PlayerType.None;

            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-picture']/img");
            if (node != null)
            {
                ImageUrl = node.Attributes["src"].Value;
            }

            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-nation']/img");
            if (node != null)
            {
                NationImageUrl = node.Attributes["src"].Value;
                NationId = Convert.ToInt32(NationImageUrl.Substring(50).Replace(".png", ""));
            }

            node = _document.DocumentNode.SelectSingleNode("//div[@class='playercard-club']/img");
            if (node != null)
            {
                ClubImageUrl = node.Attributes["src"].Value;
                ClubId = Convert.ToInt32(ClubImageUrl.Substring(48).Replace(".png", ""));
            }

            // load the league id on the other page
            node = _document.DocumentNode.SelectSingleNode("/html/body/div[2]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody/tr[3]/td[2]/a");
            string url = node.Attributes["href"].Value;
            HtmlWeb htmlWeb = new HtmlWeb();
            htmlWeb.OverrideEncoding = Encoding.UTF8;
            HtmlDocument document = htmlWeb.Load("http://www.futhead.com/" + url);
            node = document.DocumentNode.SelectSingleNode("//h1/img");
            LeagueId = Convert.ToInt32(node.Attributes["src"].Value.Substring(56).Replace(".png", ""));

            nodeCollection = _document.DocumentNode.SelectNodes("//div[@class='right-content-fixed']//td");
            if (nodeCollection != null && nodeCollection.Count > 0)
            {
                int index = 0;

                FullName = nodeCollection[index].InnerText;
                ClubName = nodeCollection[index += 2].InnerText.Trim();
                LeagueName = nodeCollection[index += 2].InnerText.Trim();
                NationName = nodeCollection[index += 2].InnerText.Trim();

                string propertyName = nodeCollection[index + 1].InnerText.Trim();
                if (propertyName == SOURCE)
                {
                    Source = nodeCollection[index += 2].InnerText.Trim();
                }

                Position = (PlayerPosition)Enum.Parse(typeof(PlayerPosition), nodeCollection[index += 4].InnerText);
                Age = int.Parse(nodeCollection[index += 2].InnerText);
                string temp = nodeCollection[index += 2].InnerText;
                int finalIndex = temp.IndexOf('c');
                Height = int.Parse(temp.Substring(0, finalIndex));
                Foot = (PlayerFoot)Enum.Parse(typeof(PlayerFoot), nodeCollection[index += 2].InnerText);
                AttackWorkrate = (Level)Enum.Parse(typeof(Level), nodeCollection[index += 2].InnerText);
                DefensiveWorkrate = (Level)Enum.Parse(typeof(Level), nodeCollection[index += 2].InnerText);
                WeakFoot = int.Parse(nodeCollection[index += 2].InnerText.Trim());
                SkillMoves = int.Parse(nodeCollection[index += 2].InnerText.Trim());
            }

            // loads the prices
            //WebClient client = new WebClient();
            //string result = client.DownloadString(string.Format(PRICES_URL, Id));
            //if (result != null)
            //{
            //    PriceInformation prices = JsonConvert.DeserializeObject<PriceInformation>(result);
            //    PriceOnPlayStation = StringToInt(prices.PS);
            //    PriceOnXbox = StringToInt(prices.Xbox);
            //    PriceOnPC = StringToInt(prices.PC);
            //}
        }

        protected void SetPropertyValue(string propertyName, object value)
        {
            PropertyInfo prop = this.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(this, value, null);
            }
        }

        private int? StringToInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            return null;
        }

    }
}
