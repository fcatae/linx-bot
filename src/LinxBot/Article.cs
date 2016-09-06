using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinxBot
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public string PostType { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
