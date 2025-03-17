import { useState } from 'react';
import reactLogo from './assets/react.svg';
import viteLogo from '/vite.svg';
import './App.css';
import BowlerList from './BowlerList';

function PageHeader() {
  // nice little header tell about page
  return (
    <>
      <h1>
        This website shows you some totally not confidential info on Bowlers
      </h1>
    </>
  );
}

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <PageHeader />
      <BowlerList />
    </>
  );
}

export default App;
