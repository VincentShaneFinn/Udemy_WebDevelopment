<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMessages.aspx.cs" Inherits="CyperWebforms.ViewMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Listed below are feedback messages we have received from customers.</small>
                </h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Subject</th>
                            <th>Message</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="ViewMessagesRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Subject") %></td>
                                    <td><%# Eval("Content") %></td>
                                    <td><%# Eval("Author") %></td>
                                    <td><%# Eval("Created") %></td>
                                    <td><a class="btn btn-primary" href="/ReplyMessage.aspx?MessageThreadId=<%# Eval("MessageThreadId") %>">Reply</a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
