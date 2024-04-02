import logo from './logo.svg';
import './App.css';
import UserList from './Components/UserList';

function App() {
  return (
    <main>
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
        </header>
      </div>
      <div>{UserList}</div>
    </main>
  );
}

export default App;
