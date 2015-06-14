using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliobabel.Domain.Models
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
