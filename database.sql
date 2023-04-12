USE p6nr5re8fmcvgnki;

-- ADMIN
CREATE TABLE IF NOT EXISTS admin (
adminId VARCHAR(255) PRIMARY KEY,
email TEXT NOT NULL,
massword TEXT NOT NULL,
securityKey TEXT NOT NULL
);

-- USERS
CREATE TABLE IF NOT EXISTS users (
userId VARCHAR(255) PRIMARY KEY,
email TEXT NOT NULL,
massword TEXT NOT NULL
);

-- GAS CARS
CREATE TABLE IF NOT EXISTS gasCars (
gasCarId VARCHAR(255) PRIMARY KEY,
make TEXT NOT NULL,
model TEXT NOT NULL,
gasCarYear INTEGER NOT NULL,
gasCarRange INTEGER NOT NULL DEFAULT 0,
price DOUBLE NOT NULL DEFAULT 0,
mpg DOUBLE NOT NULL DEFAULT 0,
addOn TEXT NOT NULL
);
                
                
-- ELECTRIC CARS
CREATE TABLE IF NOT EXISTS electricCars (
electricCarId VARCHAR(255) PRIMARY KEY,
make TEXT NOT NULL,
model TEXT NOT NULL,
electricCarYear INTEGER NOT NULL,
electricCarRange INTEGER NOT NULL DEFAULT 0,
price DOUBLE NOT NULL DEFAULT 0,
kwh DOUBLE NOT NULL DEFAULT 0,
addOn TEXT NOT NULL
);

-- PAIRS
CREATE TABLE IF NOT EXISTS car_pairs (
pairId VARCHAR(255) PRIMARY KEY,
gasCarId VARCHAR(255),
electricCarId VARCHAR(255),
userId VARCHAR(255)
);

-- INSERT INTO admin VALUES ('00719fc0-27e2-4de9-a4dd-306dbbbdd7ff','tom@gmail.com','lastpass','tom1');
-- INSERT INTO users VALUES ('05893524-dd79-4801-83ee-50dce7277d10 ','bill@gmail.com','Grant','guy');
-- INSERT INTO gasCars VALUES ('00719fc0-27e2-4de9-a4dd-306dbbbdd7ff ','Toyota','4Runner','1999','435.1','15.7','T6');
-- INSERT INTO electricCars VALUES ('20693442-8776-4dac-b900-5ad57cd50c98 ','Nissan','Leaf','2008','49.6','200.7','P7');
-- INSERT INTO car_pairs VALUES ('33d4024b-5a05-444f-85b4-563afb3b3362 ','6b7ce1fe-6e2c-4d33-8792-da598563ba92','89af36da-ae6b-4c0e-a7f8-0bc35a9f6fd9','9e9511d7-19cb-4c0d-b085-17f7fbeb0dce');


SELECT * FROM p6nr5re8fmcvgnki.admin;
SELECT * FROM p6nr5re8fmcvgnki.users;
SELECT * FROM p6nr5re8fmcvgnki.gasCars;
SELECT * FROM p6nr5re8fmcvgnki.electricCars;
SELECT * FROM p6nr5re8fmcvgnki.car_pairs;