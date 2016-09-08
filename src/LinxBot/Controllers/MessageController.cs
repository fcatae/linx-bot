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

                var message = activity.CreateReply("Hello");

                client.Conversations.ReplyToActivity(message);
            }
        }
    }
}
