import React from "react";
import Time from "../Components/Time";
import { FaRegArrowAltCircleRight } from "react-icons/fa";
import { Link } from "react-router-dom";

const Welcome = () =>{
    return(
        <div className="Welcome h-screen w-screen flex items-center justify-center text-secondary">
            <Time/>
            <div className="flex flex-col justify-center items-center">
                <h1 data-aos="fade-up" className="text-center text-xl sm:text-3xl md:text-5xl font-bold pb-2 sm:pb-4 md:pb-8">Welcome to <span className="text-tertiary">Ready Made </span> ATM</h1>
                <p data-aos="fade-up" data-aos-duration="1000" className="text-md sm:text-xl md:text-3xl font-bold opacity-50 pb-2 sm:pb-5 md:pb-10 text-secondary">Thank you for choosing us</p>
                <Link to="/Account" data-aos="fade-up" data-aos-duration="2000" className="flex gap-2 md:gap-5 bg-secondary border-2 border-secondary text-primary py-1 md:py-3 px-3 md:px-5 rounded-md items-center justify-center hover:bg-primary hover:text-secondary">Withrdraw / Debit Cash <FaRegArrowAltCircleRight size={20}/></Link>
            </div>
        </div>
    )
}

export default Welcome