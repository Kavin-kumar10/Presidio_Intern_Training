import React, { useEffect, useState } from "react";
import axios from "axios";
import Time from "../Components/Time";
import { useNavigate } from "react-router-dom";

const CheckBalance = () =>{
    const navigate = useNavigate();
    useEffect(()=>{
        if(!localStorage.getItem('user'))
            navigate('/')
    },[])
    const [balance,setBalance] = useState(0)
    const getBalance = async () =>{
        try{
            const result = await axios.get(`https://possible-flamingo-large.ngrok-free.app/api/Account/balance/${JSON.parse(localStorage.getItem('atmNumber'))}`,{
                headers:{
                    "Content-Type": "application/json",
                    "ngrok-skip-browser-warning": "69420"
                }
            })
            setBalance(result.data)
            console.log(result.data);
        }
        catch(err){
            console.log(err);
        }
    }
    useEffect(()=>{
        getBalance();
    },[])
    return(
        <div className="CheckBalance w-screen h-screen text-secondary">
            <Time/>
            <div className=" px-5 sm:px-10 py-24 md:px-20 md:py-32">
                <h1 className=" text-xl sm:text-3xl md:text-5xl mb-2 sm:mb-5 md:mb-10 font-bold opacity-50">Your Balance Amount : </h1>
                <p className="text-3xl sm:text-5xl md:text-7xl font-bold ">${balance}</p>
            </div>
        </div>
    )
}

export default CheckBalance