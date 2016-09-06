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

        public void Load(string filepath)
        {
            XElement wordpress = XElement.Load(filepath);

            var itemList = wordpress.Descendants("item");

            var res = from it in itemList
                      where it.Element(XName.Get("post_type", "http://wordpress.org/export/1.2/")).Value == "st_kb" // st_faq //!= "attachment"
                      select it.Element(XName.Get("post_type", "http://wordpress.org/export/1.2/"));
            //select it.Element(XName.Get("encoded", "http://purl.org/rss/1.0/modules/content/"));

            // wp = http://wordpress.org/export/1.2/
            var a = res.ToArray();
        }

    }
}
