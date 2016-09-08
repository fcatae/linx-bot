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
        [HttpPost]
        public void Post([FromBody] Activity activity)
        {
            if(activity.Type == ActivityTypes.Message)
            {
                var client = new ConnectorClient(new Uri(activity.ServiceUrl));

                var text = activity.Text.Trim();
                string output = null;

                var bot = new SmartBot();

                // Ola!
                if(text.EndsWith("!"))
                {
                    bot.Reset();
                    output = $"Olá {activity.From.Name}!";
                }
                    
                if( output != null )
                {
                    var message = activity.CreateReply(output);

                    client.Conversations.ReplyToActivity(message);
                }
            }
        }
    }
}
