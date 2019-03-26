<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CyperWebforms._Default" %>

<%@ Register Src="~/SurveyWidget.ascx" TagPrefix="uc1" TagName="SurveyWidget" %>
<%@ Register Src="~/SuggestionWidget.ascx" TagPrefix="uc1" TagName="SuggestionWidget" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Welcome to the Feedback Application!
                    <br />
                    <small>Here you can manage the messages and tasks for our customers.</small>
                </h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="panel panel-yellow">
                    <div class="panel-heading">
                        Latest Messages
                    </div>
                    <div class="panel-body">
                        <asp:SqlDataSource
                            ID="LatestMessagesSource"
                            runat="server"
                            ConnectionString="<%$ ConnectionStrings:CypherWebForms %>"
                            OnSelecting="LatestMessagesSource_Selecting"
                            SelectCommand="SELECT TOP 5 * FROM [Messages] ORDER BY [Created] DESC"></asp:SqlDataSource>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Author</th>
                                    <th>Subject</th>
                                    <th>Date</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="LatestMessages" runat="server" DataSourceID="LatestMessagesSource">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Author") %></td>
                                            <td><%#Eval("Subject") %></td>
                                            <td><%#Eval("Created") %></td>
                                            <td><a href="ReplyMessage.aspx?MessageThreadId=<%#Eval("MessageThreadId") %>">View</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                    </div>
                    <div class="panel-footer">
                        <a href="#" class="pull-right btn btn-primary">View All</a>
                        <span class="clearfix"></span>
                    </div>
                </div>
                <div class="panel panel-red">
                    <div class="panel-heading">
                        Admin Tasks
                    </div>
                    <div class="panel-body">
                        <asp:SqlDataSource
                            ID="TasksDataSource"
                            runat="server"
                            ConnectionString="<%$ ConnectionStrings:CypherMVCConnectionString %>"
                            SelectCommand="SELECT TOP 5 Title, Description Due Date From Tasks ORDER BY [Created] DESC"></asp:SqlDataSource>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Author</th>
                                    <th>Subject</th>
                                    <th>Date</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="ListView1" runat="server" DataSourceID="LatestMessagesSource">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Author") %></td>
                                            <td><%#Eval("Subject") %></td>
                                            <td><%#Eval("Created") %></td>
                                            <td><a href="#">View</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                    </div>
                    <div class="panel-footer">
                        <a href="#" class="pull-right btn btn-primary">View All</a>
                        <span class="clearfix"></span>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-sm-12">
                    <uc1:SurveyWidget runat="server" ID="SurveyWidget" />
                </div>
                <div class="col-sm-12">
                    <uc1:SuggestionWidget runat="server" ID="SuggestionWidget" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
