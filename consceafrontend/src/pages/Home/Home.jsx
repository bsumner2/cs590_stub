import './Home.css'

// Example of a data array that
// you might receive from an API
const data = [
    { certification: "AZ-900: A Guide to becoming a professional", certifcationDate: "06/24/2011", status:"Permanent", expiryDate:"Never"},
    { certification: "AZ-1400", certifcationDate: "11/13/2023", status:"Ok", expiryDate:"11/13/2024"},
    { certification: "AZ-2400", certifcationDate: "02/01/2024", status:"Ok", expiryDate:"02/01/2024"},
]

export default function Home() {
    return (
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
                            <td class="btns"><button class="certCRUD">Modify</button></td>
                            <td class="btns"><button class="certCRUD">Delete</button></td>
                        </tr>
                    )
                })}
            </table>

            <button class="addnew">Add New</button>
        </body>
    )
}