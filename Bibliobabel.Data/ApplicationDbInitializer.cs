using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bibliobabel.Domain.Models;
using Microsoft.AspNet.Identity;

namespace Bibliobabel.Data
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
           
            //var manager = new ApplicationUserManager(new MyUserStore(context));
            //manager.Create(
            //    new User()
            //    {
            //        Email = "jh_topgraph@yahoo.com", 
            //        UserName = "jh_topgraph@yahoo.com",
            //        UserProfile = new UserProfile() { AboutMe = "My name is Jalal.",Name = "Seyed Jalal Hosseini"}
            //    }, "qqqqqq");
            base.Seed(context);
        }
    }
}