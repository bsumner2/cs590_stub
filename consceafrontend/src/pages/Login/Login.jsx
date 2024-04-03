import './Login.css'
import UserList from '../../Components/UserList'
import Sieve from '../../Components/Sieve.jsx'

function Login() {
  return (
    <main>
      <div className="Login">
        <div>{Sieve()}</div>
        <div>Hey!</div>
        <div>{UserList}</div>
      </div>
    </main>
  );
}

export default Login
