import React, { useEffect, useState } from 'react';
import axios from 'axios';
import '../components/Post.css'

const PostDetailPage = () => {

    const [isLoading, setLoading] = useState(true);
    const [posts, setPosts] = useState({
        id: null,
        title: null,
        body: null
    });

    useEffect(() => {
        axios.get('https://jsonplaceholder.typicode.com/posts/1').then(response => {
            console.log(response);
            setLoading(false);
            setPosts({
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
            <div>{posts.id}</div>
            <div>{posts.title}</div>
            <div>{posts.body}</div>
        </div>
    )
}

export default PostDetailPage;