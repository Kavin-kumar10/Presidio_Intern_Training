import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios'

function App() {
  const [data,setData] = useState();
  useEffect(()=>{
    const getData = async() =>{
        try{
          const result = await axios.get('https://localhost:7116/api/Product')
          console.log(result);
          setData(result.data);
        }
        catch(err){
          console.log(err);
        }
    }
    getData();
  },[])

  return (
    <div className="App">
      <h1>Azure Training</h1>
      <div className="container">
        {
          data?.map((elem)=>{
            return(
              <div className="card">
                <h1>{elem.name}</h1>
                <h2>${elem.price}</h2>
                <img src={elem.image} alt="" />
              </div>
            )
          })
        }
      </div>
    </div>
  );
}

export default App;
