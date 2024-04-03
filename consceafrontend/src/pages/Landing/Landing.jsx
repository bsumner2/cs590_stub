import './Landing.css'
import { Outlet } from "react-router-dom";

function Landing() {
    return (
        <>
            <div class="topbar"></div>
            <div class="bottombar"></div>

            <Outlet />
        </>
    )
}

export default Landing