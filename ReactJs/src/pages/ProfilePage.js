import axios from 'axios';
import React, { useEffect, useState } from 'react';

const ProfilePage = ({ currentUser }) => {
    const [profile, setProfile] = useState({
        name: '',
        id: null,
        createAt: null
    })
    useEffect(() => {
        let didCancel = false;
        axios.get(`https://60dff0ba6b689e001788c858.mockapi.io/users/${currentUser.userId}`).then(response => {
            if (!didCancel) {
                setProfile({
                    name: response.data.name,
                    id: response.data.id,
                    createAt: response.data.createAt
                })
            }
        });

        return () => didCancel = true;
    }, [currentUser.userId, currentUser.token]);
    return (
        <div>
            <label>name: {profile.name}<br /></label>
            <label>userId: {profile.id}</label>
        </div>
    );
}

export default ProfilePage;