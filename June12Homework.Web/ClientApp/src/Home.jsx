import React, {useState, useEffect} from 'react';
import './App.css';
import axios from 'axios';
import PersonRow from './PersonRow';

const Home = () => {

    const [people, setPeople] = useState([])

    const onDeleteClick = async () => {
        await axios.post('/api/people/deleteallpeople')
        setPeople([])
    }

    useEffect(() => {
        const getPeople = async () => {
            const {data} = await axios.get('/api/people/getallpeople')
            setPeople(data)
        }
        getPeople()
    },[])

    return(<>
          <div className="row">
            <div className="col-md-6 offset-md-3 mt-5">
              <button className="btn btn-danger btn-lg w-100" onClick={onDeleteClick}>Delete All</button>
            </div>
          </div>
          <table className="table table-hover table-striped table-bordered mt-5">
            <thead>
              <tr>
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Age</th>
                <th>Address</th>
                <th>Email</th>
              </tr>
            </thead>
            <tbody>
              {people.map(p => <PersonRow key={p.id}
              person={p}/>)}
            </tbody>
          </table>
      </>)
}

export default Home;