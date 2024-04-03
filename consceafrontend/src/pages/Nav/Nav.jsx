import './Nav.css'
import { Outlet, Link } from "react-router-dom";

function Nav() {
    return (
        <>
            <nav>
                <ul>
                    <li>
                        <Link to="/">Home</Link>
                    </li>
                    {/* <li>
                        <Link to="/certs">Certificates</Link>
                    </li>
                    <li>
                        <Link to="/profile">Profile</Link>
                    </li> */}
                </ul>
            </nav>

            <Outlet />
        </>
    )
}

export default Nav