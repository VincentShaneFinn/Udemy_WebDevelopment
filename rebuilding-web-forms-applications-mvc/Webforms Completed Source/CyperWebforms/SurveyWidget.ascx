<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyWidget.ascx.cs" Inherits="CyperWebforms.SurveyWidget" %>

<div class="panel panel-primary widget">
    <div class="panel-heading">
        <div class="row">
            <div class="col-xs-3">
                <i class="fa fa-comments fa-5x"></i>
            </div>
            <div class="col-xs-9 text-right">
                <h3>Rep of the Month</h3>
                <p>You can only vote once!</p>
            </div>
        </div>
    </div>
    <div class="widget-display">
        <asp:Panel ID="SurveyPanel" runat="server">
            <div class="col-xs-12">
                <asp:RadioButtonList ID="RadioVotes" runat="server"></asp:RadioButtonList>
                <asp:Button ID="VoteSubmit" runat="server" CssClass="btn btn-primary pull-right" Text="Vote " />
                <div style="clear: both; margin: 10px"></div><br />
            </div>
        </asp:Panel>
        <asp:Panel ID="ResultPanel" Visible="false" runat="server">
            <p>Thank you for your vote!</p>
            <table class="table table-fluid table-striped">
                <thead>
                    <tr>
                        <th>User</th>
                        <th>Votes</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="SurveyRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Username") %></td>
                                <td><%# Eval("VoteCount") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>
    </div>
</div>
