namespace YouTubePlaylistsSystem.Data.Helpers
{
    using System;

    using Models;

    public class SeedHelper
    {
        private readonly Random random = new Random();
        private readonly string[] firstNames =
        {
            "John",
            "Pesho",
            "Gosho",
            "Stamat",
            "Mitko",
            "Vasko",
            "Lubcho",
            "Tosho",
            "Jane",
            "Jack"
        };

        private readonly string[] lastNames = 
        {
            "Jones",
            "Petrov",
            "Ivanov",
            "Georgiev",
            "Dimitrov",
            "Smith",
            "Johnson",
            "Black",
            "Silver",
            "Brunson"
        };

        private readonly string[] videoUrls =
        {
            "https://www.youtube.com/watch?v=_xENDpb1Zr8",
            "https://www.youtube.com/watch?v=gFg8XEHVKOM",
            "https://www.youtube.com/watch?v=bZ_BoOlAXyk",
            "https://www.youtube.com/watch?v=YZ87d_Wqm9Y",
            "https://www.youtube.com/watch?v=Qk7UE65iGwk",
            "https://www.youtube.com/watch?v=n-2tbvRsCUA",
            "https://www.youtube.com/watch?v=tjDHD7xgKeg",
            "https://www.youtube.com/watch?v=pr-w6h9VSyI",
            "https://www.youtube.com/watch?v=WlCv_mFRHWg",
            "https://www.youtube.com/watch?v=nY3ztACkl6I"
        };

        public User GetUser()
        {
            string firstName = this.firstNames[this.random.Next(0, this.firstNames.Length)];
            string lastName = this.lastNames[this.random.Next(0, this.lastNames.Length)];
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                ProfileImageUrl = "~/Images/default.jpg",
                FacebookAccountUrl = "http://facebook.com",
                YouTubeAccountUrl = "http://youtube.com"
            };

            return user;
        }

        public Category GetCategory(int index)
        {
            return new Category()
            {
                Name = string.Concat("Category", index)
            };
        }

        public Video GetVideo()
        {
            var video = new Video()
            {
                Url = this.videoUrls[random.Next(0, this.videoUrls.Length)]
            };

            return video;
        }

        public Playlist GetPlaylist(int index)
        {
            return new Playlist()
            {
                Title = string.Concat("Playlist", index),
                Description = "The youtube playlist description",
                CreationDate = DateTime.Now
            };
        }

        public Rating GetRating()
        {
            return new Rating()
            {
                Value = random.Next(1, 6)
            };
        }
    }
}
