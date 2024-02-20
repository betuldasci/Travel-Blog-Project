using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; } 

        public virtual Role Role { get; set; } 

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}