import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Time from "../Components/Time";
import axios from 'axios'

const Withdrawal = () =>{
    const navigate = useNavigate();
    useEffect(()=>{
        if(!localStorage.getItem('user'))
            navigate('/')
    },[])
    const [Amount,setAmount] = useState()
    const [success,setSuccess] = useState(false);
    const local = JSON.parse(localStorage.getItem('user'));
    const notify = (err) => toast.error(err)
    const handleWithdrawal = async(e) =>{
        e.preventDefault();
        try{
            const result = await axios.post('https://possible-flamingo-large.ngrok-free.app/api/Transactions/withdraw',{
                userId:local.userId,
                amount:Amount.toString()
            },{
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${local.token}`
                },
            })
            console.log(result);
            localStorage.removeItem('user')
            setAmount()
            setSuccess(true)
        }
        catch(err){
            notify(err.response.data.message);
            console.log(err);
            // console.log(err);
        }
    }
    return(
        <div className="Withdrawal w-screen h-screen bg-primary text-secondary">
            <Time/>
            <ToastContainer/>
            <form onSubmit={handleWithdrawal} className="px-5 py-24 sm:px-10 sm:p-24 md:px-20 md:py-32 flex flex-col ">
                <h1 className="text-2xl sm:text-3xl md:text-5xl mb-10 font-bold opacity-50">Enter Amount to Withdraw: </h1>
                <div className="flex flex-col md:flex-row gap-5">
                    <input value={Amount} onChange={(e)=>setAmount(e.target.value)} type="number" placeholder="Amount" className="w-fit px-5 py-2 outline-none bg-transparent border-2 rounded-md border-secondary shadow-sm"/>
                    <button className="w-fit text-md bg-secondary text-primary rounded-md font-bold py-2 px-5">Withdraw Amount</button>
                </div>
                {
                    success?
                    <p className="mt-2 sm:mt-5 md:mt-10 bg-green-900 px-3 py-2 text-primary w-fit rounded-sm font-bold">Withdrawal Successful</p>
                    :<></>
                }
            </form>
        </div>
    )
}

export default Withdrawal