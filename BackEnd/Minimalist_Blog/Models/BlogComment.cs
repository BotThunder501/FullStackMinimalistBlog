namespace Minimalist_Blog.Models
{
    public class BlogComment
    {
        // This class represents a comment on a blog post.
        public int CommentID { get; set; }
        public int BlogPostID { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CommentedOn { get; set; }

        // Navigation property to represent the relationship with the blog post.
        public BlogPost? BlogPost { get; set; }
    }
}