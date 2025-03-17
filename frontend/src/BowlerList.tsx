import React, { useEffect, useState } from 'react';
import { bowler } from './types/bowler';

function BowlerList() {
  const [bowlers, setbowlers] = useState<bowler[]>([]);

  useEffect(() => {
    // makes sure we dont call the server over and over until we crash
    const fetchBowler = async () => {
      const response = await fetch('https://localhost:5069/api/Bowling');
      const data = await response.json();
      setbowlers(data);
    };
    fetchBowler();
  }, []);

  return (
    // returns our nice little table
    <>
      <h2>Bowler List</h2>
      <table>
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler) => (
            <tr key={bowler.bowlerId}>
              <td>
                {`${bowler.firstName} ${bowler.middleInitial || ''} ${bowler.lastName}`.trim()}
              </td>
              <td>{bowler.teamName}</td>
              <td>{bowler.address}</td>
              <td>{bowler.city}</td>
              <td>{bowler.state}</td>
              <td>{bowler.zip}</td>
              <td>{bowler.phoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlerList;
