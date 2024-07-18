import {  useState } from 'react';
import './App.css';
import {WORDS,getRandomWord} from './Components/answerword'

function App() {
  const [data,setData] = useState(Array(25).fill(null))
  const [resultcolor,setResultColor] = useState(Array(25).fill('brown'))
  const [correctanswer,] = useState(getRandomWord(WORDS));
  const [guessword,setGuessword] = useState('');
  const[ind,setInd] = useState(0);
  const handleSubmit = () =>{
    if(guessword.length<5){
      alert("Invalid entry try again");
      setGuessword('');
      return;
    }
    console.log(correctanswer);
    let temparr = [...data];
    var tempColors = [...resultcolor]
    for (let index = 0; index < 5; index++) { 
      if(guessword[index].toUpperCase() === correctanswer[index]){
        console.log(guessword[index].toUpperCase() + " "+ correctanswer[index]);
        tempColors[ind+index] = 'green';
      }
      else if(correctanswer.indexOf(guessword[index].toUpperCase())>=0){
        let val = correctanswer.indexOf(guessword[index].toUpperCase());
        console.log(val);
        tempColors[ind+index] = 'yellow';
      }
      temparr[ind+index] = guessword[index].toUpperCase();
    }
    setResultColor(tempColors);
    setData(temparr);
    setTimeout(()=>{
      if(guessword.toUpperCase() === correctanswer){
        alert("you won");
        window.location.reload();
      } 
    },1000)
    console.log(data);
    setInd((prev)=>prev+5)
    setGuessword('');
  }
  return (
    <div className="flex flex-col items-center justify-center h-screen w-screen">
        <div className="grid grid-cols-5 gap-3 grid-rows-5 mb-20">
          {
            data.map((elem,index)=>{
              return(
                <div className="flex items-center justify-center font-bold text-4xl h-14 w-14 rounded-m text-white" style={{background:resultcolor[index]}}>{elem}</div>
              )
            })
          }
        </div>
        {/* <Keyboard/> */}
        <div className="flex gap-5">
          <input value={guessword} onChange={(e)=>setGuessword(e.target.value)} maxLength={5} type="text" className='px-5 py-2 border-2 border-black'/>
          <button className='px-5 py-2 bg-red-900 rounded-md text-white' onClick={handleSubmit}>Submit</button>
        </div>
    </div>
  );
}

export default App;



// import React, { useState } from 'react';
// import './index.css';

// const WORDS = [
//   'APPLE',
//   'BERRY',
//   'CHERRY'];

// const getRandomWord = (words) => {
//   return words[Math.floor(Math.random() * words.length)];
// };

// const Row = ({ guess = '', solution = '' }) => {
//   const letters = guess.split('');
//   return (
//     <div className="grid grid-cols-5 gap-2">
//       {[...Array(5)].map((_, i) => (
//         <div
//           key={i}
//           className={`w-12 h-12 border flex items-center justify-center text-xl font-bold ${getLetterColor(
//             letters[i],
//             solution,
//             i
//           )}`}
//         >
//           {letters[i]}
//         </div>
//       ))}
//     </div>
//   );
// };

// const getLetterColor = (letter, solution, index) => {
//   if (!letter) return 'bg-white';
//   if (solution[index] === letter) return 'bg-green-500 text-white';
//   if (solution.includes(letter)) return 'bg-yellow-500 text-white';
//   return 'bg-gray-300';
// };

// function App() {
//   const [currentGuess, setCurrentGuess] = useState('');
//   const [guesses, setGuesses] = useState([]);
//   const [solution, setSolution] = useState(getRandomWord(WORDS));

//   const handleSubmitGuess = () => {
//     if (currentGuess.length === 5) {
//       setGuesses([...guesses, currentGuess]);
//       setCurrentGuess('');
//     }
//   };

//   return (
//     <div className="flex flex-col items-center justify-center h-screen bg-gray-100">
//       <h1 className="text-4xl font-bold mb-8">Wordle Clone</h1>
//       <div className="grid grid-rows-6 gap-2 mb-8">
//         {guesses.map((guess, index) => (
//           <Row key={index} guess={guess} solution={solution} />
//         ))}
//         {[...Array(6 - guesses.length)].map((_, index) => (
//           <Row key={index + guesses.length} />
//         ))}
//       </div>
//       <input
//         type="text"
//         value={currentGuess}
//         onChange={(e) => setCurrentGuess(e.target.value.toUpperCase())}
//         maxLength={5}
//         className="border p-2 mb-4 text-center"
//       />
//       <button
//         onClick={handleSubmitGuess}
//         className="bg-blue-500 text-white px-4 py-2 rounded"
//       >
//         Submit Guess
//       </button>
//     </div>
//   );
// }

// export default App;

