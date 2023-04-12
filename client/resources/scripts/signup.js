// SIGNUP.JS

const userUrl = "https://your-api-endpoint.com/users"; // Replace with the correct API endpoint for creating a user

function userSignUp() {
    const signUpForm = document.getElementById("signup-form");
    const loginButton = document.getElementById("login-director");
    
    signUpForm.addEventListener("submit", createUser);
    loginButton.addEventListener("click", () => {
      window.location.href = "../pages/login.html"; // Redirect to the login page
    });
}

///// CREATE USER /////
const createUser = async (event) => {
  event.preventDefault();
  const target = event.target;
  const user = {
      Email: target["email-input-signup"].value,
      Password: target["password-input-signup"].value
  }
  const response = await fetch(userUrl, {
      method: 'POST',
      headers: {
        Accept: '*/*',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(user),
  });

  if (response.ok) {
      console.log("User created successfully");
      window.location.href = "../pages/login.html"; // Redirect to the login page
  } else {
      console.error("Error creating user:", response.statusText);
  }
}
  
userSignUp();
