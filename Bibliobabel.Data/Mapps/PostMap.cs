using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Bibliobabel.Domain.Models;

namespace Bibliobabel.Data.Mapps
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            HasKey(p => p.Id);
            HasRequired(p => p.User).WithMany(u => u.Posts);
            ToTable("Posts");

            Property(p => p.Content).IsRequired();

            //Property(p => p.CreatedAt).IsRequired();
            //Property(p => p.UpdatedAt);


        }
    }
}