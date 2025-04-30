// This file contains the API service for fetching blog posts and their details
import axios from 'axios';
import { BlogPostList, BlogPostDetail } from '../types';

// The API URL for the blog posts
const API_URL = 'http://localhost:5102/api';

// Calls the API to get the list of blog posts
export const getBlogPosts = async (): Promise<BlogPostList[]> => {
    const response = await axios.get<BlogPostList[]>(`${API_URL}/BlogPosts`);
    return response.data;
};

// Calls the API to get the details of a specific blog post by ID
export const getBlogPostById = async (id: number): Promise<BlogPostDetail> => {
    const response = await axios.get<BlogPostDetail>(`${API_URL}/BlogPosts/${id}`);
    return response.data;
};