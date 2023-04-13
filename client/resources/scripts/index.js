const gasCarUrl = "http://localhost:5104/api/gascar";
const electricCarUrl = "http://localhost:5104/api/electriccar";
const pairUrl = "http://localhost:5104/api/pair";

const render = () => {
    getGasCars();
    getElectricCars();
    getPairs();
}

function populateCarDropdown() {
    fetch('/api/gascar')
        .then(response => response.json())
        .then(gasCars => {
            gasCars.forEach(gasCar => {
                addCarOptionToDropdown('gas', gasCar);
            });
        })
        .catch(error => {
            console.error('Error fetching gas cars:', error);
        });

    fetch('/api/electriccar')
        .then(response => response.json())
        .then(electricCars => {
            electricCars.forEach(electricCar => {
                addCarOptionToDropdown('electric', electricCar);
            });
        })
        .catch(error => {
            console.error('Error fetching electric cars:', error);
        });
}

function addCarOptionToDropdown(carType, car) {
    const carDropdown = document.getElementById('car-dropdown');
    const option = document.createElement('option');
    option.value = carType + '-' + car.id; // Set the option value to be a combination of car type and ID
    option.innerText = car.make + ' ' + car.model + ' ' + car.year; // Set the option text to show the car's make, model, and year
    carDropdown.appendChild(option);
}

document.getElementById('car-dropdown').addEventListener('change', (event) => {
    const [carType, carId] = event.target.value.split('-'); // Split the value into car type and ID
    if (carType === 'gas') {
        displayGasCar(carId);
    } else if (carType === 'electric') {
        displayElectricCar(carId);
    }
});

populateCarDropdown();


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

// Add the event listeners to the select elements
document.getElementById('gas-car-select').addEventListener('change', (event) => {
    const gasCarId = event.target.value;
    if (gasCarId) {
        displayGasCar(gasCarId);
    }
});

document.getElementById('electric-car-select').addEventListener('change', (event) => {
    const electricCarId = event.target.value;
    if (electricCarId) {
        displayElectricCar(electricCarId);
    }
});

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


