<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReplyMessage.aspx.cs" Inherits="CyperWebforms.ReplyMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-8">
                <h2>Reply To: <asp:Label ID="HeadingSubject" runat="server"></asp:Label></h2>
                <asp:Repeater ID="ReplyRepeater" runat="server">
                    <ItemTemplate>
                        <div class="thread-item">
                            <p><%# Eval("Author") %></p>
                            <p><%# Eval("Content") %></p>
                            <p><%# Eval("Created") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label>Reply Content</label>
                    <asp:TextBox ID="Reply" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReplyValidator" runat="server" CssClass="error-message" ControlToValidate="Reply" ErrorMessage="Field is Required"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="Subject" runat="server" />
                    <asp:HiddenField ID="Thread" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button  runat="server" CssClass="btn btn-primary pull-right" text="Submit" ID="ReplySubmit" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
