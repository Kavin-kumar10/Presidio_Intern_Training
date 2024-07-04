const express = require('express')

const app = express();
const port = 3030;


app.get('/',(req,res)=>{
    res.send("Helo i am working")
})

app.listen(port,()=>{
    console.log(`Running in the port :${port}`);
})