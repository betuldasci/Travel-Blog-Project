using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog3.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<BlogCity> BlogCities { get; set; }
        public virtual ICollection<Blog> Blog { get; set; }

    }
}