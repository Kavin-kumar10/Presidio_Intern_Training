const handleLogin = async(e) =>{
    try{
        e.preventDefault();
        let form = document.getElementById('login');
        const formData = new FormData(form);
        let data = {
            "userId":formData.get('userId'),
            "password":formData.get('password')
        }
        const options = {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        };
        let response = await fetch('http://localhost:5018/api/User/Login',options)
        let result = await response.json();
        localStorage.setItem('RefundApp',JSON.stringify(result));
        window.location.href = "/src/User/index.html"
    }
    catch(err){
        console.log(err);
    }
}

const login = document.getElementById('login');
login.addEventListener('submit',handleLogin);