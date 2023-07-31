using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterunitOfwork.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}