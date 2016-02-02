<%@ Page Title="Playlist details"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Details.aspx.cs"
    Inherits="YouTubePlaylistsSystem.Web.App.Playlists.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default text-center" style="width:600px;margin-left:auto;margin-right:auto">
        <div class="panel-heading">
            <h2>Playlist details</h2>
        </div>
        <div class="panel-body">
            <asp:DetailsView runat="server"
                ID="PrjectDetailsView"
                AutoGenerateRows="false"
                ItemType="YouTubePlaylistsSystem.Data.Models.Playlist"
                SelectMethod="PrjectDetailsView_GetItem"
                CssClass="table table-striped table-hover">
                <Fields>
                    <asp:BoundField HeaderText="Title" HeaderStyle-Font-Bold="true" DataField="Title" />
                    <asp:BoundField HeaderText="Description" HeaderStyle-Font-Bold="true" DataField="Description" />
                    <asp:BoundField HeaderText="Creation date" HeaderStyle-Font-Bold="true" DataField="CreationDate" DataFormatString="{0:F}" />
                    <asp:BoundField HeaderText="Category" HeaderStyle-Font-Bold="true" DataField="Category.Name" />
                    <asp:TemplateField HeaderText="Created by">
                        <ItemTemplate>
                            <%#: Item.Creator.FirstName + " " + Item.Creator.LastName %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div>
    </div>
    <div class="panel panel-default text-center" style="width:600px;margin-left:auto;margin-right:auto">
        <div class="panel-heading">
            <h2>Playlist videos</h2>
        </div>
        <div class="panel-body">
            <asp:Repeater runat="server"
                ID="VideosRepeater"
                ItemType="YouTubePlaylistsSystem.Data.Models.Video"
                SelectMethod="VideosRepeater_GetData">
                <ItemTemplate>
                    <div>
                        <iframe width="560" height="315" src='<%#: this.UrlHelper.GetEmbeddedUrl(Item.Url) %>'></iframe>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
