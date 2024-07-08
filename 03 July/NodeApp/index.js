const express = require("express")
const dbConnect = require('./db')

const app = express();

dbConnect;


app.get('/',(req,res)=>{
    res.send("hello i am working here");
})

app.listen(3000,()=>{
    console.log("running in port 3000");
})