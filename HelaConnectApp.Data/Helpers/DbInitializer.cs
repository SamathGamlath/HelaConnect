using HelaConnectApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelaConnectApp.Data.Helpers
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext appDbContext) 
        {
            if (!appDbContext.Users.Any() && !appDbContext.Posts.Any())
            {
                var newUser = new User()
                {
                    FullName = "Samath Gamlath",
                    ProfilePictureUrl = "https://media.licdn.com/dms/image/v2/D5603AQGXgxz1t2FuFw/profile-displayphoto-shrink_200_200/profile-displayphoto-shrink_200_200/0/1701667931397?e=1740614400&v=beta&t=E_4gh3skgvXGIO16aoMt1Fqc681zl-1kQTLa_4uf_nU"


                };
                 await appDbContext.Users.AddAsync(newUser);
                await appDbContext.SaveChangesAsync();
                var newPostWithoutImage = new Post()
                {
                    Content = "This is going to be our first post which is being loaded from the database and it has been created using our test user.",
                    ImageUrl = "",
                    NrOfReports = 0,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    UserId = newUser.Id
                };
                var newPostWithImage = new Post()
                {
                    Content = "This is going to be our first post which is being loaded from the database and it has been created using our test user. This post has an image",
                    ImageUrl = "https://media.licdn.com/dms/image/v2/D5603AQGXgxz1t2FuFw/profile-displayphoto-shrink_200_200/profile-displayphoto-shrink_200_200/0/1701667931397?e=1740614400&v=beta&t=E_4gh3skgvXGIO16aoMt1Fqc681zl-1kQTLa_4uf_nU",
                    NrOfReports = 0,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    UserId = newUser.Id
                };
                await appDbContext.Posts.AddRangeAsync(newPostWithoutImage, newPostWithImage);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
        
        
    

