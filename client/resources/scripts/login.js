const loginUser = async (event) => {
    event.preventDefault();
    const target = event.target;
    const email = target.email.value;
    const password = target.password.value;
  
    // Replace with the correct API endpoint for getting user data
    const url = `https://your-api-endpoint.com/users?email=${encodeURIComponent(email)}`;
  
    const response = await fetch(url, {
      method: "GET",
      headers: {
        Accept: "*/*",
        "Content-Type": "application/json",
      },
    });
  
    if (response.ok) {
      const user = await response.json();
      if (user.password === password) {
        console.log("User logged in");
        // Redirect to the main page
        window.location.href = "../pages/main.html";
      } else {
        console.log("Incorrect password");
        // Show an error message or handle the incorrect password case
      }
    } else {
      console.log("User not found");
      // Show an error message or handle the user not found case
    }
};


document.getElementById("login-form").addEventListener("submit", (event) => {
    event.preventDefault();
    // Implement the login functionality here
    console.log("User logged in");
    window.location.href = "../pages/index.html";; // Redirect to the main page
});


document.getElementById("continue-as-guest").addEventListener("click", () => {
    console.log("Continuing as guest");
    window.location.href = "../pages/index.html"; // Redirect to the main page
});

