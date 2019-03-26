<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTasks.aspx.cs" Inherits="CyperWebforms.ViewTasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Listed below are tasks that should be completed by staff.</small>
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
                            <th>Title</th>
                            <th>Description</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="ViewTasksRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Title") %></td>
                                    <td><%# Eval("Description") %></td>
                                    <td><%# Eval("Created") %></td>
                                    <td><a class="btn btn-primary" href="CreateTask?TaskId=<%# Eval("Id") %>">Reply</a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
