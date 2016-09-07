using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using LinxBot;

namespace Linx.Tests
{
    public class QuestionTests
    {
        [Fact]
        public void Create_Question()
        {
            var repository = new QuestionRepository(Tests.DATABASE);

            Question question = new Question()
            {
                ArticleId = 1,
                Text = "Como criar um post no wordpress?"
            };

            repository.Save(question);
        }

        [Fact]
        public void Associate_Known_Answer()
        {
            var articles = new Repository(Tests.DATABASE);

            int articleHotsite = articles.FindArticle(new string[] { "hotsite" }).Where( a => a.Title.StartsWith("Hotsite")).First().Id;

            var repository = new QuestionRepository(Tests.DATABASE);

            Question question = new Question()
            {
                ArticleId = articleHotsite,
                Text = "Como criar um template html?"
            };

            repository.Save(question);
        }

        [Fact]
        public void Find_Article_Using_Keywords()
        {
            var repository = new QuestionRepository(Tests.DATABASE);

            var ret = new List<Article>(repository.FindQuestion(new string[] { "template", "html" }));

            Assert.True(ret.Count > 0);
        }
    }
}
