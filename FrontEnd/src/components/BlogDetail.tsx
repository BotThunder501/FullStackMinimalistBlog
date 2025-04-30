import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { getBlogPostById } from '../services/blogService';
import { BlogPostDetail } from '../types';

interface RouteParams {
    [key: string]: string | undefined; // Add index signature
    id?: string; // Keep the specific property
}

// This component fetches and displays the details of a specific blog post
const BlogDetail: React.FC = () => {
    const { id } = useParams<RouteParams>();
    const [post, setPost] = useState<BlogPostDetail | null>(null);
    const [loading, setLoading] = useState<boolean>(true);

    // Fetches the blog post details when the component mounts or when the ID changes
    useEffect(() => {
        const fetchPost = async () => {
            if (!id) return;

            try {
                const data = await getBlogPostById(parseInt(id, 10));
                setPost(data);
            } catch (error) {
                console.error("Error fetching post details:", error);
            } finally {
                setLoading(false);
            }
        };
        fetchPost();
    }, [id]);

    // If loading, show a loading message
    if (loading) return <p>Loading...</p>;
    // If no post found, show a not found message
    if (!post) return <p>Post not found</p>;

    // Creates the blog detail view and displays the comments if any
    return (
        <div className="blog-detail">
            <Link to="/">← Back to Posts</Link>
            <h1>{post.title}</h1>
            <p className="date">Published: {new Date(post.publishedOn).toLocaleDateString()}</p>
            <div className="blog-content">{post.body}</div>

            <h2>Comments ({post.comments.length})</h2>
            {post.comments.map(comment => (
                <div key={comment.commentID} className="comment">
                    <p>{comment.comment}</p>
                    <p className="comment-date">
                        {new Date(comment.commentedOn).toLocaleDateString()}
                    </p>
                </div>
            ))}
        </div>
    );
};

export default BlogDetail;