const users = [
    { email: "kavinkumar.prof@gmail.com", password: "kavin@10" },
    { email: "pravinkumar.prof@gmail.com", password: "pravin@10" }
  ];
  
  function validateLogin(event) {
    event.preventDefault();
  
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const message = document.getElementById("message");
  
    if (email === "" || password === "") {
      message.textContent = "Please enter both email and password.";
      return false;
    }
  
    for (const user of users) {
      if (user.email === email && user.password === password) {
        message.textContent = "Login successful!";
        return true;
      }
    }
  
    message.textContent = "Invalid email or password.";
    return false;
  }
  