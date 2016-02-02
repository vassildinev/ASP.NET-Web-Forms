<%@ Page
    Title="Profile"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs"
    Inherits="YouTubePlaylistsSystem.Web.App.Account.Profile" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default text-center" style="width: 400px; margin-left: auto; margin-right: auto">
        <div class="panel-heading">
            <h2>Profile details</h2>
        </div>
        <div class="panel-body">
            <div class="text-center" style="margin:10px;">
                <asp:Image runat="server" Id="ProfileImageUrl" Width="250" Height="250" />
            </div>
            <asp:DetailsView runat="server"
                ID="UserDetailsView"
                AutoGenerateRows="false"
                ItemType="YouTubePlaylistsSystem.Data.Models.User"
                SelectMethod="UserDetailsView_GetItem"
                CssClass="table table-striped table-hover">
                <Fields>
                    <asp:BoundField HeaderText="First name" HeaderStyle-Font-Bold="true" DataField="FirstName" />
                    <asp:BoundField HeaderText="Last name" HeaderStyle-Font-Bold="true" DataField="LastName" />
                    <asp:BoundField HeaderText="Username" HeaderStyle-Font-Bold="true" DataField="UserName" DataFormatString="{0:F}" />
                    <asp:BoundField HeaderText="Email" HeaderStyle-Font-Bold="true" DataField="Email" />
                    <asp:TemplateField HeaderText="Rating" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <%#: (Item.Playlists.SelectMany(p => p.RatingsReceived).Aggregate(0, (sum , item) => sum + item.Value)/(Item.Playlists.SelectMany(p => p.RatingsReceived).Count())).ToString("0.0") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Playlists" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Repeater runat="server" ID="UserPlaylistsRepeater"
                                ItemType="YouTubePlaylistsSystem.Data.Models.Playlist"
                                SelectMethod="UserPlaylistsRepeater_GetData">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" Text='<%#: Item.Title %>' NavigateUrl='<%#: "~/Playlists/Details?PlaylistId=" + Item.Id %>' />
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div>
    </div>
</asp:Content>
