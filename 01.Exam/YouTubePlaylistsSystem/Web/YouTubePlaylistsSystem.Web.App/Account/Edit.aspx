<%@ Page Title="Edit Profile"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs"
    Inherits="YouTubePlaylistsSystem.Web.App.Account.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10">
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal col-md-10">
            <h4>Edit your information</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                        CssClass="text-danger" ErrorMessage="The First name field is required." Display="None" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="LastName" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                        CssClass="text-danger" ErrorMessage="The Last name field is required." Display="None" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FacebookAccountUrl" CssClass="col-md-2 control-label">Facebook Profile (optional)</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FacebookAccountUrl" CssClass="form-control" TextMode="Url" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="YouTubeAccountUrl" CssClass="col-md-2 control-label">YouTube Profile (optional)</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="YouTubeAccountUrl" CssClass="form-control" TextMode="Url" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Style="display: inline-block; margin-left: 150px; margin-right: auto" AssociatedControlID="ImageUpload" CssClass="col-md-4 btn btn-raised btn-primary">Change profile picture</asp:Label>
                <div class="col-md-2 hidden">
                    <asp:FileUpload runat="server" ID="ImageUpload" accept=".png,.jpg,.gif" />
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="EditUserClick" Text="Save changes" CssClass="btn btn-default" />
                <asp:Button runat="server" OnClick="CancelClick" Text="Cancel" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
