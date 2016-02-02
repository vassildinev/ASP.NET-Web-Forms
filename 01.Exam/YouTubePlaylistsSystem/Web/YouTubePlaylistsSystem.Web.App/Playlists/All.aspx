<%@ Page
    Title="Playlists"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="All.aspx.cs"
    Inherits="YouTubePlaylistsSystem.Web.App.Playlists.All" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="SearchTextBox" placeholder="Search by title or desc"></asp:TextBox>
    <asp:Button runat="server" OnClick="SearchClick" Text="Search" CssClass="btn btn-default btn-raised" />
    <asp:GridView runat="server" ID="AllPlaylistsGridView"
        CssClass="table table-striped table-hover"
        ItemType="YouTubePlaylistsSystem.Data.Models.Playlist"
        AllowPaging="true"
        AllowSorting="true"
        PageSize="10"
        AutoGenerateColumns="false"
        SelectMethod="AllPlaylistsGridView_GetData">
        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text='<%#: Item.Title %>' NavigateUrl='<%#: "~/Playlists/Details?PlaylistId=" + Item.Id %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text='<%#: Item.Category.Name %>' NavigateUrl='<%#: "~/Playlists/All.aspx?CategoryId=" + Item.CategoryId %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField HeaderText="Date created" DataField="CreationDate" SortExpression="CreationDate" DataFormatString="{0:F}" />
            <asp:TemplateField HeaderText="Created by">
                <ItemTemplate>
                    <%#: Item.Creator.FirstName + " " + Item.Creator.LastName %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Videos">
                <ItemTemplate>
                    <%#: Item.Videos.Count %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rating" SortExpression="">
                <ItemTemplate>
                    <%#: (Item.RatingsReceived.Aggregate(0, (sum, item) => sum + item.Value) / (Item.RatingsReceived.Count < 1 ? 1: Item.RatingsReceived.Count)).ToString("0.0") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
