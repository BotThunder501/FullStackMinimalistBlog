namespace Minimalist_Blog.Models.DTOs
{
    public class BlogCommentDto
    {
        // This class is used to represent a comment on a blog post.
        public int CommentID { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CommentedOn { get; set; }
    }
}