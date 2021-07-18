import React, { useState } from "react";

const LoginPage = () => {
    const [email, setEmail] = useState();
    const [password, setPassword] = useState();

    const handleEmail = () => {
        setEmail(email)
    }

    const handlePassword = () => {
        setPassword(password)
    }
    return (
        <form>
        <div>
            <div>
                <div><input type="Email" placeholder="Email" value={email} onChange={ handleEmail } style={{ marginTop:"10px" }} /></div>
                <div><input type="Password" placeholder="Password" value={password} onChange={ handlePassword } stype={{ marginTop:"10px" }} /></div>
            </div>
            <div>
                <button type="submit" stype={{ marginRight:"10px" }}>Submit</button>
            </div>
        </div>
        </form>
    );
}

export default LoginPage;