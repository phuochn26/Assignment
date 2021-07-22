import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './css/Post.css'

const PostDetailPage = () => {

    const [isLoading, setLoading] = useState(true);
    const [post, setPost] = useState({
        id: null,
        title: null,
        body: null
    });

    useEffect(() => {
        axios.get(`https://jsonplaceholder.typicode.com/posts/1`).then(response => {
            console.log(response);
            setLoading(false);
            setPost({
                id: response.data.id,
                title: response.data.title,
                body: response.data.body
            });
        })
            .catch(error => {
                console.log(error);
            })
    }, []);

    if (isLoading) return <div>Loading</div>

    return (
        <div>
            <div>{post.id}</div>
            <div>{post.title}</div>
            <div>{post.body}</div>
        </div>
    )
}

export default PostDetailPage;