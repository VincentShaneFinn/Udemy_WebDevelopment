using CypherWebforms.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyperWebforms
{
    public partial class ViewMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new FeedbackContext();
            var latestMessages = context.Threads
                    .SelectMany(x => x.Messages).OrderByDescending(c => c.Created).ToList()
                    .GroupBy(y => y.MessageThreadId).Select(grp => grp.FirstOrDefault()).ToList();
            ViewMessagesRepeater.DataSource = latestMessages;
            ViewMessagesRepeater.DataBind();
        }

        protected void ViewMessagesRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}