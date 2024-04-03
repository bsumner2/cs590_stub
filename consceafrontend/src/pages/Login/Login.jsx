import './Login.css'

export default function Login() {
  return (
    <body>
      <header>
        <div class="topbar"></div>
        <div class="bottombar"></div>
      </header>

      <container class="content">
        <h1>Certificate Site Login</h1>

        <form>
          <div class="formSegment">
            <label for="username"> Username </label>
            <input id="username"></input>
          </div>
          <div class="formSegment">
            <label for="password"> Password </label>
            <input id="password"></input>
          </div>
          <button
            class="login"
            type="submit"
            id="submit_login" >
            Login
          </button>
        </form>
        <button class="forgot_pw">
          Forgot Password?
        </button>
        </container>

        <footer>
          <div class="bottombar"></div>
          <div class="topbar"></div> 
        </footer>
        
    </body>
  )
}