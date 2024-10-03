
import { useEffect, useState } from 'react'
import axios from 'axios';
import { Activity } from '../Models/activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/dashboard/ActivityDashboard';
import { Container } from 'semantic-ui-react';

function App() {

  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('http://localhost:5000/api/activities')
      .then(response => {
        setActivities(response.data)
      })
  }, [])

  return (
    <>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <ActivityDashboard activities={activities}></ActivityDashboard>
      </Container>
    </>
  )
}

export default App
