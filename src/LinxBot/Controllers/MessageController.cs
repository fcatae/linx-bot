using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;

namespace LinxBot.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        ISmartBot _bot;

        public MessagesController(ISmartBot bot)
        {
            this._bot = bot;
        }

        [HttpPost]
        public void Post([FromBody] Activity activity)
        {
            if(activity.Type == ActivityTypes.Message)
            {
                var client = new ConnectorClient(new Uri(activity.ServiceUrl));

                var text = activity.Text.Trim();
                string output = null;

                // Ola!
                if (text.EndsWith("!"))
                {
                    _bot.Reset();
                    output = $"Olá {activity.From.Name}!";
                }
                else if (text.StartsWith("link:"))
                {
                    string link = text.Split(' ')[1];
                    _bot.SetLink(link);
                }
                else if (text.StartsWith("pergunta: "))
                {
                    string question = text.Substring("pergunta: ".Length);
                    _bot.DefineQuestion(question);
                }
                else if (text.StartsWith("busca em: "))
                {
                    string category = text.Substring("busca em: ".Length);
                    _bot.SetCategory(category);

                    output = $"Você está buscando em {category}. O que deseja saber?";
                }
                else if (text.EndsWith("?"))
                {
                    output = _bot.AskQuestion(text);
                }

                if ( output != null )
                {
                    var message = activity.CreateReply(output);

                    client.Conversations.ReplyToActivity(message);
                }
            }
        }
    }
}
