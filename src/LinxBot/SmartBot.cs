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
        public void Reset()
        {
        }

        public string AskQuestion(string question)
        {
            return "I don't know!";
        }

        public void SetLink(string link)
        {
        }

        public void DefineQuestion(string question)
        {
        }
        
        public void SetCategory(string question)
        {
        }
    }
}
