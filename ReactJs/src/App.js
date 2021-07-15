import Welcome from './components/Welcome';
import Count from './components/Count';

const App = ({ age, name , color}) => {
    return (
            <div>
            <Welcome
                age={50}
                name="Davion"
                color="red"
            />
            <Welcome
                age={5}
                name="Pikachu"
                color="yellow"
            />
            <Welcome
                age={40}
                name="Viper"
                color="Green"
            />
            <Count></Count>
            </div>
            )
};

export default App;