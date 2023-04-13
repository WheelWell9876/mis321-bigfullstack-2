const adminUrl = "http://localhost:5104/api/admin";
const userUrl = "http://localhost:5104/api/user";
const gasCarUrl = "http://localhost:5104/api/gascar";
const electricCarUrl = "http://localhost:5104/api/electriccar";
const pairUrl = "http://localhost:5104/api/pair";

const render = () => {
    getAdmins();
    getUsers();
    getGasCars();
    getElectricCars();
    getPairs();
}

function displayContent(event, tabName) {
    // Get all tab content elements and hide them
    let tabContents = document.getElementsByClassName("tabcontent");
    for (let i = 0; i < tabContents.length; i++) {
        tabContents[i].style.display = "none";
    }

    // Get all tab buttons and remove the "active" class
    let tabLinks = document.getElementsByClassName("tablinks");
    for (let i = 0; i < tabLinks.length; i++) {
        tabLinks[i].className = tabLinks[i].className.replace(" active", "");
    }

    // Show the current tab content and add the "active" class to the clicked tab button
    document.getElementById(tabName).style.display = "block";
    event.currentTarget.className += " active";

    // Fetch and populate the tables with data
    render();
}

document.addEventListener('DOMContentLoaded', () => {
    render();
});

/////////////////////////////////////////////   ADMINS    /////////////////////////////////////////////
/////////////////////////////////////////////   ADMINS    /////////////////////////////////////////////
/////////////////////////////////////////////   ADMINS    /////////////////////////////////////////////


///// Get ADMINS /////
const getAdmins = function () {
    fetch(adminUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        makeAdminTable(data); // <-- Replaced 'populateAdminTable' with 'makeAdminTable'
    });
};

///// Make Admin Table /////
const makeAdminTable = (admins) => {
    let adminTable = document.getElementById("admin-table");
    adminTable.innerHTML = "";

    adminTable.appendChild(makeAdminHeader());
    adminTable.appendChild(makeAdminBody(admins));
};

///// MAKE Admin HEADER /////
const makeAdminHeader = () => {
    const adminHeader = document.createElement("thead");

    // ADMIN ID HEADER
    const adminTh1 = document.createElement("th");
    adminTh1.innerHTML = "Admin ID";
    adminHeader.appendChild(adminTh1);

    // ADMIN EMAIL HEADER
    const adminTh2 = document.createElement("th");
    adminTh2.innerHTML = "Email";
    adminHeader.appendChild(adminTh2);

    // ADMIN PASSWORD HEADER
    const adminTh3 = document.createElement("th");
    adminTh3.innerHTML = "Password";
    adminHeader.appendChild(adminTh3);

    // ADMIN SECURITY KEY HEADER
    const adminTh4 = document.createElement("th");
    adminTh4.innerHTML = "Security Key";
    adminHeader.appendChild(adminTh4);

    return adminHeader;
}

///// MAKE ADMIN BODY /////
const makeAdminBody = (admins) => {
    let adminTbody = document.createElement("tbody");

    admins.forEach((c) => {
        let adminTR = document.createElement("tr");

        // ADMIN ID TABLE DATA
        let adminTd1 = document.createElement("td");
        adminTd1.innerHTML = c.adminId;
        adminTR.appendChild(adminTd1);

        // ADMIN EMAIL TABLE DATA
        let adminTd2 = document.createElement("td");
        adminTd2.innerHTML = c.email;
        adminTR.appendChild(adminTd2);

        // ADMIN PASSWORD TABLE DATA
        let adminTd3 = document.createElement("td");
        adminTd3.innerHTML = c.password;
        adminTR.appendChild(adminTd3);

        // ADMIN SECURITY KEY TABLE DATA
        let adminTd4 = document.createElement("td");
        adminTd4.innerHTML = c.securityKey;
        adminTR.appendChild(adminTd4);

        // ADMIN EDIT BUTTON
        let adminEditBtn = document.createElement("button");
        adminTR.appendChild(adminEditBtn);
        adminEditBtn.innerHTML = "Edit Admin";
        adminEditBtn.classList.add("edit-btn");
        adminEditBtn.addEventListener("click", () => {
            
            // ADMIN EMAIL INPUT
            let adminEmailInput = document.getElementById("admin-email-input");
            adminEmailInput.value = c.adminEmail;

            // ADMIN PASSWORD INPUT
            let adminPasswordInput = document.getElementById("admin-password-input");
            adminPasswordInput.value = c.adminPassword;

            // ADMIN SECURITY KEY INPUT
            let securityKeyInput = document.getElementById("security-key-input");
            securityKeyInput.value = c.securityKey;

            // ADMIN FORM
            let adminForm = document.getElementById("admin-form");
            adminForm.onsubmit = editAdmin;
            adminForm.key = c.adminId;
        });

        // ADMIN DELETE BUTTON
        let adminDeleteBtn = document.createElement("button");
        adminTR.appendChild(adminDeleteBtn);
        adminDeleteBtn.innerHTML = "Delete";
        adminDeleteBtn.classList.add("delete-btn");
        adminDeleteBtn.addEventListener("click", () => {
            deleteAdmin(c.adminId);
        });

        adminTbody.appendChild(adminTR);
    });
    return adminTbody;
};


///// CREATE ADMIN /////
const createAdmin = async (event) => {
    event.preventDefault();
    const target = event.target;
    const admin = {
        Email: target["admin-email"].value,
        Password: target["admin-password"].value,
        SecurityKey: target["security-key"].value
    };

    console.log("Sending Admin:", JSON.stringify(admin));

    const response = await fetch(adminUrl, {
        method: 'POST',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(admin),
    });

    if (response.ok) {
        console.log("Admin created successfully");
        render();
        target["admin-email"].value = "";
        target["admin-password"].value = "";
        target["security-key"].value = "";
    } else {
        console.error("Error creating admin:", response.statusText);
    }
};


///// EDIT ADMIN /////
const editAdmin = async (event) => {
    event.preventDefault();
    const target = event.target;
    const admin = {
        AdminID: target.key,
        Email: target.adminEmail.value,
        Password: target.adminPassword.value,
        SecurityKey: target.adminSecurityKey.value
    }
    await fetch(`${adminUrl}/${target.key}`, {
        method: 'PUT',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(admin),
    });
    render();
    target.adminEmail.value = "";
    target.adminPassword.value = "";
    target.adminSecurityKey.value = "";
}

///// DELETE ADMIN /////
const deleteAdmin = async (AdminId) => {
    await fetch(`${adminUrl}/${AdminId}`, {
        method: 'DELETE',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
    });
    render();
}

/////////////////////////////////////////////   USERS    /////////////////////////////////////////////
/////////////////////////////////////////////   USERS    /////////////////////////////////////////////
/////////////////////////////////////////////   USERS    /////////////////////////////////////////////


///// Get USERS /////
const getUsers = function () {
    fetch(userUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        makeUserTable(data);
    });
};

///// Make User Table /////
const makeUserTable = (users) => {
    let userTable = document.getElementById("user-table");
    userTable.innerHTML = "";

    userTable.appendChild(makeUserHeader());
    userTable.appendChild(makeUserBody(users));
};

///// MAKE User HEADER /////
const makeUserHeader = () => {
    const userHeader = document.createElement("thead");

    // USER ID HEADER
    const userTh1 = document.createElement("th");
    userTh1.innerHTML = "User ID";
    userHeader.appendChild(userTh1);

    // USER EMAIL HEADER
    const userTh2 = document.createElement("th");
    userTh2.innerHTML = "Email";
    userHeader.appendChild(userTh2);

    // USER PASSWORD HEADER
    const userTh3 = document.createElement("th");
    userTh3.innerHTML = "Password";
    userHeader.appendChild(userTh3);

    return userHeader;
}

///// MAKE USER BODY /////
const makeUserBody = (users) => {
    let userTbody = document.createElement("tbody");

    users.forEach((c) => {
        let userTR = document.createElement("tr");

        // USER ID TABLE DATA
        let userTd1 = document.createElement("td");
        userTd1.innerHTML = c.userId;
        userTR.appendChild(userTd1);

        // USER EMAIL TABLE DATA
        let userTd2 = document.createElement("td");
        userTd2.innerHTML = c.email;
        userTR.appendChild(userTd2);

        // USER PASSWORD TABLE DATA
        let userTd3 = document.createElement("td");
        userTd3.innerHTML = c.password;
        userTR.appendChild(userTd3);

        // USER EDIT BUTTON
        let userEditBtn = document.createElement("button");
        userTR.appendChild(userEditBtn);
        userEditBtn.innerHTML = "Edit";
        userEditBtn.classList.add("edit-btn");
        userEditBtn.addEventListener("click", () => {

            // USER EMAIL INPUT
            let userEmailInput = document.getElementById("user-email-input");
            userEmailInput.value = c.userEmail;

            // USER PASSWORD INPUT
            let userPasswordInput = document.getElementById("user-password-input");
            userPasswordInput.value = c.userPassword;

            // USER FORM
            let userForm = document.getElementById("user-form");
            userForm.onsubmit = editUser;
            userForm.key = c.userId;
        });

        // USER DELETE BUTTON
        let deleteBtn = document.createElement("button");
        userTR.appendChild(deleteBtn);
        deleteBtn.innerHTML = "Delete";
        deleteBtn.classList.add("delete-btn");
        deleteBtn.addEventListener("click", () => {
            deleteUser(c.userId);
        });

        userTbody.appendChild(userTR);
    });
    return userTbody;
};


///// CREATE USER /////
const createUser = async (event) => {
    event.preventDefault();
    const target = event.target;
    const user = {
        Email: target["user-email"].value,
        Password: target["user-password"].value
    }
    await fetch(userUrl, {
        method: 'POST',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    });
    render();
    target["user-email"].value = "";
    target["user-password"].value = "";
}

///// EDIT USER /////
const editUser = async (event) => {
    event.preventDefault();
    const target = event.target;
    const user = {
        UserId: target.key,
        Email: target.userEmail.value,
        Password: target.userPassword.value
    }
    await fetch(`${userUrl}/${target.key}`, {
        method: 'PUT',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    });
    render();
    target.userEmail.value = "";
    target.userPassword.value = "";
}

///// DELETE USER /////
const deleteUser = async (userID) => {
    await fetch(`${userUrl}/${userID}`, {
        method: 'DELETE',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
    });
    render();
}



/////////////////////////////////////////////   GAS CARS    /////////////////////////////////////////////
/////////////////////////////////////////////   GAS CARS    /////////////////////////////////////////////
/////////////////////////////////////////////   GAS CARS    /////////////////////////////////////////////

///// Get Gas Cars /////
const getGasCars = function () {
    fetch(gasCarUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        makeGasCarTable(data);
    });
};

///// Make GAS CAR Table /////
const makeGasCarTable = (gasCars) => {
    let gasCarTable = document.getElementById("gas-car-table");
    gasCarTable.innerHTML = "";

    gasCarTable.appendChild(makeGasCarHeader());
    gasCarTable.appendChild(makeGasCarBody(gasCars));
};

///// MAKE GAS CAR HEADER /////
const makeGasCarHeader = () => {
    const gasCarHeader = document.createElement("thead");

    // GAS CAR ID HEADER
    const gasCarTh1 = document.createElement("th");
    gasCarTh1.innerHTML = "Gas Car ID";
    gasCarHeader.appendChild(gasCarTh1);

    // GAS CAR MAKE HEADER
    const gasCarTh2 = document.createElement("th");
    gasCarTh2.innerHTML = "Make";
    gasCarHeader.appendChild(gasCarTh2);

    // GAS CAR MODEL HEADER
    const gasCarTh3 = document.createElement("th");
    gasCarTh3.innerHTML = "Model";
    gasCarHeader.appendChild(gasCarTh3);

    // GAS CAR YEAR HEADER
    const gasCarTh4 = document.createElement("th");
    gasCarTh4.innerHTML = "Year";
    gasCarHeader.appendChild(gasCarTh4);

    // GAS CAR RANGE HEADER
    const gasCarTh5 = document.createElement("th");
    gasCarTh5.innerHTML = "Range";
    gasCarHeader.appendChild(gasCarTh5);

    // GAS CAR PRICE HEADER
    const gasCarTh6 = document.createElement("th");
    gasCarTh6.innerHTML = "Price";
    gasCarHeader.appendChild(gasCarTh6);

    // GAS CAR MPG HEADER
    const gasCarTh7 = document.createElement("th");
    gasCarTh7.innerHTML = "MPG";
    gasCarHeader.appendChild(gasCarTh7);
    
    // GAS CAR ADDON HEADER
    const gasCarTh8 = document.createElement("th");
    gasCarTh8.innerHTML = "Add On";
    gasCarHeader.appendChild(gasCarTh8);

    return gasCarHeader;
}

///// MAKE GAS CAR BODY /////
const makeGasCarBody = (gasCars) => {
    let gasCarTbody = document.createElement("tbody");

    // GAS CAR FOREACH LOOP
    gasCars.forEach((c) => {
        let gasCarTR = document.createElement("tr");

        // GAS CAR ID TABLE DATA
        let gasCarTd1 = document.createElement("td");
        gasCarTd1.innerHTML = c.gasCarId;
        gasCarTR.appendChild(gasCarTd1);

        // GAS CAR MAKE TABLE DATA
        let gasCarTd2 = document.createElement("td");
        gasCarTd2.innerHTML = c.make;
        gasCarTR.appendChild(gasCarTd2);

        // GAS CAR MODEL TABLE DATA
        let gasCarTd3 = document.createElement("td");
        gasCarTd3.innerHTML = c.model;
        gasCarTR.appendChild(gasCarTd3);

        // GAS CAR YEAR TABLE DATA
        let gasCarTd4 = document.createElement("td");
        gasCarTd4.innerHTML = c.year;
        gasCarTR.appendChild(gasCarTd4);

        // GAS CAR RANGE TABLE DATA
        let gasCarTd5 = document.createElement("td");
        gasCarTd5.innerHTML = c.range;
        gasCarTR.appendChild(gasCarTd5);

        // GAS CAR PRICE TABLE DATA
        let gasCarTd6 = document.createElement("td");
        gasCarTd6.innerHTML = c.price;
        gasCarTR.appendChild(gasCarTd6);

        // GAS CAR MPG TABLE DATA
        let gasCarTd7 = document.createElement("td");
        gasCarTd7.innerHTML = c.mpg;
        gasCarTR.appendChild(gasCarTd7);

        // GAS CAR ADDON TABLE DATA
        let gasCarTd8 = document.createElement("td");
        gasCarTd8.innerHTML = c.addOn;
        gasCarTR.appendChild(gasCarTd8);

        // GAS CAR EDIT BUTTON
        let gasCarEditBtn = document.createElement("button");
        gasCarTR.appendChild(gasCarEditBtn);
        gasCarEditBtn.innerHTML = "Edit";
        gasCarEditBtn.classList.add("edit-btn");
        gasCarEditBtn.addEventListener("click", () => {

            // GAS CAR MAKE INPUT
            let gasCarMakeInput = document.getElementById("gas-car-make-input");
            gasCarMakeInput.value = c.make;

            // GAS CAR MODEL INPUT
            let gasCarModelInput = document.getElementById("gas-car-model-input");
            gasCarModelInput.value = c.model;

            // GAS CAR YEAR INPUT
            let gasCarYearInput = document.getElementById("gas-car-year-input");
            gasCarYearInput.value = c.year;

            // GAS CAR RANGE INPUT
            let gasCarRangeInput = document.getElementById("gas-car-range-input");
            gasCarRangeInput.value = c.range;

            // GAS CAR PRICE INPUT
            let gasCarPriceInput = document.getElementById("gas-car-price-input");
            gasCarPriceInput.value = c.price;

            // GAS CAR MPG INPUT
            let gasCarMPGInput = document.getElementById("gas-car-mpg-input");
            gasCarMPGInput.value = c.mpg;

            // GAS CAR ADDON INPUT
            let gasCarAddOnInput = document.getElementById("gas-car-addon-input");
            gasCarAddOnInput.value = c.addOn;

            // GAS CAR FORM
            let gasCarForm = document.getElementById("gas-car-form");
            gasCarForm.onsubmit = editGas;
            gasCarForm.key = c.gasCarId;
        });

        // GAS CAR DELETE BUTTON
        let gasCarDeleteBtn = document.createElement("button");
        gasCarTR.appendChild(gasCarDeleteBtn);
        gasCarDeleteBtn.innerHTML = "Delete";
        gasCarDeleteBtn.classList.add("delete-btn");
        gasCarDeleteBtn.addEventListener("click", () => {
            deleteGas(c.gasCarId);
        });

        gasCarTbody.appendChild(gasCarTR);
    });
    return gasCarTbody;
};


///// CREATE GAS CAR /////
const createGas = async (event) => {
    event.preventDefault();
    const target = event.target;
    const gasCar = {
        Make: target["gas-car-make"].value,
        Model: target["gas-car-model"].value,
        Year: target["gas-car-year"].value,
        Range: target["gas-car-range"].value,
        Price: target["gas-car-price"].value,
        MPG: target["gas-car-mpg"].value,
        AddOn: target["gas-car-addon"].value
    }
    await fetch(gasCarUrl, {
        method: 'POST',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(gasCar),
    });
    render();
    target["gas-car-make"].value = "";
    target["gas-car-model"].value = "";
    target["gas-car-year"].value = "";
    target["gas-car-range"].value = "";
    target["gas-car-price"].value = "";
    target["gas-car-mpg"].value = "";
    target["gas-car-addon"].value = "";
}

///// EDIT GAS CAR /////
const editGas = async (event) => {
    event.preventDefault();
    const target = event.target;
    const gasCar = {
        GasCarId: target.key,
        Make: target["gas-car-make"].value,
        Model: target["gas-car-model"].value,
        Year: target["gas-car-year"].value,
        Range: target["gas-car-range"].value,
        Price: target["gas-car-price"].value,
        MPG: target["gas-car-mpg"].value,
        AddOn: target["gas-car-addon"].value
    }
    await fetch(`${gasCarUrl}/${target.key}`, {
        method: 'PUT',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(gasCar),
    });
    render();
    target["gas-car-make"].value = "";
    target["gas-car-model"].value = "";
    target["gas-car-year"].value = "";
    target["gas-car-range"].value = "";
    target["gas-car-price"].value = "";
    target["gas-car-mpg"].value = "";
    target["gas-car-addon"].value = "";
}

///// DELETE GAS CAR /////
const deleteGas = async (gasCarId) => {
    await fetch(`${gasCarUrl}/${gasCarId}`, {
        method: 'DELETE',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
    });
    render();
}

/////////////////////////////////////////////   ELECTRIC CARS    /////////////////////////////////////////////
/////////////////////////////////////////////   ELECTRIC CARS    /////////////////////////////////////////////
/////////////////////////////////////////////   ELECTRIC CARS    /////////////////////////////////////////////


///// Get ELECTRIC Cars /////
const getElectricCars = function () {
    fetch(electricCarUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        makeElectricCarTable(data);
    });
};

///// Make ElECTRIC CAR Table /////
const makeElectricCarTable = (electricCars) => {
    let electricCarTable = document.getElementById("electric-car-table");
    electricCarTable.innerHTML = "";

    electricCarTable.appendChild(makeElectricCarHeader());
    electricCarTable.appendChild(makeElectricCarBody(electricCars));
};

///// MAKE ELECTRIC CAR HEADER /////
const makeElectricCarHeader = () => {
    const electricCarHeader = document.createElement("thead");

    // ELECTRIC CAR ID HEADER
    const electricCarTh1 = document.createElement("th");
    electricCarTh1.innerHTML = "Electric Car ID";
    electricCarHeader.appendChild(electricCarTh1);

    // ELECTRIC CAR MAKE HEADER
    const electricCarTh2 = document.createElement("th");
    electricCarTh2.innerHTML = "Make";
    electricCarHeader.appendChild(electricCarTh2);

    // ELECTRIC CAR MODEL HEADER
    const electricCarTh3 = document.createElement("th");
    electricCarTh3.innerHTML = "Model";
    electricCarHeader.appendChild(electricCarTh3);

    // ELECTRIC CAR YEAR HEADER
    const electricCarTh4 = document.createElement("th");
    electricCarTh4.innerHTML = "Year";
    electricCarHeader.appendChild(electricCarTh4);

    // ELECTRIC CAR RANGE HEADER
    const electricCarTh5 = document.createElement("th");
    electricCarTh5.innerHTML = "Range";
    electricCarHeader.appendChild(electricCarTh5);

    // ELECTRIC CAR PRICE HEADER
    const electricCarTh6 = document.createElement("th");
    electricCarTh6.innerHTML = "Price";
    electricCarHeader.appendChild(electricCarTh6);

    // ELECTRIC CAR KWH HEADER
    const electricCarTh7 = document.createElement("th");
    electricCarTh7.innerHTML = "KWH";
    electricCarHeader.appendChild(electricCarTh7);
    
    // ELECTRIC CAR ADDON HEADER
    const electricCarTh8 = document.createElement("th");
    electricCarTh8.innerHTML = "Add On";
    electricCarHeader.appendChild(electricCarTh8);

    return electricCarHeader;
}

///// MAKE ELECTRIC CAR BODY /////
const makeElectricCarBody = (electricCars) => {
    let electricCarTbody = document.createElement("tbody");

    // ELECTRIC CAR FOREACH LOOP
    electricCars.forEach((c) => {
        let electricCarTR = document.createElement("tr");

        // ELECTRIC CAR ID TABLE DATA
        let electricCarTd1 = document.createElement("td");
        electricCarTd1.innerHTML = c.electricCarId;
        electricCarTR.appendChild(electricCarTd1);

        // ELECTRIC CAR MAKE TABLE DATA
        let electricCarTd2 = document.createElement("td");
        electricCarTd2.innerHTML = c.make;
        electricCarTR.appendChild(electricCarTd2);

        // ELECTRIC CAR MODEL TABLE DATA
        let electricCarTd3 = document.createElement("td");
        electricCarTd3.innerHTML = c.model;
        electricCarTR.appendChild(electricCarTd3);

        // ELECTRIC CAR YEAR TABLE DATA
        let electricCarTd4 = document.createElement("td");
        electricCarTd4.innerHTML = c.year;
        electricCarTR.appendChild(electricCarTd4);

        // ELECTRIC CAR RANGE TABLE DATA
        let electricCarTd5 = document.createElement("td");
        electricCarTd5.innerHTML = c.range;
        electricCarTR.appendChild(electricCarTd5);

        // ELECTRIC CAR PRICE TABLE DATA
        let electricCarTd6 = document.createElement("td");
        electricCarTd6.innerHTML = c.price;
        electricCarTR.appendChild(electricCarTd6);

        // ELECTRIC CAR KWH TABLE DATA
        let electricCarTd7 = document.createElement("td");
        electricCarTd7.innerHTML = c.kwh;
        electricCarTR.appendChild(electricCarTd7);

        // ELECTRIC CAR ADDON TABLE DATA
        let electricCarTd8 = document.createElement("td");
        electricCarTd8.innerHTML = c.addOn;
        electricCarTR.appendChild(electricCarTd8);

        // ELECTRIC CAR EDIT BUTTON
        let electricCarEditBtn = document.createElement("button");
        electricCarTR.appendChild(electricCarEditBtn);
        electricCarEditBtn.innerHTML = "Edit";
        electricCarEditBtn.classList.add("edit-btn");
        electricCarEditBtn.addEventListener("click", () => {

            // ELECTRIC CAR MAKE INPUT
            let electricCarMakeInput = document.getElementById("electric-car-make-input");
            electricCarMakeInput.value = c.make;

            // ELECTRIC CAR MODEL INPUT
            let electricCarModelInput = document.getElementById("electric-car-model-input");
            electricCarModelInput.value = c.model;

            // ELECTRIC CAR YEAR INPUT
            let electricCarYearInput = document.getElementById("electric-car-year-input");
            electricCarYearInput.value = c.year;

            // ELECTRIC CAR RANGE INPUT
            let electricCarRangeInput = document.getElementById("electric-car-range-input");
            electricCarRangeInput.value = c.range;

            // ELECTRIC CAR PRICE INPUT
            let electricCarPriceInput = document.getElementById("electric-car-price-input");
            electricCarPriceInput.value = c.price;

            // ELECTRIC CAR KWH INPUT
            let electricCarKWHInput = document.getElementById("electric-car-kwh-input");
            electricCarKWHInput.value = c.kwh;

            // ELECTRIC CAR ADDON INPUT
            let electricCarAddOnInput = document.getElementById("electric-car-addon-input");
            electricCarAddOnInput.value = c.addOn;

            // ELECTRIC CAR FORM
            let electricCarForm = document.getElementById("electric-car-form");
            electricCarForm.onsubmit = editElectric;
            electricCarForm.key = c.electricCarId;
        });

        // ELECTRIC CAR DELETE BUTTON
        let electricCarDeleteBtn = document.createElement("button");
        electricCarTR.appendChild(electricCarDeleteBtn);
        electricCarDeleteBtn.innerHTML = "Delete";
        electricCarDeleteBtn.classList.add("delete-btn");
        electricCarDeleteBtn.addEventListener("click", () => {
            deleteElectric(c.electricCarId);
        });

        electricCarTbody.appendChild(electricCarTR);
    });
    return electricCarTbody;
};

///// CREATE ELECTRIC CAR /////
const createElectric = async (event) => {
    event.preventDefault();
    const target = event.target;
    const electricCar = {
        Make: target["electric-car-make"].value,
        Model: target["electric-car-model"].value,
        Year: target["electric-car-year"].value,
        Range: target["electric-car-range"].value,
        Price: target["electric-car-price"].value,
        KWH: target["electric-car-kwh"].value,
        AddOn: target["electric-car-addon"].value
    }
    await fetch(electricCarUrl, {
        method: 'POST',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(electricCar),
    });
    render();
    target["electric-car-make"].value = "";
    target["electric-car-model"].value = "";
    target["electric-car-year"].value = "";
    target["electric-car-range"].value = "";
    target["electric-car-price"].value = "";
    target["electric-car-kwh"].value = "";
    target["electric-car-addon"].value = "";
}

///// EDIT ELECTRIC CAR /////
const editElectric = async (event) => {
    event.preventDefault();
    const target = event.target;
    const electricCar = {
        ElectricCarId: target.key,
        Make: target["electric-car-make"].value,
        Model: target["electric-car-model"].value,
        Year: target["electric-car-year"].value,
        Range: target["electric-car-range"].value,
        Price: target["electric-car-price"].value,
        KWH: target["electric-car-kwh"].value,
        AddOn: target["electric-car-addon"].value
    }
    await fetch(`${electricCarUrl}/${target.key}`, {
        method: 'PUT',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(electricCar),
    });
    render();
    target["electric-car-make"].value = "";
    target["electric-car-model"].value = "";
    target["electric-car-year"].value = "";
    target["electric-car-range"].value = "";
    target["electric-car-price"].value = "";
    target["electric-car-kwh"].value = "";
    target["electric-car-addon"].value = "";
}

///// DELETE ELECTRIC CAR /////
const deleteElectric = async (electricCarId) => {
    await fetch(`${electricCarUrl}/${electricCarId}`, {
        method: 'DELETE',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
    });
    render();
}


/////////////////////////////////////////////   PAIRS    /////////////////////////////////////////////
/////////////////////////////////////////////   PAIRS    /////////////////////////////////////////////
/////////////////////////////////////////////   PAIRS    /////////////////////////////////////////////


///// Get PAIRS /////
const getPairs = function () {
    fetch(pairUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        makePairTable(data);
    });
};

///// Make CAR PAIR Table /////
const makePairTable = (pairs) => {
    let pairTable = document.getElementById("pair-table");
    pairTable.innerHTML = "";

    pairTable.appendChild(makePairHeader());
    pairTable.appendChild(makePairBody(pairs));
};

///// MAKE Car PAIR HEADER /////
const makePairHeader = () => {
    const pairHeader = document.createElement("thead");

    // PAIR ID HEADER
    const pairTh1 = document.createElement("th");
    pairTh1.innerHTML = "Pair ID";
    pairHeader.appendChild(pairTh1);

    // USER ID HEADER
    const pairTh2 = document.createElement("th");
    pairTh2.innerHTML = "User ID";
    pairHeader.appendChild(pairTh2);

    // GAS CAR ID HEADER
    const pairTh3 = document.createElement("th");
    pairTh3.innerHTML = "Gas Car ID";
    pairHeader.appendChild(pairTh3);

    // ELECTRIC CAR ID HEADER
    const pairTh4 = document.createElement("th");
    pairTh4.innerHTML = "Electric Car ID";
    pairHeader.appendChild(pairTh4);

    return pairHeader;
}

///// MAKE CarPair BODY /////
const makePairBody = (pairs) => {
    let pairTbody = document.createElement("tbody");

    // PAIR FOREACH LOOP
    pairs.forEach((c) => {
        let pairTR = document.createElement("tr");

        // PAIR ID TABLE DATA
        let pairTd1 = document.createElement("td");
        pairTd1.innerHTML = c.pairId;
        pairTR.appendChild(pairTd1);

        // USER ID TABLE DATA
        let pairTd2 = document.createElement("td");
        pairTd2.innerHTML = c.userId;
        pairTR.appendChild(pairTd2);

        // GAS CAR ID TABLE DATA
        let pairTd3 = document.createElement("td");
        pairTd3.innerHTML = c.gasCarId;
        pairTR.appendChild(pairTd3);

        // ELECTRIC ID TABLE DATA
        let pairTd4 = document.createElement("td");
        pairTd4.innerHTML = c.electricCarId;
        pairTR.appendChild(pairTd4);

        let pairEditBtn = document.createElement("button");
        pairTR.appendChild(pairEditBtn);
        pairEditBtn.innerHTML = "Edit";
        pairEditBtn.classList.add("edit-btn");
        pairEditBtn.addEventListener("click", () => {

            // PAIR ID INPUT
            let pairIDInput = document.getElementById("title-input");
            pairIDInput.value = c.PairId;

            // USER ID INPUT
            let userIDInput = document.getElementById("artist-input");
            userIDInput.value = c.UserId;

            // GAS CAR ID INPUT
            let gasCarIDInput = document.getElementById("title-input");
            gasCarIDInput.value = c.GasCarId;

            // ELECTRIC CAR ID INPUT
            let electricCarIDInput = document.getElementById("artist-input");
            electricCarIDInput.value = c.ElectricCarId;

            let pairForm = document.getElementById("pair-form");
            pairForm.onsubmit = editPair();
            pairForm.key = c.pairId;
        });

        let deleteBtn = document.createElement("button");
        tr.appendChild(deleteBtn);
        deleteBtn.innerHTML = "Delete";
        deleteBtn.classList.add("delete-btn");
        deleteBtn.addEventListener("click", () => {
            deletePair(c.pairId);
        });

        pairTbody.appendChild(tr);
    });
    return pairTbody;
};


///// CREATE CAR PAIR /////
const createPair = async (event) => {      //////THIS NEEDS TO WORK WITH THE CREATEPAIR.CS IN THE API, TARGET.KEY IS JUST A FILLER
    event.preventDefault();
    const target = event.target;
    const carPair = {
        GasCarId: target.key,
        ElectricCarId: target.key,
        PairId: target.key
    }
}

///// DELETE CAR PAIR /////
const deletePair = async (pairID) => {
    await fetch(`${pairUrl}/${pairID}`, {
        method: 'DELETE',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
    });
    render();
}


