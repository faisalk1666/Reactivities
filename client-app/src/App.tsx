
import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';
import { Header, Icon, List, ListItem } from 'semantic-ui-react';

function App() {

  const [activities, setActivity] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/activities')
      .then(response => {
        setActivity(response.data)
      })
  }, [])

  return (
    <div>
      <Header as='h2' icon textAlign='center'>
      <Icon name='users' circular />
      <Header.Content>Reactivities</Header.Content>
    </Header> 
      <div>
        <List celled>
          {activities.map((activity:any) => (
            <ListItem key={activity.id}>{activity.title}</ListItem>
          ))}
        </List>
      </div>
    </div>
  )
}

export default App
