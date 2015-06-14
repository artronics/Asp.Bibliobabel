using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bibliobabel.Domain.Models;

namespace Bibliobabel.Domain.Models
{
    public class Comment:BaseEntity
    {
        //[Key]
        //[ForeignKey("CommentOf")]
        //public long Id { get; set; }
        //public long UserId { get; set; }
        public string Content { get; set; }
        public User CommentOf { get; set; }
        //public string Kir { get; set; }
        public string Loo { get; set; }
        //public IAppUser User { get; set; }
    }
}