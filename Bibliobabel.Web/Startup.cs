using System;
using Bibliobabel.Data;
using Bibliobabel.Domain.Models;
using Bibliobabel.Web.Areas.Api.Controllers;
using Bibliobabel.Web.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bibliobabel.Web.Startup))]
namespace Bibliobabel.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            Test();
        }

        private void Test()
        {
            //var profile = new UserProfile { AboutMe = "aboutme", CreatedAt = DateTime.Now ,UpdatedAt = DateTime.Now};
            //var user = new User {Username = "artronics",CreatedAt = DateTime.Now ,UpdatedAt = DateTime.Now,UserProfile = profile};
            //var post = new Post { Content = "first post artronci", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now};
            //using (var contex = new DataDbContext())
            //{
            //    contex.Users.Add(user);
            //    contex.Posts.Add(post);
            //    contex.SaveChanges();
            //}

        }
    }
}
