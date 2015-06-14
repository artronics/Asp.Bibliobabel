using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Bibliobabel.Data.Mapps;
using Bibliobabel.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bibliobabel.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, MyRole, long, MyUserLogin, MyUserRole, MyUserClaim>, IDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            //  Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
            //Database.SetInitializer(new ApplicationDbInitializer());
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region  Models Configuration for implementation of BaseEntity abstract class
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            #endregion

            #region  Custom names for tables related to Asp.Identiy

            modelBuilder.Entity<User>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<MyUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<MyUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<MyUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<MyRole>().ToTable("Roles");

            #endregion

            modelBuilder.Entity<Comment>()
                //.HasKey(c=>c.Id)
                .HasRequired(c => c.CommentOf)
                .WithRequiredDependent(u => u.Comment);

        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    #region DO NOT CHANGE: Costume Implementation of Asp.Identity.

    //Here is my custome implementation of Asp.identity
    //This will change default primary key from string to long

    public class MyUserStore : UserStore<User, MyRole, long,
        MyUserLogin, MyUserRole, MyUserClaim>
    {
        public MyUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class MyRoleStore : RoleStore<MyRole, long, MyUserRole>
    {
        public MyRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    #endregion
}