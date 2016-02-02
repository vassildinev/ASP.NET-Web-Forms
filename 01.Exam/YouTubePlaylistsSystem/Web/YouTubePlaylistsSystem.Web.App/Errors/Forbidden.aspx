<%@ Page 
    Title="" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Forbidden.aspx.cs" 
    Inherits="YouTubePlaylistsSystem.Web.App.Errors.Forbidden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-center alert alert-danger">
        <strong style="font-size: 40px">Oh, snap!</strong>
        <br />
        <strong style="font-size: 30px">Access forbidden</strong>
    </p>
</asp:Content>
