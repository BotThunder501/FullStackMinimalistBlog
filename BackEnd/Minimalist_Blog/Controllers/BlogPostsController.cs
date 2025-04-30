using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimalist_Blog.Data;
using Minimalist_Blog.Models.DTOs;


namespace Minimalist_Blog.Controllers
{
    // This controller handles HTTP requests related to blog posts.
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        // The database context used to interact with the database.
        private readonly BlogDbContext _context;

        // Constructor that accepts the BlogDbContext and assigns it to the private field.
        public BlogPostsController(BlogDbContext context)
        {
            _context = context;
        }

        // This action method retrieves a list of blog posts with their details.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostListDto>>> GetBlogPosts()
        {
            // Check if there are any posts in the database.
            var posts = await _context.BlogPosts
                .Select(p => new BlogPostListDto
                {
                    BlogPostID = p.BlogPostID,
                    Title = p.Title,
                    PublishedOn = p.PublishedOn,
                    CommentCount = p.Comments.Count
                })
                .OrderByDescending(p => p.PublishedOn)
                .ToListAsync();

            // If no posts are found, return a 404 Not Found response.
            return posts;
        }

        // This action method retrieves a specific blog post by its ID, including its comments.
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDetailDto>> GetBlogPost(int id)
        {
            // Check if the post with the given ID exists in the database.
            var post = await _context.BlogPosts
                .Where(p => p.BlogPostID == id)
                .Select(p => new BlogPostDetailDto
                {
                    BlogPostID = p.BlogPostID,
                    Title = p.Title,
                    Body = p.Body,
                    PublishedOn = p.PublishedOn,
                    Comments = p.Comments.Select(c => new BlogCommentDto
                    {
                        CommentID = c.CommentID,
                        Comment = c.Comment,
                        CommentedOn = c.CommentedOn
                    }).OrderByDescending(c => c.CommentedOn).ToList()
                })
                .FirstOrDefaultAsync();

            // If the post is not found, return a 404 Not Found response.
            if (post == null)
            {
                return NotFound();
            }

            // Return the post details as a response.
            return post;
        }
    }
}