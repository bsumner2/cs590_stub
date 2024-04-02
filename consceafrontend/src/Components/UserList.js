import React, { useState, useEffect } from 'react'

const UserList = ( ) => {
    const [users, setUsers] = useState([])

    useEffect(() => {
        fetch('apiEndpoint')
            .then(response => response.json())
            .then(data => setUsers(data))
            .catch(error => console.error('Error fetching users:', error))
    }, [])

    return (
        <div>
            {/* Display the fetched user data */}
            {users.map(user => (
                <div key={user.id}>{user.name}</div>
            ))}
        </div>
    )
}

