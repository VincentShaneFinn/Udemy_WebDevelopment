using CypherWebforms.Data;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyperWebforms
{
    public partial class CreateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new FeedbackContext();

            Category.DataSource = context.Categories.Select(x =>
                new ListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            Category.DataBind();

            AssignedTo.DataSource = context.Admins.Select(x =>
                new ListItem() { Text = x.Username, Value = x.Id.ToString() }).ToList();
            AssignedTo.DataBind();

            //Is this a create or update?
            if (!string.IsNullOrEmpty(Request.Params["TaskId"]))
            {
                var id = int.Parse(Request.Params["TaskId"]);
                var item = context.Tasks.FirstOrDefault(x => x.Id == id);

                Subject.Text = item.Title;
                Description.Text = item.Description;
                Category.SelectedIndex = item.Id;
                DueDate.Text = item.DueDate.ToShortDateString();
                AssociatedMessage.Text = item.AssociatedMessageId.ToString();
                Notes.Text = item.Notes;
                IsComplete.Checked = item.Completed;
            }


            if (Page.IsPostBack)
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    var task = new Task();
                    task.Title = Subject.Text;
                    task.CategoryId = int.Parse(Category.SelectedValue);
                    task.Description = Description.Text;
                    task.DueDate = DateTime.Parse(DueDate.Text);
                    task.AssignedToId = int.Parse(AssignedTo.Text);
                    task.AssociatedMessageId = int.Parse(AssociatedMessage.Text);
                    task.Notes = Notes.Text;
                    task.Completed = IsComplete.Checked;
                    context.Tasks.Add(task);
                    context.SaveChanges();
                }
            }
        }

        protected void ValidDate(object source, ServerValidateEventArgs args)
        {
            var date = new DateTime();
            if (DateTime.TryParse(args.Value, out date))
            {
                args.IsValid = !(date.Date < DateTime.Now.Date);
            }
            else
            {
                args.IsValid = false;
            }

        }

        protected void MaxText(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !(args.Value.Length > 500);
        }
    }
}