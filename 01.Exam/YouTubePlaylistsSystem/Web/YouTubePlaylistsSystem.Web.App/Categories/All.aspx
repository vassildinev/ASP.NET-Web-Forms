<%@ Page
    Title="Categories"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="All.aspx.cs"
    Inherits="YouTubePlaylistsSystem.Web.App.Categories.All" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="CategoriesGridView"
        AllowPaging="true"
        CssClass="table table-hover table-striped"
        AutoGenerateColumns="false"
        ItemType="YouTubePlaylistsSystem.Data.Models.Category"
        AutoGenerateEditButton="true"
        SelectMethod="CategoriesGridView_GetData">
        <Columns>
            <asp:BoundField HeaderText="Id" HeaderStyle-Font-Bold="true" DataField="Id" />
            <asp:BoundField HeaderText="Name" HeaderStyle-Font-Bold="true" DataField="Name" />
            <asp:TemplateField HeaderText="Playlists" HeaderStyle-Font-Bold="true">
                <ItemTemplate>
                    <%#: Item.Playlists.Count %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
