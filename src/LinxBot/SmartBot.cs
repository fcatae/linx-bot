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

        int _currentArticleId = 0;

        public SmartBot(IRepository repository)
        {
            this._repository = (Repository)repository;
        }

        public void Reset()
        {
        }

        public string AskQuestion(string question)
        {
            return "I don't know!";
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

        public void DefineQuestion(string question)
        {
        }
        
        public void SetCategory(string question)
        {
        }
    }
}
