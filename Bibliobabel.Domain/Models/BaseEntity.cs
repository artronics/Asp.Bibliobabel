using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliobabel.Domain.Models
{
    public abstract class BaseEntity
    {
        //protected BaseEntity()
        //{
        //    CreatedAt=DateTime.UtcNow;
        //}
        public long Id { get; set; }  
        //public DateTime CreatedAt { get; set; }  
        //public DateTime? UpdatedAt { get; set; }
    }
}