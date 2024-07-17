var cron = require('node-cron')
const express = require('express')
var date = new Date();


const app = express();

const getNewDate = () =>{
    return new Date();
}

app.get('/',(req,res)=>{
    cron.schedule('* * * * *', () => {
        console.log('running a task every minute');
        let currDate = getNewDate();
        res.send(currDate)
    });

})

app.listen(5000,()=>{
    console.log("Port running in 5000");
})
