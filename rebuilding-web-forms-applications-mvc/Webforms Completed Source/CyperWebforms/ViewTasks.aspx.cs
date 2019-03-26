using CypherWebforms.Data;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace CyperWebforms
{
    public partial class ViewTasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new FeedbackContext();
            ViewTasksRepeater.DataSource = context.Tasks.ToList();
            ViewTasksRepeater.DataBind();
        }
    }
}