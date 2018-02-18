using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicAPITestTask
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Post(int userId, int id, string title, string body)
        {
            Title = title;
            Body = body;
            Id = id;
            UserId = userId;
        }
    }
}
