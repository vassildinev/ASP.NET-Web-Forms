<%@ Page
    Title="Not found"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="NotFound.aspx.cs"
    Inherits="YouTubePlaylistsSystem.Web.App.Errors.NotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-center alert alert-danger">
        <strong style="font-size: 40px">Oh, snap!</strong>
        <br />
        <strong style="font-size: 30px">The resource you requested could not be found</strong>
    </p>
</asp:Content>
