const Welcome = ({ age, name , color}) => {
    return (
        <div style={ { backgroundColor: color, fontsize: 15 } }>
            <h1>Hello { name }</h1>
            <h3>Age { age }</h3>
        </div>
    )
};

export default Welcome;