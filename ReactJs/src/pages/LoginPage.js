import React from "react";
import { Formik } from 'formik';
import './css/Login.css'
import axios from "axios";

const LoginPage = ({ currentUser, setCurrentUser }) => {
    console.log("currentUser =", currentUser)
    return (
        <div className="center">
            <h1>Login Form</h1>
            <Formik
                initialValues={{ email: '', password: '' }}
                validate={values => {
                    const errors = {};
                    if (!values.email) {
                        errors.email = 'Required';
                    } else if (
                        !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)
                    ) {
                        errors.email = 'Invalid email address';
                    }

                    if (!values.password) {
                        errors.password = "Required";
                    } else if (values.password.length < 8) {
                        errors.password = "Password must have at least 8 charater";
                    }
                    return errors;
                }}
                onSubmit={(values, { setSubmitting }) => {
                    axios.get('https://60dff0ba6b689e001788c858.mockapi.io/token', {
                        email: values.email,
                        password: values.password,
                    })
                        .then(response => {
                            setSubmitting(false);
                            setCurrentUser({
                                token: response.data.token,
                                userId: response.data.userId
                            })
                        })
                }}
            >
                {({
                    values,
                    errors,
                    touched,
                    handleChange,
                    handleBlur,
                    handleSubmit,
                    isSubmitting,
                }) => (
                    <div>
                        <form onSubmit={handleSubmit}>
                            <div >
                                <label>Email</label><br />
                                <input
                                    type="email"
                                    name="email"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.email}
                                />
                                <label style={{ color: "red" }}>
                                    {errors.email && touched.email && errors.email}
                                </label>
                            </div>
                            <div>
                                <label>Password</label><br />
                                <input
                                    type="password"
                                    name="password"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.password}
                                />
                                <label style={{ color: "red" }}>
                                    {errors.password && touched.password && errors.password}
                                </label>
                            </div>
                            <div>
                                <button type="submit" disabled={isSubmitting}>
                                    Submit
                                </button>
                            </div>
                        </form>
                    </div>
                )}
            </Formik>
        </div>
    );
}

export default LoginPage;