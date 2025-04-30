namespace Minimalist_Blog.Models
{
    public class BlogPost
    {
        // This class represents a blog post with properties for ID, title, body, published date, and a list of comments.
        public int BlogPostID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime PublishedOn { get; set; }

        // Navigation property to represent the relationship with comments.
        public List<BlogComment> Comments { get; set; } = new List<BlogComment>();
    }
}