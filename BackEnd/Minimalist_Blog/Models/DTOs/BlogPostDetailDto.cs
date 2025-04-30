namespace Minimalist_Blog.Models.DTOs
{
    public class BlogPostDetailDto
    {
        // This class is used to represent the details of a blog post, including its comments.
        public int BlogPostID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime PublishedOn { get; set; }
        public List<BlogCommentDto> Comments { get; set; } = new List<BlogCommentDto>();
    }
}