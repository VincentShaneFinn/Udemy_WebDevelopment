using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CypherMVC.Models
{
    public class Vote
    {

        [Key, ForeignKey("Admin")]
        public int VoteId { get; set; }
        public int VoteCount { get; set; }

        public Admin Admin { get; set; }
    }
}