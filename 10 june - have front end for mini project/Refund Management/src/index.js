const RedirectToLogin = () =>{
    if(!localStorage.getItem("RefundApp")){
        window.location.href = "/src/Auth/Login.html"
    }
}

const getUserData = () =>{
    if(localStorage.getItem("RefundApp")){
        let memberId = JSON.parse(localStorage.getItem("RefundApp")).memberID
    }
}


RedirectToLogin();
getUserData();