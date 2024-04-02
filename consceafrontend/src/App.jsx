import logo from './logo.svg'
import './App.css'
import UserList from './Components/UserList'
import Sieve from './Components/Sieve'

function App() {
  return (
    <main>
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <div>{Sieve}</div>
          <div>Hey!</div>
        </header>
        
      </div>
      <div>{UserList}</div>
      
    </main>
  );
}

export default App