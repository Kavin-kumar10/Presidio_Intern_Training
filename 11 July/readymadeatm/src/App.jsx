import './output.css';
import Account from './Screens/Account';
import Choice from './Screens/Choice';
import Welcome from './Screens/Welcome';
import { BrowserRouter as Router,Routes,Route } from 'react-router-dom';
import Withdrawal from './Screens/Withdrawal';
import Deposit from './Screens/Deposit';
import CheckBalance from './Screens/CheckBalance';

function App() {
  return (
    <Router>
      <div className="App bg-primary">
      <Routes>
        <Route path='/' element={<Welcome/>}/>
        <Route path='/Account' element={<Account/>}/>
        <Route path='/Choice' element={<Choice/>}/>
        <Route path='/Withdrawal' element={<Withdrawal/>}/>
        <Route path='/Deposit' element={<Deposit/>}/>
        <Route path='/Balance' element={<CheckBalance/>}/>

      </Routes>
      </div>
    </Router>
  );
}

export default App;
