using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinxBot
{
    public class Question
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Text { get; set; }
        public string Tags { get; set; }
    }
}
