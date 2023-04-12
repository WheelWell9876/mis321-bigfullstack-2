const gasCarUrl = "http://localhost:5104/api/gascar";
const electricCarUrl = "http://localhost:5104/api/electriccar";
const pairUrl = "http://localhost:5104/api/pair";

const render = () => {
    getGasCars();
    getElectricCars();
    getPairs();
}

//// GET GAS CARS ////
const getGasCars = function () {
    fetch(gasCarUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        displayGasCar(data);
    });
};

///// Get ELECTRIC Cars /////
const getElectricCars = function () {
    fetch(electricCarUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        displayElectricCar(data);
    });
};

///// Get PAIRS /////
const getPairs = function () {
    fetch(pairUrl).then(function (response) {
        return response.json();
    }).then(function(data){
        makePairTable(data);
    });
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


// DISPLAY GAS CAR
const displayGasCar = (gasCarId) => {
    const apiUrl = 'http://localhost:5104/api/gascar/' + gasCarId; // Replace with your actual API endpoint.
    const xhr = new XMLHttpRequest();
    xhr.open('GET', apiUrl, true);
    xhr.setRequestHeader('Accept', '*/*');
    xhr.onreadystatechange = () => {
        if (xhr.readyState === 4 && xhr.status === 200) {
            const gasCar = JSON.parse(xhr.responseText);
            document.getElementById('gas-car-make-display').innerText = gasCar.make;
            document.getElementById('gas-car-model-display').innerText = gasCar.model;
            document.getElementById('gas-car-year-display').innerText = gasCar.year;
            document.getElementById('gas-car-range-display').innerText = gasCar.range;
            document.getElementById('gas-car-price-display').innerText = gasCar.price;
            document.getElementById('gas-car-mpg-display').innerText = gasCar.mpg;
            document.getElementById('gas-car-addons-display').innerText = gasCar.addOn;
        }
    };
    xhr.send();
};

// DISPLAY ELECTRIC CAR
const displayElectricCar = (electricCarId) => {
    const apiUrl = 'http://localhost:5104/api/electriccar/' + electricCarId; // Replace with your actual API endpoint.
    const xhr = new XMLHttpRequest();
    xhr.open('GET', apiUrl, true);
    xhr.setRequestHeader('Accept', '*/*');
    xhr.onreadystatechange = () => {
        if (xhr.readyState === 4 && xhr.status === 200) {
            const electricCar = JSON.parse(xhr.responseText);
            document.getElementById('electric-car-make-display').innerText = electricCar.make;
            document.getElementById('electric-car-model-display').innerText = electricCar.model;
            document.getElementById('electric-car-year-display').innerText = electricCar.year;
            document.getElementById('electric-car-range-display').innerText = electricCar.range;
            document.getElementById('electric-car-price-display').innerText = electricCar.price;
            document.getElementById('electric-car-kwh-display').innerText = electricCar.kwh;
            document.getElementById('electric-car-addons-display').innerText = electricCar.addOn;
        }
    };
    xhr.send();
};