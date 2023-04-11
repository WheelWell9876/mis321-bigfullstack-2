function userSignUp() {
    const signUpForm = document.getElementById("signup-form");
    const loginButton = document.getElementById("login-director");
    
    signUpForm.addEventListener("submit", createUser);
    loginButton.addEventListener("click", () => {
      console.log("User signed up");
      window.location.href = "../pages/index.html"; // Redirect to the main page
    });
}

///// CREATE USER /////
const createUser = async (event) => {
    event.preventDefault();
    const target = event.target;
    const user = {
      email: target.email.value,
      password: target.password.value,
    };
    await fetch(url, {
      method: "POST",
      headers: {
        Accept: "*/*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user),
    });
    render();
    target.email.value = "";
    target.password.value = "";
};
  
userSignUp();