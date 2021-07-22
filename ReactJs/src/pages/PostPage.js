import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './css/Post.css'
import {
    Link
  } from "react-router-dom";

const PostPage = () => {
    const [isLoading, setLoading] = useState(true);
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        axios.get('https://jsonplaceholder.typicode.com/posts').then(response => {
            setLoading(false);
            setPosts(response.data);
        })
            .catch(error => {
                console.log(error);
            })
    }, []);

    if (isLoading) return <div>Loading</div>

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Title</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {posts.map(post => (
                        <tr key={post.id}>
                            <td>{post.id}</td>
                            <td>{post.title}</td>
                            <td><Link to={"./post/" + post.id} >View Detail</Link></td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
};
export default PostPage;