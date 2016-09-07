using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using LinxBot;

namespace Linx.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void Save_Articles()
        {
            var repository = new Repository(Tests.DATABASE);

            Article article = new Article()
            {
                Id = 0,
                Title = "title",
                Content = "content",
                Link = "http://link",
                PostType = "test",
                Categories = new string[] { "cat1", "cat2"}
            };

            int ret = repository.Save( article );

            Assert.True(ret > 0);
        }

        [Fact]
        public void Truncate_Articles()
        {
            var repository = new Repository(Tests.DATABASE);

            repository.Truncate();
        }

        [Fact]
        public void Find_Article_Using_Keywords()
        {
            var repository = new Repository(Tests.DATABASE);

            var ret = new List<Article>(repository.FindArticle(new string[] { "template", "html" }));

            Assert.True(ret.Count > 0);
        }
    }
}
