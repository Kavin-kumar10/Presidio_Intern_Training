import React, { useState,useEffect } from "react";
import Time from "../Components/Time";
import axios from 'axios'
import { useNavigate } from "react-router-dom";

const Account = () =>{
    const navigate = useNavigate();
    const [data,setData] = useState({
        atmNumber:"",
        pin:""
    })
    const handleSubmit = async (e) =>{
        e.preventDefault();
        console.log(data);
        try{
            const result = await axios.post('https://possible-flamingo-large.ngrok-free.app/api/Account/verify',data,{
                headers:{
                    'Content-Type':'application/json'
                }
            })
            localStorage.setItem('user',JSON.stringify(result.data));
            localStorage.setItem('atmNumber',JSON.stringify(data.atmNumber));
            console.log(result.data);
            navigate('/Choice')
        }catch(err){
            console.log(err);
        }
    }
    return(
        <div className="Account bg-primary h-screen flex items-center flex-col justify-center">
            <Time/>
            <div className="flex flex-col gap-10">
                <h1 className="text-secondary font-bold text-xl sm:text-3xl md:text-5xl">Enter your Card details.</h1>
                <form onSubmit={e=>handleSubmit(e)} className="flex flex-col gap-5">
                    <div className="flex flex-col gap-3 font-bold text-secondary">
                        <label htmlFor="Card">Card Number</label>
                        <input onChange={(e)=>setData({...data,atmNumber:e.target.value})} id="pin" className="px-3 py-1 outline-none bg-transparent rounded-md border-2 border-secondary" type="text" placeholder="**** **** **** ****"/>
                    </div>
                    <div className="flex flex-col gap-3 font-bold text-secondary">
                        <label htmlFor="pin">Pin number</label>
                        <input onChange={(e)=>setData({...data,pin:e.target.value})} id="pin" className="px-3 py-1 outline-none bg-transparent rounded-md border-2 border-secondary" type="password" placeholder="****"/>
                    </div>
                    <div className="flex justify-between">
                        <button className="px-5 py-2 w-1/3 rounded-md bg-secondary text-primary border-2 border-secondary">Verify</button>
                        <button className="px-5 py-2 w-1/3 rounded-md bg-primary border-2 border-secondary">Reset</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default Account