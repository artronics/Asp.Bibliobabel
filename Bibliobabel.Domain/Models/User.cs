using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bibliobabel.Domain.Models
{
    public class User : IdentityUser<long, MyUserLogin, MyUserRole, MyUserClaim>
    {
        public Comment Comment { get; set; }
        public List<Post> Posts { get; set; }
        public UserProfile UserProfile { get; set; }

        #region GenerateUserIdentityAsync

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, long> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }

        #endregion

    }

    #region DO NOT CHANGE: Custom implementation of Asp.Identity

    public class MyUserRole : IdentityUserRole<long>
    {
    }

    public class MyUserClaim : IdentityUserClaim<long>
    {
    }

    public class MyUserLogin : IdentityUserLogin<long>
    {
    }

    public class MyRole : IdentityRole<long, MyUserRole>
    {
        public MyRole()
        {
        }

        public MyRole(string name)
        {
            Name = name;
        }
    }

    #endregion
}