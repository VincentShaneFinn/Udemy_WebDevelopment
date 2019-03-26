using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CypherMVC.Models
{
    public class ReplyVM
    {
        public virtual List<Message> Messages { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int MessageThreadId { get; set; }
    }
}