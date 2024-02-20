using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace TravelBlog3.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string ImageUrl { get; set; }
        public int LikeCount { get; set; }
        public int? CityId { get; set; }  
        public virtual City City { get; set; }
        public virtual ICollection<BlogCity> BlogCities { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public Blog()
        {
            this.Comments = new List<Comment>();
        }
    }
}