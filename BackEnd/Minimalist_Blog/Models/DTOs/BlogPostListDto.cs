namespace Minimalist_Blog.Models.DTOs
{
    public class BlogPostListDto
    {
        // This class is used to represent a summary of a blog post in the list view.
        public int BlogPostID { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedOn { get; set; }
        public int CommentCount { get; set; }
    }
}