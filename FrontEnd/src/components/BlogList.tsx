import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getBlogPosts } from '../services/blogService';
import { BlogPostList } from '../types';

// This component fetches and displays a list of blog posts
const BlogList: React.FC = () => {
    const [posts, setPosts] = useState<BlogPostList[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    // Fetches the list of blog posts when the component mounts
    useEffect(() => {
        const fetchPosts = async () => {
            try {
                const data = await getBlogPosts();
                setPosts(data);
            } catch (error) {
                console.error("Error fetching posts:", error);
            } finally {
                setLoading(false);
            }
        };
        fetchPosts();
    }, []);

    // If loading, show a loading message
    if (loading) return <p>Loading...</p>;

    // Creates a list of blog posts
    return (
        <div className="blog-list">
            <h1>Blog Posts</h1>
            {posts.map(post => (
                <div key={post.blogPostID} className="blog-card">
                    <h2><Link to={`/posts/${post.blogPostID}`}>{post.title}</Link></h2>
                    <p>Published: {new Date(post.publishedOn).toLocaleDateString()}</p>
                    <p>Comments: {post.commentCount}</p>
                </div>
            ))}
        </div>
    );
};

export default BlogList;