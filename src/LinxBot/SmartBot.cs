using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinxBot
{
    public interface ISmartBot
    {
        void Reset();
        string AskQuestion(string question);
        void SetLink(string link);
        void DefineQuestion(string question);
        void SetCategory(string question);
    }

    public class SmartBot : ISmartBot
    {
        Repository _repository;
        QuestionRepository _qrepository;

        int _currentArticleId = 0;
        string _currentCategory;

        public SmartBot(IRepository repository, IQuestionRepository qrepository)
        {
            this._repository = (Repository)repository;
            this._qrepository = (QuestionRepository)qrepository;
        }

        public void Reset()
        {
        }

        public string AskQuestion(string question)
        {
            if (question.Length < 4 || question.Contains("??"))
            {
                return "Você está buscando sobre Website, Pagamento ou Newsletter?";
            }


            string[] keywords = question.Trim(' ', '?')
                                        .Split(' ')
                                        .Where(k => k.Length > 2)
                                        .ToArray();

            var questions = new List<Article>(_qrepository.FindQuestion(keywords));
            var articles = new List<Article>(_repository.FindArticle(keywords));

            if( question == "luis?" )
            {
                return "Language Understanding: http://dialogice2.cloudapp.net/";
            }

            if( questions.Count == 0 && articles.Count == 0 )
            {
                if (question.Contains("javascript"))
                {
                    _currentCategory = "programação";
                }

                if( _currentCategory != null )
                {
                    return $"Você está buscando sobre {_currentCategory}. O que deseja saber?";
                }

                return $"Não encontrei artigos";
            }
            
            if(questions.Count > 0)
            {
                string link = questions[0].Link;

                if (link.StartsWith("category://"))
                {
                    string category = link.Substring("category://".Length);

                    return $"Você está buscando sobre {category}. O que deseja saber?";
                }

                return $"Encontrei esse link {link}";
            }

            return $"Encontrei {articles.Count} artigos. Veja esse link {articles[0].Link}";
        }

        public void SetLink(string link)
        {
            var article = _repository.FindArticleByUrl(link);

            if( article == null )
            {
                if (!link.StartsWith("category://"))
                    throw new InvalidOperationException("Invalid link");

                string category = link.Substring("category://".Length);

                var articleCategory = new Article()
                {
                    Link = "category://" + category,
                    Categories = new string[] { },
                    Content = "",
                    PostType = "st_kb",
                    Title = "category://" + category
                };

                _repository.Save(articleCategory);

                article = articleCategory;
            }

            _currentArticleId = article.Id;
            //_currentCategory = null;
        }

        public void DefineQuestion(string text)
        {
            var question = new Question()
            {
                ArticleId = _currentArticleId,
                Text = text,
                Tags = _currentCategory
            };

            _qrepository.Save(question);
        }
        
        public void SetCategory(string category)
        {
            _currentCategory = category;
        }
    }
}
