<%@ Page
    Title="Create a new playlist"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Create.aspx.cs"
    Inherits="YouTubePlaylistsSystem.Web.App.Playlists.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal col-md-10">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TitleTextBox" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TitleTextBox" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TitleTextBox"
                    CssClass="text-danger" ErrorMessage="The Title field is required." Display="None" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                    CssClass="text-danger" ErrorMessage="The Description field is required." Display="None" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CategorySelect" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-10">
                <asp:ListBox runat="server" ID="CategorySelect" CssClass="form-control" SelectionMode="Single" AutoPostBack="false" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Url" CssClass="col-md-2 control-label">First video url</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Url" CssClass="form-control" TextMode="Url" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Url"
                    CssClass="text-danger" ErrorMessage="The Url field is required." Display="None" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Create_Click" Text="Create" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
