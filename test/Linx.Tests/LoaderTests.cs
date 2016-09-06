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

            var items = new List<Article>(loader.Load(@"xml\rss.xml"));

            Assert.Equal(items.Count, 1);
            Assert.Equal(items[0].Title, "Installing WordPress");            
        }
    }
}
