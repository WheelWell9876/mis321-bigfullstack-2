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


/////////////////////////////////////////////   ADMINS    /////////////////////////////////////////////
/////////////////////////////////////////////   ADMINS    /////////////////////////////////////////////
/////////////////////////////////////////////   ADMINS    /////////////////////////////////////////////


///// Get ADMINS /////
const getAdmins = function () {
    fetch(adminUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        makeAdminTable(data);
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
        adminTd1.innerHTML = c.adminID;
        adminTR.appendChild(adminTd1);

        // ADMIN EMAIL TABLE DATA
        let adminTd2 = document.createElement("td");
        adminTd2.innerHTML = c.adminEmail;
        adminTR.appendChild(adminTd2);

        // ADMIN PASSWORD TABLE DATA
        let adminTd3 = document.createElement("td");
        adminTd3.innerHTML = c.adminPassword;
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
            adminForm.key = c.adminID;
        });

        // ADMIN DELETE BUTTON
        let adminDeleteBtn = document.createElement("button");
        adminTR.appendChild(adminDeleteBtn);
        adminDeleteBtn.innerHTML = "Delete";
        adminDeleteBtn.classList.add("delete-btn");
        adminDeleteBtn.addEventListener("click", () => {
            deleteAdmin(c.adminID);
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
        email: target.email.value,
        password: target.password.value,
        securityKey: target.securityKey.value
    }
    await fetch(url, {
        method: 'POST',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(admin),
    });
    render();
    target.email.value = "";
    target.password.value = "";
    target.securityKey.value = "";
}

///// EDIT ADMIN /////
const editAdmin = async (event) => {
    event.preventDefault();
    const target = event.target;
    const admin = {
        adminID: target.key,
        email: target.email.value,
        password: target.password.value,
        securityKey: target.securityKey.value
    }
    await fetch(`${url}/${target.key}`, {
        method: 'PUT',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(admin),
    });
    render();
    target.email.value = "";
    target.password.value = "";
    target.securityKey.value = "";
}

///// DELETE ADMIN /////
const deleteAdmin = async (adminID) => {
    await fetch(`${url}/${adminID}`, {
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
        userTd1.innerHTML = c.userID;
        userTR.appendChild(userTd1);

        // USER EMAIL TABLE DATA
        let userTd2 = document.createElement("td");
        userTd2.innerHTML = c.userEmail;
        userTR.appendChild(userTd2);

        // USER PASSWORD TABLE DATA
        let userTd3 = document.createElement("td");
        userTd3.innerHTML = c.userPassword;
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
            userForm.key = c.userID;
        });

        // USER DELETE BUTTON
        let deleteBtn = document.createElement("button");
        userTR.appendChild(deleteBtn);
        deleteBtn.innerHTML = "Delete";
        deleteBtn.classList.add("delete-btn");
        deleteBtn.addEventListener("click", () => {
            deleteUser(c.userID);
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
        email: target.email.value,
        password: target.password.value
    }
    await fetch(url, {
        method: 'POST',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    });
    render();
    target.email.value = "";
    target.password.value = "";
}

///// EDIT USER /////
const editUser = async (event) => {
    event.preventDefault();
    const target = event.target;
    const user = {
        userID: target.key,
        email: target.email.value,
        password: target.password.value
    }
    await fetch(`${url}/${target.key}`, {
        method: 'PUT',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    });
    render();
    target.email.value = "";
    target.password.value = "";
}

///// DELETE USER /////
const deleteUser = async (userID) => {
    await fetch(`${url}/${userID}`, {
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
        gasCarTd1.innerHTML = c.gasCarID;
        gasCarTR.appendChild(gasCarTd1);

        // GAS CAR MAKE TABLE DATA
        let gasCarTd2 = document.createElement("td");
        gasCarTd2.innerHTML = c.gasCarMake;
        gasCarTR.appendChild(gasCarTd2);

        // GAS CAR MODEL TABLE DATA
        let gasCarTd3 = document.createElement("td");
        gasCarTd3.innerHTML = c.gasCarModel;
        gasCarTR.appendChild(gasCarTd3);

        // GAS CAR YEAR TABLE DATA
        let gasCarTd4 = document.createElement("td");
        gasCarTd4.innerHTML = c.gasCarYear;
        gasCarTR.appendChild(gasCarTd4);

        // GAS CAR RANGE TABLE DATA
        let gasCarTd5 = document.createElement("td");
        gasCarTd5.innerHTML = c.gasCarRange;
        gasCarTR.appendChild(gasCarTd5);

        // GAS CAR PRICE TABLE DATA
        let gasCarTd6 = document.createElement("td");
        gasCarTd6.innerHTML = c.gasCarPrice;
        gasCarTR.appendChild(gasCarTd6);

        // GAS CAR MPG TABLE DATA
        let gasCarTd7 = document.createElement("td");
        gasCarTd7.innerHTML = c.gasCarMPG;
        gasCarTR.appendChild(gasCarTd7);

        // GAS CAR ADDON TABLE DATA
        let gasCarTd8 = document.createElement("td");
        gasCarTd8.innerHTML = c.gasCarAddOn;
        gasCarTR.appendChild(gasCarTd8);

        // GAS CAR EDIT BUTTON
        let gasCarEditBtn = document.createElement("button");
        gasCarTR.appendChild(gasCarEditBtn);
        gasCarEditBtn.innerHTML = "Edit";
        gasCarEditBtn.classList.add("edit-btn");
        gasCarEditBtn.addEventListener("click", () => {

            // GAS CAR MAKE INPUT
            let gasCarMakeInput = document.getElementById("gas-car-make-input");
            gasCarMakeInput.value = c.gasCarMake;

            // GAS CAR MODEL INPUT
            let gasCarModelInput = document.getElementById("gas-car-model-input");
            gasCarModelInput.value = c.gasCarModel;

            // GAS CAR YEAR INPUT
            let gasCarYearInput = document.getElementById("gas-car-year-input");
            gasCarYearInput.value = c.gasCarYear;

            // GAS CAR RANGE INPUT
            let gasCarRangeInput = document.getElementById("gas-car-range-input");
            gasCarRangeInput.value = c.gasCarRange;

            // GAS CAR PRICE INPUT
            let gasCarPriceInput = document.getElementById("gas-car-price-input");
            gasCarPriceInput.value = c.gasCarPrice;

            // GAS CAR MPG INPUT
            let gasCarMPGInput = document.getElementById("gas-car-mpg-input");
            gasCarMPGInput.value = c.gasCarMPG;

            // GAS CAR ADDON INPUT
            let gasCarAddOnInput = document.getElementById("gas-car-addon-input");
            gasCarAddOnInput.value = c.gasCarAddOn;

            // GAS CAR FORM
            let gasCarForm = document.getElementById("gas-car-form");
            gasCarForm.onsubmit = editGasCar();
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
        gasMake: target.gasMake.value,
        gasModel: target.gasModel.value,
        gasYear: target.gasYear.value,
        gasRange: target.gasRange.value,
        gasPrice: target.gasPrice.value,
        gasMPG: target.gasMPG.value,
        gasAddOn: target.gasAddOn.value
    }
    await fetch(url, {
        method: 'POST',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(gasCar),
    });
    render();
    target.gasMake.value = "";
    target.gasModel.value = "";
    target.gasYear.value = "";
    target.gasRange.value = "";
    target.gasPrice.value = "";
    target.gasMPG.value = "";
    target.gasAddOn.value = "";
}

///// EDIT GAS CAR /////
const editGas = async (event) => {
    event.preventDefault();
    const target = event.target;
    const gasCar = {
        gasCarId: target.key,
        gasMake: target.gasMake.value,
        gasModel: target.gasModel.value,
        gasYear: target.gasYear.value,
        gasRange: target.gasRange.value,
        gasPrice: target.gasPrice.value,
        gasMPG: target.gasMPG.value,
        gasAddOn: target.gasAddOn.value
    }
    await fetch(`${url}/${target.key}`, {
        method: 'PUT',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(gasCar),
    });
    render();
    target.gasMake.value = "";
    target.gasModel.value = "";
    target.gasYear.value = "";
    target.gasRange.value = "";
    target.gasPrice.value = "";
    target.gasMPG.value = "";
    target.gasAddOn.value = "";
}

///// DELETE GAS CAR /////
const deleteGas = async (gasCarId) => {
    await fetch(`${url}/${gasCarId}`, {
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
        electricCarTd1.innerHTML = c.electricCarID;
        electricCarTR.appendChild(electricCarTd1);

        // ELECTRIC CAR MAKE TABLE DATA
        let electricCarTd2 = document.createElement("td");
        electricCarTd2.innerHTML = c.electricCarMake;
        electricCarTR.appendChild(electricCarTd2);

        // ELECTRIC CAR MODEL TABLE DATA
        let electricCarTd3 = document.createElement("td");
        electricCarTd3.innerHTML = c.electricCarModel;
        electricCarTR.appendChild(electricCarTd3);

        // ELECTRIC CAR YEAR TABLE DATA
        let electricCarTd4 = document.createElement("td");
        electricCarTd4.innerHTML = c.electricCarYear;
        electricCarTR.appendChild(electricCarTd4);

        // ELECTRIC CAR RANGE TABLE DATA
        let electricCarTd5 = document.createElement("td");
        electricCarTd5.innerHTML = c.electricCarRange;
        electricCarTR.appendChild(electricCarTd5);

        // ELECTRIC CAR PRICE TABLE DATA
        let electricCarTd6 = document.createElement("td");
        electricCarTd6.innerHTML = c.electricCarPrice;
        electricCarTR.appendChild(electricCarTd6);

        // ELECTRIC CAR MPG TABLE DATA
        let electricCarTd7 = document.createElement("td");
        electricCarTd7.innerHTML = c.electricCarKWH;
        electricCarTR.appendChild(electricCarTd7);

        // ELECTRIC CAR ADDON TABLE DATA
        let electricCarTd8 = document.createElement("td");
        electricCarTd8.innerHTML = c.electricCarAddOn;
        electricCarTR.appendChild(electricCarTd8);

        // ELECTRIC CAR EDIT BUTTON
        let electricCarEditBtn = document.createElement("button");
        electricCarTR.appendChild(electricCarEditBtn);
        electricCarEditBtn.innerHTML = "Edit";
        electricCarEditBtn.classList.add("edit-btn");
        electricCarEditBtn.addEventListener("click", () => {

            // ELECTRIC CAR MAKE INPUT
            let electricCarMakeInput = document.getElementById("electric-car-make-input");
            electricCarMakeInput.value = c.electricCarMake;

            // ELECTRIC CAR MODEL INPUT
            let electricCarModelInput = document.getElementById("electric-car-model-input");
            electricCarModelInput.value = c.electricCarModel;

            // ELECTRIC CAR YEAR INPUT
            let electricCarYearInput = document.getElementById("electric-car-year-input");
            electricCarYearInput.value = c.electricCarYear;

            // ELECTRIC CAR RANGE INPUT
            let electricCarRangeInput = document.getElementById("electric-car-range-input");
            electricCarRangeInput.value = c.electricCarRange;

            // ELECTRIC CAR PRICE INPUT
            let electricCarPriceInput = document.getElementById("electric-car-price-input");
            electricCarPriceInput.value = c.electricCarPrice;

            // ELECTRIC CAR MPG INPUT
            let electricCarMPGInput = document.getElementById("electric-car-kwh-input");
            electricCarMPGInput.value = c.electricCarKWH;

            // ELECTRIC CAR ADDON INPUT
            let electricCarAddOnInput = document.getElementById("electric-car-addon-input");
            electricCarAddOnInput.value = c.electricCarAddOn;

            // ELECTRIC CAR FORM
            let electricCarForm = document.getElementById("electric-car-form");
            electricCarForm.onsubmit = editelectricCar();
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
        electricMake: target.electricMake.value,
        electricModel: target.electricModel.value,
        electricYear: target.electricYear.value,
        electricRange: target.electricRange.value,
        electricPrice: target.electricPrice.value,
        electricMPG: target.electricMPG.value,
        electricAddOn: target.electricAddOn.value
    }
    await fetch(url, {
        method: 'POST',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(electricCar),
    });
    render();
    target.electricMake.value = "";
    target.electricModel.value = "";
    target.electricYear.value = "";
    target.electricRange.value = "";
    target.electricPrice.value = "";
    target.electricMPG.value = "";
    target.electricAddOn.value = "";
}

///// EDIT ELECTRIC CAR /////
const editElectric = async (event) => {
    event.preventDefault();
    const target = event.target;
    const electricCar = {
        electricCarId: target.key,
        electricMake: target.electricMake.value,
        electricModel: target.electricModel.value,
        electricYear: target.electricYear.value,
        electricRange: target.electricRange.value,
        electricPrice: target.electricPrice.value,
        electricMPG: target.electricMPG.value,
        electricAddOn: target.electricAddOn.value
    }
    await fetch(`${url}/${target.key}`, {
        method: 'PUT',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(electricCar),
    });
    render();
    target.electricMake.value = "";
    target.electricModel.value = "";
    target.electricYear.value = "";
    target.electricRange.value = "";
    target.electricPrice.value = "";
    target.electricMPG.value = "";
    target.electricAddOn.value = "";
}

///// DELETE ELECTRIC CAR /////
const deleteElectric = async (electricCarId) => {
    await fetch(`${url}/${electricCarId}`, {
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
        pairTd1.innerHTML = c.pairID;
        pairTR.appendChild(pairTd1);

        // USER ID TABLE DATA
        let pairTd2 = document.createElement("td");
        pairTd2.innerHTML = c.userID;
        pairTR.appendChild(pairTd2);

        // GAS CAR ID TABLE DATA
        let pairTd3 = document.createElement("td");
        pairTd3.innerHTML = c.gasCarID;
        pairTR.appendChild(pairTd3);

        // ELECTRIC ID TABLE DATA
        let pairTd4 = document.createElement("td");
        pairTd4.innerHTML = c.electricCarID;
        pairTR.appendChild(pairTd4);

        let pairEditBtn = document.createElement("button");
        pairTR.appendChild(pairEditBtn);
        pairEditBtn.innerHTML = "Edit";
        pairEditBtn.classList.add("edit-btn");
        pairEditBtn.addEventListener("click", () => {

            // PAIR ID INPUT
            let pairIDInput = document.getElementById("title-input");
            pairIDInput.value = c.title;

            // USER ID INPUT
            let userIDInput = document.getElementById("artist-input");
            userIDInput.value = c.artist;

            // GAS CAR ID INPUT
            let gasCarIDInput = document.getElementById("title-input");
            gasCarIDInput.value = c.title;

            // ELECTRIC CAR ID INPUT
            let electricCarIDInput = document.getElementById("artist-input");
            electricCarIDInput.value = c.artist;

            let pairForm = document.getElementById("pair-form");
            pairForm.onsubmit = editPair();
            pairForm.key = c.pairID;
        });

        let deleteBtn = document.createElement("button");
        tr.appendChild(deleteBtn);
        deleteBtn.innerHTML = "Delete";
        deleteBtn.classList.add("delete-btn");
        deleteBtn.addEventListener("click", () => {
            deletePair(c.pairID);
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
        gasID: target.key,
        electricID: target.key,
        pairID: target.key
    }
}

///// DELETE CAR PAIR /////
const deletePair = async (pairID) => {
    await fetch(`${url}/${pairID}`, {
        method: 'DELETE',
        headers: {
          Accept: '*/*',
          'Content-Type': 'application/json',
        },
    });
    render();
}

