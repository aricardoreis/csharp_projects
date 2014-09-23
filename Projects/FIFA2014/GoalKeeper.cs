using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA15
{
    public class GoalKeeper : PlayerBase
    {
        public GoalKeeper(int id, string url)
            : base(id, url)
        {
            LoadProperties();
        }

        public GoalKeeper(int id, string url, HtmlDocument document)
            : base(id, url, document)
        {
            LoadProperties();
        }

        #region Skills (GK)

        public int? DIV { get; set; }
        public int? HAN { get; set; }
        public int? KIC { get; set; }
        public int? REF { get; set; }
        public int? SPE { get; set; }
        public int? POS { get; set; }
  
        #endregion

        protected override void LoadProperties()
        {
            base.LoadProperties();

            DIV = Attribute1;
            HAN = Attribute2;
            KIC = Attribute3;
            REF = Attribute4;
            SPE = Attribute5;
            POS = Attribute6;
        }
    }
}
