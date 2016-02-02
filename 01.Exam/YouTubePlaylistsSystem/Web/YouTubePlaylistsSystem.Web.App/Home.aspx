<%@ Page Title="Home"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Home.aspx.cs"
    Inherits="YouTubePlaylistsSystem.Web.App.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1>Welcome to the YouTube Playlist System</h1>
        <p class="lead">Collect all your favourite videos and share them</p>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default text-center">
            <div class="panel-heading">
                <h3><strong>Top 10 most rated playlists</strong></h3>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TopPlaylists" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView runat="server"
                            ID="TopPlaylistsGridView"
                            CssClass="table table-striped table-hover"
                            AutoGenerateColumns="false"
                            ItemType="YouTubePlaylistsSystem.Data.Models.Playlist"
                            SelectMethod="TopPlaylistsGridView_GetData">
                            <Columns>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" Text='<%#: Item.Title %>' NavigateUrl='<%#: "~/Playlists/Details?PlaylistId=" + Item.Id %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" Text='<%#: Item.Category.Name %>' NavigateUrl='<%#: "~/Playlists/All?GategoryId=" + Item.CategoryId %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CreationDate" HeaderText="Date Created" DataFormatString="{0:F}" />
                                <asp:TemplateField HeaderText="Created by">
                                    <ItemTemplate>
                                        <%#: Item.Creator.FirstName + " " + Item.Creator.LastName %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%#: (((double)Item.RatingsReceived.Aggregate(0, (sum, element) => sum + element.Value) / (Item.RatingsReceived.Count < 1 ? 1: Item.RatingsReceived.Count))).ToString("0.0") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <asp:Timer runat="server" ID="TopPlaylists" Interval="600000" />
    </div>
</asp:Content>
