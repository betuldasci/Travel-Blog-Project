using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog3.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public string CommentContent { get; set; }
        public bool IsStatus { get; set; }

        public Comment()
        {
            // IsStatus varsayılan olarak true olarak ayarlanır
            this.IsStatus = true;
        }

    }
}