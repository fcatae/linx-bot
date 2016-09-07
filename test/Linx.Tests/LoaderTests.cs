using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinxBot;
using Xunit;

namespace Linx.Tests
{
    public class LoaderTests
    {
        [Fact]
        public void Load_Rss_File()
        {
            var loader = new Loader();

            var items = new List<Article>(loader.LoadFromFile(@"xml\rss.xml"));

            Assert.Equal(items.Count, 1);
            Assert.Equal(items[0].Title, "Installing WordPress");            
        }

        [Fact]
        public void Load_All_Items()
        {
            string file = Tests.XMLFILE;
            var loader = new Loader();
            var articles = loader.LoadFromFile(file);

            var repo = new Repository(Tests.DATABASE);

            foreach (var art in articles)
            {
                repo.Save(art);
            }
        }
    }
}
