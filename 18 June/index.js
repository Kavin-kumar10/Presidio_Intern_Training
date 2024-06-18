const updateValues = async (e) =>{
    try{
        e.preventDefault();
        let id = document.getElementById('Id').value;
        let body = document.getElementById('Body').value;
        console.log(id);
        let response = await fetch(`https://dummyjson.com/comments/${id}`, {
          method: 'PUT',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            body: body,
          })
        })
        let result = await response.json();
        console.log(result);

    }
    catch(err){
        console.log(err);
    }
}

let form = document.getElementById("myform");
form.addEventListener('submit',updateValues)