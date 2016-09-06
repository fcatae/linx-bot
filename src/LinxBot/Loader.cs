using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinxBot
{
    public class Loader
    {
        public Loader()
        {
        }

        public IEnumerable<Article> LoadFromFile(string filepath)
        {
            return LoadFromFile(filepath, null);
        }

        public IEnumerable<Article> LoadFromFile(string filepath, Func<Article,bool> filter)
        {
            string XMLNS_WP = "http://wordpress.org/export/1.2/";
            string XMLNS_CONTENT = "http://purl.org/rss/1.0/modules/content/";

            XElement wordpress = XElement.Load(filepath);

            var itemList = wordpress.Descendants("item");

            var articles = from item in itemList
                           select new Article()
                           {
                               Id = 0,
                               Title = item.Element("title").Value,
                               Link = item.Element("link").Value,
                               Content = item.Element(XName.Get("encoded", XMLNS_CONTENT)).Value,
                               PostType = item.Element(XName.Get("post_type", XMLNS_WP)).Value,
                               Categories = (from c in item.Elements("category")
                                             select c.Attribute("domain").Value + ":" + c.Attribute("nicename").Value).ToArray()
                           };

            var filtered_articles = (filter != null) ? articles.Where(filter) : articles;

            return filtered_articles;
        }
    }
}
