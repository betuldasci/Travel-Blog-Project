using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog3.Models
{
    public class BlogCity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}