import './Home.css'
import 'bootstrap/dist/css/bootstrap.min.css';
// import Certificate from "../../Components/Certificate.jsx"
import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

// Example of a data array that
// you might receive from an API
const data = [
    { certification: "AZ-900: A Guide to becoming a professional", certifcationDate: "06/24/2011", status:"Permanent", expiryDate:"Never"},
    { certification: "AZ-1400", certifcationDate: "11/13/2023", status:"Ok", expiryDate:"11/13/2024"},
    { certification: "AZ-2400", certifcationDate: "02/01/2024", status:"Ok", expiryDate:"02/01/2024"},
]

export default function Home() {
    const [showAdd, setShowAdd] = useState(false);
    const [showModify, setShowModify] = useState(false);
    const [showDelete, setShowDelete] = useState(false);

    const [modData, set_Mod_Data] = useState({
        certificate: '',
        certifcationDate: '',
        status: '',
        expiryDate: '',
    }); 

    const handleCloseAdd = () => setShowAdd(false);
    const handleShowAdd = () => setShowAdd(true);
    const handleCloseModify = () => setShowModify(false);
    const handleShowModify = () => setShowModify(true);
    const handleCloseDelete = () => setShowDelete(false);
    const handleShowDelete = () => setShowDelete(true);

    const modHandler = (e) => {
        console.log(e);
        set_Mod_Data( prevCert => {
            console.log(prevCert);
            return { ...prevCert, [e.target]: e.target}
        })
        console.log(modData);
        handleShowModify();
     }

    return (
        <>
        <body>
            <h1>Your Certifications</h1>

            <table>
                <tr>
                    <th>Certifications</th>
                    <th>Certified Date</th>
                    <th>Status</th>
                    <th>Expiry Date</th>
                </tr>
                {data.map((val, key) => {
                    return (
                        <tr key={key}>
                            <td>{val.certification}</td>
                            <td>{val.certifcationDate}</td>
                            <td>{val.status}</td>
                            <td>{val.expiryDate}</td>
                            <td class="btns"><button onClick={ () => modHandler(val)} class="certCRUD">Modify</button></td>
                            <td class="btns"><button onClick={handleShowDelete} class="certCRUD">Delete</button></td>
                        </tr>
                    )
                })}
            </table>

            <button onClick={handleShowAdd} class="addnew">Add New</button>
            
        </body>


                {/* MODAL FOR ADDING A NEW CERTIFICATE */}
        <Modal show={showAdd} onHide={handleCloseAdd}>
            <Modal.Header className="modalHead">
                <Modal.Title className="modalHead">Add New Certificate</Modal.Title>
            </Modal.Header>
            <Modal.Body>
            <form>
                <div class="addnewcert">
                    <div class="formSegment">
                        <label for="certificate"> Certificate </label>
                        <select id="certificate"></select>
                    </div>
                    <div class="formSegment">
                        <label for="certDate"> Certifcate Date </label>
                        <input type="date" id="certDate"></input>
                    </div>
                    <div class="formSegment">
                        <label for="certExpiry"> Expiry Date </label>
                        <input type="date" id="certExpiry"></input>
                    </div>
                </div>
            </form>
            </Modal.Body>
            <Modal.Footer>
            <Button className="modalbtn" type="submit" id="submit_new_cert" onClick={handleCloseAdd}>
                Add Certificate
            </Button>
            <Button className="modalbtn" onClick={handleCloseAdd}>
                Close
            </Button>
            </Modal.Footer>
        </Modal>

        {/* MODAL FOR MODIFYING A CERTIFICATE */}
        <Modal show={showModify} onHide={handleCloseModify}>
            <Modal.Header className="modalHead">
                <Modal.Title className="modalHead">Modify Certificate</Modal.Title>
            </Modal.Header>
            <Modal.Body>
            <form>
                <div class="modifycert">
                    <div class="formSegment">
                        <label for="certificate"> Certificate </label>
                        <select id="certificate"></select>
                    </div>
                    <div class="formSegment">
                        <label for="certDate"> Certifcate Date </label>
                        <input type="date" id="certDate"></input>
                    </div>
                    <div class="formSegment">
                        <label for="certExpiry"> Expiry Date </label>
                        <input type="date" id="certExpiry"></input>
                    </div>
                </div>
            </form>
            </Modal.Body>
            <Modal.Footer>
            <Button className="modalbtn" type="submit" id="submit_new_cert" onClick={handleCloseModify}>
                Modify Certificate
            </Button>
            <Button className="modalbtn" onClick={handleCloseModify}>
                Close
            </Button>
            </Modal.Footer>
        </Modal>

        {/* MODAL FOR DELETING A CERTIFICATE */}
        <Modal show={showDelete} onHide={handleCloseDelete}>
            <Modal.Header className="modalHead">
                <Modal.Title className="modalHead">Delete Certificate</Modal.Title>
            </Modal.Header>
            <Modal.Body>
            <form>
                <div class="deletecert">
                    <div class="formSegment">
                        <label for="certificate"> Are you sure you want to <span>delete</span> this certificate? </label>
                    </div>
                </div>
            </form>
            </Modal.Body>
            <Modal.Footer>
            <Button className="delbtn" type="submit" id="delete_cert" onClick={handleCloseDelete}>
                Delete Certificate
            </Button>
            <Button className="modalbtn" onClick={handleCloseDelete}>
                Close
            </Button>
            </Modal.Footer>
        </Modal>

        </>
    )
}