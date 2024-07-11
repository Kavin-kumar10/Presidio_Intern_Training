import React,{useEffect} from "react";
import Time from "../Components/Time";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

const Choice = () =>{
    const navigate = useNavigate();
    useEffect(()=>{
        if(!localStorage.getItem('user'))
            navigate('/')
    },[])
    return(
        <div className="Choice gap-10 bg-primary text-secondary w-screen h-screen flex flex-col items-center justify-center">
            <Time/>
            <h1 className="text-secondary text-2xl sm:text-3xl md:text-5xl font-bold">Enter your Choice</h1>
            <div className="flex gap-2 md:gap-5 flex-col sm:flex-row">
                <Link to='/Withdrawal' data-aos="fade-up" data-aos-duration="1000" className="text-center rounded-md px-3 sm:px-5 md:px-10 cursor-pointer py-1 sm:py-2 md:py-4 bg-secondary text-primary font-bold">Withdrawal</Link>
                <Link to='/Deposit' data-aos="fade-up" data-aos-duration="1500" className="text-center rounded-md px-3 sm:px-5 md:px-10 cursor-pointer py-1 sm:py-2 md:py-4 bg-secondary text-primary font-bold">Deposit</Link>
                <Link to='/Balance' data-aos="fade-up" data-aos-duration="2000" className="text-center rounded-md px-3 sm:px-5 md:px-10 cursor-pointer py-1 sm:py-2 md:py-4 bg-secondary text-primary font-bold">Check Balance</Link>
            </div>
        </div>
    )
}

export default Choice