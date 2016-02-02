namespace YouTubePlaylistsSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Helpers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<YouTubePlaylistsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(YouTubePlaylistsSystemDbContext context)
        {
            var seedHelper = new SeedHelper();
            var random = new Random();

            /* Seed data */
            var roleStore = new RoleStore<IdentityRole>(context);
            var userStore = new UserStore<User>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userManager = new UserManager<User>(userStore);

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 5,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            string adminUserName = "admin@site.com";

            if (userManager.FindByName(adminUserName) == null)
            {
                /* Seed users and roles */
                string adminRoleName = "Administrator";
                string userRoleName = "User";

                var adminRole = new IdentityRole
                {
                    Name = adminRoleName
                };

                var userRole = new IdentityRole
                {
                    Name = userRoleName
                };

                roleManager.Create(adminRole);
                roleManager.Create(userRole);

                var admin = new User
                {
                    FirstName = "Administrator",
                    LastName = "Administrator",
                    UserName = adminUserName,
                    ProfileImageUrl = "~/Images/default.jpg",
                    Email = adminUserName
                };

                string adminPassword = "admin";

                string userPasswordBeginning = "user";
                IdentityResult adminIdentityResult = userManager.Create(admin, adminPassword);
                User dbAdmin = userManager.FindByEmail(admin.Email);
                userManager.AddToRole(dbAdmin.Id, adminRoleName);

                for (int i = 0; i < 5; i++)
                {
                    User user = seedHelper.GetUser();
                    user.Email = string.Concat("user" + (i + 1), "@site.com");
                    user.UserName = user.Email;

                    IdentityResult identityResult = userManager
                        .Create(user, string.Concat(userPasswordBeginning, (i + 1)));
                    User dbUser = userManager.FindByName(user.UserName);
                    userManager.AddToRole(dbUser.Id, userRoleName);
                }

                /* Seed categories */
                for (int i = 0; i < 30; i++)
                {
                    Category category = seedHelper.GetCategory(i + 1);
                    context.Categories.AddOrUpdate(c => c.Name, category);
                }

                context.SaveChanges(); // Save categories into db

                /* Seed playlists, videos and ratings */
                var videosSeeded = new List<Video>();

                for (int i = 0; i < 20; i++)
                {
                    Playlist playlist = seedHelper.GetPlaylist(i + 1);

                    Category chosenCategory = context.Categories.OrderBy(c => Guid.NewGuid()).First();
                    User chosenCreator = context.Users.OrderBy(u => Guid.NewGuid()).First();

                    playlist.Category = chosenCategory;
                    playlist.Creator = chosenCreator;

                    for (int j = 0; j < 5; j++)
                    {
                        Video videoToSeed = seedHelper.GetVideo();
                        Video videoFromAlreadySeeded = videosSeeded.FirstOrDefault(v => v.Url == videoToSeed.Url);
                        if (videoFromAlreadySeeded != null)
                        {
                            playlist.Videos.Add(videoFromAlreadySeeded);
                        }
                        else
                        {
                            playlist.Videos.Add(videoToSeed);
                            videosSeeded.Add(videoToSeed);
                        }
                    }

                    List<User> usersWhoHaveRatedThisPlaylist = context.Users.OrderBy(u => Guid.NewGuid()).Take(count: 5).ToList();
                    for (int j = 0; j < 5; j++)
                    {
                        Rating rating = seedHelper.GetRating();
                        rating.User = usersWhoHaveRatedThisPlaylist[j];
                        rating.Playlist = playlist;
                        context.Ratings.Add(rating);
                    }
                }
            }
            
            context.SaveChanges();
        }
    }
}
