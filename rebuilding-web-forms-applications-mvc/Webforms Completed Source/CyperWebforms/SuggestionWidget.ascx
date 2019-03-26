<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuggestionWidget.ascx.cs" Inherits="CyperWebforms.SuggestionWidget" %>

<div class="panel panel-green widget">
    <div class="panel-heading">
        <div class="row">
            <div class="col-xs-3">
                <i class="fa fa-tasks fa-5x"></i>
            </div>
            <div class="col-xs-9 text-right">
                <h3>Continuous Improvement</h3>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-xs-12 feature-request">
                <p>Have a feature request or suggestion for how we can improve this app? Let us know! Send us a suggestion.</p>
                <asp:TextBox TextMode="MultiLine" Rows="5" ID="Suggestion" runat="server" CssClass="form-control"></asp:TextBox><br />
                <asp:Button runat="server" Text="Submit" CssClass="improvement btn btn-primary pull-right" OnClick="Suggestion_Click" />
            </div>
        </div>
    </div>
</div>
