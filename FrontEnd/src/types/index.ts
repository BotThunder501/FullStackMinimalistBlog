// This file contains the types for the blog post and comment data
export interface BlogPostList {
    blogPostID: number;
    title: string;
    publishedOn: string;
    commentCount: number;
}

export interface BlogComment {
    commentID: number;
    comment: string;
    commentedOn: string;
}

export interface BlogPostDetail {
    blogPostID: number;
    title: string;
    body: string;
    publishedOn: string;
    comments: BlogComment[];
}