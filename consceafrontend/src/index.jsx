import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import './index.css';
import Login from './pages/Login/Login.jsx'
import Nav from './pages/Nav/Nav.jsx'
import Home from './pages/Home/Home.jsx'
import NoPage from './pages/NoPage/NoPage.jsx'

import reportWebVitals from './reportWebVitals';

// sets the navigation for the app
export default function App() {
  return (
    <BrowserRouter>
      <Routes>
          <Route path="/Login" element={<Login />}/>
        <Route path="/" element={<Nav />}>
          <Route index element={<Home />}/>
          <Route path="*" element={<NoPage />}/>
        </Route>
        
      </Routes>
    </BrowserRouter>
  );
}

ReactDOM.render(<App />, document.getElementById("root"));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
