import './Nav.css'
import { Outlet, Link } from "react-router-dom";

function Nav() {
    return (
        <>
            <div class="topbar">  
            </div>
            
            <div class="bottombar">
            <ul>
                    <li>
                        <Link class="a" to="/">Home</Link>
                    </li>
                    <li>
                        <Link class="a" to="/Dashboard">Dashboard</Link>
                    </li>
                    {/* <li>
                        <Link to="/certs">Certificates</Link>
                    </li>
                    <li>
                        <Link to="/profile">Profile</Link>
                    </li> */}
                </ul>
            </div>
            <Outlet />
        </>
    )
}

export default Nav