using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bibliobabel.Domain.Models
{
    public class UserProfile:BaseEntity
    {
        public string Name { get; set; }
        public string AboutMe { get; set; }
        public virtual User ProfileOf { get; set; }
    }
}