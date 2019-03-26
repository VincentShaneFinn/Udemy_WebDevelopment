using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyperWebforms
{
    public partial class SuggestionWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Suggestion_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                var message = Suggestion.Text;
                //send email
                //other tasks
                Suggestion.Text = "";
            }
        }
    }
}