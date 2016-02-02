<%@ Page Title="Unauthorized" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Unauthorized.aspx.cs" 
    Inherits="YouTubePlaylistsSystem.Web.App.Errors.Unauthorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-center alert alert-danger">
        <strong style="font-size: 40px">Oh, snap!</strong>
        <br />
        <strong style="font-size: 30px">You are not authorized to see this page</strong>
    </p>
</asp:Content>
