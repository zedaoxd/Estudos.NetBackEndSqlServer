using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Blog.models
{
    [Table("[Tag]")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        
        [Write(false)]
        public List<Post> Posts { get; set; }
    }
}