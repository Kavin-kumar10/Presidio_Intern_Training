import { useState } from 'react';
import answer from './Answer.json'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './App.css';

function App() {
  const notify = () => toast("Wow so easy!");

  const answers = answer;
  const [guessed,setGuessed] = useState([]);
  const [guess,setGuess] = useState('');
  const [score,setScore] = useState(0);
  const handleSubmit = (e) =>{
    e.preventDefault();
    if(!guess.includes('a' || 'A')){
      toast.error("Letter A is mandatory...!")
      setGuess('')
      return;
    }
    if(guess.length<4){
      toast.error('Too short');
      setGuess('');
      return;
    }

    if(answers.includes(guess.toUpperCase())){
      toast.success("Congrats you got "+guess.length+ " points")
      setGuessed([...guessed,guess]);
      setScore((prev)=>prev+guess.length)
    }
    else{
      toast.error("No such word found ... !")
    }
    setGuess('')
  }
  console.log(answer);
  return (
    <div className="App flex items-center justify-center h-screen w-screen">
      <ToastContainer/>
      <form onSubmit={(e)=>handleSubmit(e)} className="flex-1 flex flex-col items-center justify-center gap-10">

        <div className='flex gap-5' >
          <input className='outline-none shadow-md shadow-gray-300 rounded-md px-3 py-2' value={guess} onChange={(e)=>setGuess(e.target.value)} type="text" />
        </div>
        <div className="flex flex-col items-center gap-1">
          <div className="flex">
            <div onClick={()=>setGuess((prev)=>prev+'C')} className="shape relative top-10 left-4 h-20 w-20 bg-secondary font-comb">C</div>
            <div onClick={()=>setGuess((prev)=>prev+'O')} className="shape h-20 w-20 bg-secondary font-comb">O</div>
            <div onClick={()=>setGuess((prev)=>prev+'H')} className="shape relative top-11 right-4 h-20 w-20 bg-secondary font-comb">H</div>
          </div>
          <div onClick={()=>setGuess((prev)=>prev+'A')} className="shape h-20 w-20 bg-tertiary font-comb">A</div>
          <div className="flex">
            <div onClick={()=>setGuess((prev)=>prev+'T')} className="shape relative bottom-11 left-4 h-20 w-20 bg-secondary font-comb">T</div>
            <div onClick={()=>setGuess((prev)=>prev+'I')} className="shape h-20 w-20 bg-secondary font-comb">I</div>
            <div onClick={()=>setGuess((prev)=>prev+'R')} className="shape relative bottom-10 right-4 h-20 w-20 bg-secondary font-comb">R</div>
          </div>
        </div>
        <div className="flex gap-10">
            <button className='px-3 py-1 shadow-md shadow-secondary rounded-lg outline-none' type='reset'>Delete</button>
            <button className='px-3 py-1 shadow-md shadow-secondary rounded-lg outline-none' type='submit'>Enter</button>
        </div>

      </form>
      <div className="p-10 flex-1 h-full flex items-center justify-center">
        <div className="p-5 border-2 rounded-md border-black h-full w-full">
          <div className="flex justify-between mb-5">
            <h1>you have found {guessed.length} words</h1>
            <h1 className='px-4 py-2 bg-tertiary text-white rounded-md'>Score : {score} </h1>
          </div>
          {
            guessed?.map((elem)=>{
              return(
                <p>{elem}</p>
              )
            })
          }
        </div>
      </div>
    </div>
  );
}

export default App;
