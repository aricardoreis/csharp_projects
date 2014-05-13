using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace FIFA2014
{
    public abstract class SearchableObject
    {
        protected string _url;
        protected HtmlDocument _document;

        public int Id { get; private set; }

        public SearchableObject(int id, string baseUrl)
        {
            Id = id;
            _url = baseUrl + id;
            LoadDocument();
        }

        protected void LoadDocument()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            htmlWeb.OverrideEncoding = Encoding.UTF8;
            _document = htmlWeb.Load(_url);
        }
    }
}
