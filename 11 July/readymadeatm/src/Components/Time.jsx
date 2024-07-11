import React,{useState,useEffect} from "react";
import { GoHomeFill } from "react-icons/go";
import { Link } from "react-router-dom";

const Time = () =>{
    const [time,setTime] = useState(new Date());
    setTimeout(() => {
        setTime(new Date())
    }, 1000);
    return(
        <div className="Time bg-primary fixed top-0 left-0 w-full p-5 flex justify-between">
            <h1>{time.toLocaleTimeString()}</h1>
            <Link className="flex flex-col items-center justify-center text-secondary" to="/"><GoHomeFill className="text-xl"/> Home</Link>
        </div>
    )
}

export default Time