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
            string[] keywords = question.Trim(' ', '?').Split(' ');

            var questions = new List<Article>(_qrepository.FindQuestion(keywords));
            var articles = new List<Article>(_repository.FindArticle(keywords));

            if( questions.Count == 0 && articles.Count == 0 )
            {
                return $"Não encontrei artigos";
            }
            
            if(questions.Count > 0)
            {
                return $"Encontrei esse link {questions[0].Link}";
            }

            return $"Encontrei {articles.Count} artigos. Veja esse link {articles[0].Link}";
        }

        public void SetLink(string link)
        {
            var article = _repository.FindArticleByUrl(link);

            if( article == null )
            {
                throw new InvalidOperationException("Invalid link");
            }

            _currentArticleId = article.Id;
        }

        public void DefineQuestion(string text)
        {
            var question = new Question()
            {
                ArticleId = _currentArticleId,
                Text = text
            };

            _qrepository.Save(question);
        }
        
        public void SetCategory(string question)
        {
        }
    }
}
