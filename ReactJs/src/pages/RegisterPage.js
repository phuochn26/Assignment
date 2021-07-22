import React from "react";
import { Formik } from 'formik';
import './css/Login.css'

const RegisterPage = () => {
    return (
        <div className="center">
            <h1>Register Form</h1>
            <Formik
                initialValues={{ userName: '', email: '', gender: '', password: '', retypePassword: '' }}
                validate={values => {
                    const errors = {};
                    if (!values.userName) {
                        errors.userName = 'Required';
                    } else if (
                        !/^[A-Za-z0-9]{4,}$/i.test(values.userName)
                    ) {
                        errors.userName = 'Invalid UserName';
                    }

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
                    
                    if (!values.retypePassword) {
                        errors.retypePassword = "Required";
                    } else if (values.retypePassword !== values.password) {
                        errors.password = "Password does not match";
                    }
                    return errors;
                }}
                onSubmit={(values, { setSubmitting }) => {
                    setTimeout(() => {
                        alert(JSON.stringify(values, null, 2));
                        setSubmitting(false);
                    }, 400);
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
                            <div>
                                <label>User Name</label><br />
                                <input
                                    type="text"
                                    name="userName"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.userName}
                                />
                                <label style={{ color: "red" }}>{errors.userName && touched.userName && errors.userName}</label>
                            </div>
                            <div>
                                <label>Email</label><br />
                                <input
                                    type="email"
                                    name="email"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.email}
                                />
                                <label style={{ color: "red" }}>{errors.email && touched.email && errors.email}</label>
                            </div>
                            <div>
                                <label>Gender</label>
                                <select
                                    name="gender"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.gender}
                                >
                                    <option selected value="male">Male</option>
                                    <option value="female">Female</option>
                                </select>
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
                                <label style={{ color: "red" }}>{errors.password && touched.password && errors.password}</label>
                            </div>
                            <div>
                                <label>Retype Password</label><br />
                                <input
                                    type="password"
                                    name="retypePassword"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.retypePassword}
                                />
                                <label style={{ color: "red" }}>{errors.retypePassword && touched.retypePassword && errors.retypePassword}</label>
                            </div>
                            <div><label><input name="agreement" type="checkbox" required="required"/>I have read the agreement</label></div>
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

export default RegisterPage;