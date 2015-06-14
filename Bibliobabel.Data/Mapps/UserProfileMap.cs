using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Bibliobabel.Domain.Models;

namespace Bibliobabel.Data.Mapps
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            HasKey(p => p.Id);
            HasRequired(p => p.ProfileOf).WithRequiredDependent(u => u.UserProfile);
            ToTable("UserProfiles");

            Property(p => p.AboutMe).HasMaxLength(500);
            Property(p => p.Name).HasMaxLength(60);

            //Property(p => p.CreatedAt).IsRequired();
            //Property(p => p.UpdatedAt);
        }
    }
}