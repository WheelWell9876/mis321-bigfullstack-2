const url = "http://localhost:5162/api/car";

const render = () => {
    getCars();
}

//// GET CARS ////
const getCars = function () {
    fetch(url).then(function (response) {
        return response.json();
    }).then(function(data){
        makeCarTable(data);
    });
};

//// MAKE TABLE ////
const makeCarTable = (cars) => {
    let table = document.getElementById("car-table");
    table.innerHTML = "";

    table.appendChild(makeHeader());
    table.appendChild(makeStatsList());
    table.appendChild(makeLeftSideStats(cars));
    table.appendChild(makeRightSideStats(cars));
}

///// MAKE HEADER /////
const makeStatsHeader = () => {
    const header  = document.createElement("thead");

    const th1 = document.createElement("th");
    th1.innerHTML = "Gas Vehicle";
    header.appendChild(th1);

    const th2 = document.createElement("th");
    th2.innerHTML = "*************";
    header.appendChild(th2);

    const th3 = document.createElement("th");
    th3.innerHTML = "Electric Vehicle";
    header.appendChild(th3);
}

///// STATS GAS CAR /////
const makeLeftSideStats = async (event) => {
    event.preventDefault();
    const target = event.target;
    const gasCar = {
        gasId: target.key,
        gasMake: document.getElementById("gas-car-make"),
        gasModel: document.getElementById("gas-car-model"),
        gasYear: document.getElementById("gas-car-year"),
        gasRange: document.getElementById("gas-car-range"),
        gasPrice: document.getElementById("gas-car-price"),
        gasMPG: document.getElementById("gas-car-mpg"),
        gasAddOn: document.getElementById("gas-car-addons")
    }
    await fetch(url, {
        method: "GET",
        headers: {
            Accept: '*/*',
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(gasCar),
    });
    render();
}

///// STATS ELECTRIC CAR //////
const makeRightSideStats = async (event) => {
    event.preventDefault();
    const target = event.target;
    const electricCar = {
        electricId: target.key,
        electricMake: document.getElementById("electric-car-make"),
        electricModel: document.getElementById("electric-car-model"),
        electricYear: document.getElementById("electric-car-year"),
        electricRange: document.getElementById("electric-car-range"),
        electricPrice: document.getElementById("electric-car-price"),
        electricMPG: document.getElementById("electric-car-mpg"),
        electricAddOn: document.getElementById("electric-car-addons")
    }
    await fetch(url, {
        method: "GET",
        headers: {
            Accept: '*/*',
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(electricCar),
    });
    render();
}




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


///// DISPLAY GAS CAR /////
function displayGasCar(gasCarId) {
    const apiUrl = '/api/gascars/' + gasCarId; // Replace with your actual API endpoint.
    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            document.getElementById('gas-car-make').innerText = data.make;
            document.getElementById('gas-car-model').innerText = data.model;
            document.getElementById('gas-car-year').innerText = data.year;
            document.getElementById('gas-car-range').innerText = data.range;
            document.getElementById('gas-car-price').innerText = data.price;
            document.getElementById('gas-car-mpg').innerText = data.mpg;
            document.getElementById('gas-car-addons').innerText = data.addOn;
        })
        .catch(error => {
            console.error('Error fetching gas car data:', error);
        });
}

///// DISPLAY ELECTRIC CAR /////
function displayElectricCar(electricCarId) {
    const apiUrl = '/api/electriccars/' + electricCarId; // Replace with your actual API endpoint.
    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            document.getElementById('electric-car-make').innerText = data.make;
            document.getElementById('electric-car-model').innerText = data.model;
            document.getElementById('electric-car-year').innerText = data.year;
            document.getElementById('electric-car-range').innerText = data.range;
            document.getElementById('electric-car-price').innerText = data.price;
            document.getElementById('electric-car-kwh').innerText = data.kwh;
            document.getElementById('electric-car-addons').innerText = data.addOn;
        })
        .catch(error => {
            console.error('Error fetching electric car data:', error);
        });
}

