﻿namespace YouTubePlaylistsSystem.Web.App
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<YouTubePlaylistsSystemDbContext, Configuration>());
        }
    }
}