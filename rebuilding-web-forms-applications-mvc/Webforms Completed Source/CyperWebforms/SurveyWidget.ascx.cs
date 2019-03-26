using CypherWebforms.Data;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyperWebforms
{
    public partial class SurveyWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new FeedbackContext();
            var admins = context.Admins.ToList();

            if (Page.IsPostBack)
            {
                foreach(var radio in RadioVotes.Items)
                {
                    var item = (ListItem)radio;
                    if (item.Selected)
                    {
                        var admin = admins.FirstOrDefault(x => 
                        x.Username == item.Text);
                        admin.Votes.Add(new Vote() { AdminId = admin.Id });
                        var success = context.SaveChanges();
                        Session["HasVoted"] = true;
                    }
                }
            }

            if (Session["HasVoted"] != null)
            {
                SurveyPanel.Visible = false;
                ResultPanel.Visible = true;
                SurveyRepeater.DataSource = admins.OrderByDescending(x => 
                x.Votes.Count).Select(x => new {
                    Username = x.Username,
                    VoteCount = x.Votes.Count
                });
                SurveyRepeater.DataBind();
            }
            else
            {
                RadioVotes.CssClass = "table table-striped";
                RadioVotes.Items.Clear();
                foreach (var admin in admins)
                {
                    RadioVotes.Items.Add(admin.Username);
                }

            }
        }
    }
}