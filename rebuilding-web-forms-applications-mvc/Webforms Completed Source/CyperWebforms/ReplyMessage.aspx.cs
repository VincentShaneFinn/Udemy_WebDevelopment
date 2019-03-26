using CypherWebforms.Data;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyperWebforms
{
    public partial class ReplyMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new FeedbackContext();

            int id;
            if (int.TryParse(Request.Params["MessageThreadId"], out id))
            {
                if (Page.IsPostBack)
                {
                    Page.Validate();

                    if (Page.IsValid)
                    {
                        var newMessage = new Message();
                        newMessage.Content = Reply.Text;
                        newMessage.Created = DateTime.Now;
                        newMessage.Author = HttpContext.Current.User.Identity.Name;
                        newMessage.MessageThreadId = int.Parse(Thread.Value);
                        newMessage.Subject = Subject.Value;

                        context.Messages.Add(newMessage);
                        context.SaveChanges();

                        Response.Redirect("ViewMessages.aspx");
                    }
                }

                var messages = context.Threads
                    .FirstOrDefault(x => x.MessageThreadId == id)
                    .Messages.OrderBy(x => x.Created).ToList();

                HeadingSubject.Text = messages.First().Subject;
                Thread.Value = messages.First().MessageThreadId.ToString();
                Subject.Value = messages.First().Subject;

                ReplyRepeater.DataSource = messages;
                ReplyRepeater.DataBind();
            }
            else
            {
                Response.Redirect("ViewMessages.aspx");
            }
        }
    }
}