<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTask.aspx.cs" Inherits="CyperWebforms.CreateTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div id="page-wrapper">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                Create a New Task<br />
                <small>These are issues your team members should take care of - ASAP!</small>
            </h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-md-12">
                <div class="form-group">
                    <label>Title</label>
                    <asp:TextBox ID="Subject" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="error-message" ID="SubjectValidator" Display="Dynamic"  ControlToValidate="Subject" runat="server" ErrorMessage="Field is required."></asp:RequiredFieldValidator>
                </div>
                
                <div class="form-group">
                    <label>Description</label>
                    <asp:TextBox ID="Description" runat="server" CssClass="form-control"></asp:TextBox> 
                    <asp:RequiredFieldValidator CssClass="error-message" ID="DescriptionValidator" Display="Dynamic"  ControlToValidate="Description"  runat="server" ErrorMessage="Field is required."></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Category</label>
                    <asp:DropDownList CssClass ="form-control" runat="server" ID="Category"></asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="error-message" ID="CategoryValidator" Display="Dynamic"  runat="server" ControlToValidate="Category"  ErrorMessage="Field is required."></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Due Date</label>
                    <asp:TextBox ID="DueDate" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="error-message" ID="DueDateValidator" Display="Dynamic"  runat="server" ControlToValidate="DueDate"  ErrorMessage="Field is required."></asp:RequiredFieldValidator>
                    <asp:CustomValidator CssClass="error-message" OnServerValidate="ValidDate" ControlToValidate="DueDate"  ID="DateValidator" runat="server" ErrorMessage="Invalid Date!"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <label>Assigned To</label>
                    <asp:DropDownList ID="AssignedTo" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="error-message" ID="AssignedToValidator" Display="Dynamic"  runat="server" ControlToValidate="AssignedTo"  ErrorMessage="Field is required."></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Associated Message</label>
                    <asp:TextBox ID="AssociatedMessage" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="error-message" ID="AssociatedMessageValidator" Display="Dynamic"  runat="server" ControlToValidate="AssociatedMessage"  ErrorMessage="Field is required."></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Notes</label>
                    <asp:TextBox Rows="5" TextMode="MultiLine" ID="Notes" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="error-message" ID="NotesValidator" Display="Dynamic" runat="server" ControlToValidate="Notes" ErrorMessage="Field is required."></asp:RequiredFieldValidator>
                    <asp:CustomValidator CssClass="error-message" OnServerValidate="MaxText" ControlToValidate="Notes"  ID="MaxCharacterValidator" runat="server" ErrorMessage="500 character limit!"></asp:CustomValidator>
                </div>
            
                <div class="form-group">
                    <label>Is Complete</label>
                    <asp:CheckBox ID="IsComplete" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button Text="Submit" runat="server" CssClass="btn btn-primary pull-right" />
                </div>
        </div>
        <!-- /#page-wrapper -->
    </div>
</div>
</asp:Content>
