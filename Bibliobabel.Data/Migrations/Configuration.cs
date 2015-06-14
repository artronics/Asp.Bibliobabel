using System.Collections.Generic;
using Bibliobabel.Domain.Models;
using Microsoft.AspNet.Identity;
//using Bibliobabel.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bibliobabel.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bibliobabel.Data.ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationUserManager _userManager;
        public UserManager<User,long> UserManager { get; private set; }
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Bibliobabel.Data.UserIdentityDbContext";
            _context = new ApplicationDbContext();
            _userManager= new ApplicationUserManager(new MyUserStore(_context));
        }

        protected override void Seed(Bibliobabel.Data.ApplicationDbContext context)
        {
            //var users = CreateUsersWithProfiles(12);
            var users = CreateUsersWithProfile(5,3);
            //CreatePostsForUsers(users, 4);

            //foreach (var user in users)
            //{
            //    context.Users.Add(user);
            //}

            //context.SaveChanges();
        }

         
        

        private List<User> CreateUsersWithProfile(int numberOfUsers = 10, int numberOfPostsPerUser=5)
        {

            //var user = new User() { Email = "p@a.com", UserName = "p@a.com" };
            var users = new List<User>();
            //_userManager.Create(user, "111111");
            for (int i = 0; i < numberOfUsers; i++)
            {
                //email and username must be the same
                var email = Faker.Internet.Email();
                var user = new User
                {
                    Email = email,
                    UserName = email,
                    UserProfile = CreateProfile(),
                    Posts = CreatePosts(numberOfPostsPerUser),
                };

                var ressult = _userManager.Create(user, "qqqqqq");
                if (ressult.Succeeded)
                    users.Add(user);
                else
                    i--;
                if(i<0) throw new Exception("something wrong inside createuser method.");
            }
            return users;
        }

        private UserProfile CreateProfile()
        {
            return new UserProfile()
            {
                Name = Faker.Name.FullName(),
                AboutMe = Faker.Lorem.Paragraph(3),
            };
        }

        private List<Post> CreatePosts(int count)
        {
            var posts = new List<Post>();

            for (int i = 0; i < count; i++)
            {
                var post = new Post()
                {
                    Content = Faker.Lorem.Paragraph(3),
                };
                TimeStamps(post);

                posts.Add(post);
            }

            return posts;
        }

        //TODO : Implemet this method to create random DateTime for Entities
        private void TimeStamps(BaseEntity entity)
        {
            //entity.UpdatedAt=
            //entity.CreatedAt=
        }
    }


}
