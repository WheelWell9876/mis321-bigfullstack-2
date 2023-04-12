USE p6nr5re8fmcvgnki;

-- ADMIN
CREATE TABLE IF NOT EXISTS admin (
adminID VARCHAR(255) PRIMARY KEY,
adminEmail TEXT NOT NULL,
adminMassword TEXT NOT NULL,
adminSecurityKey TEXT NOT NULL
);

-- USERS
CREATE TABLE IF NOT EXISTS users (
userID VARCHAR(255) PRIMARY KEY,
userEmail TEXT NOT NULL,
userMassword TEXT NOT NULL
);

-- GAS CARS
CREATE TABLE IF NOT EXISTS gasCars (
gasCarID VARCHAR(255) PRIMARY KEY,
gasCarMake TEXT NOT NULL,
gasCarModel TEXT NOT NULL,
gasCarYear INTEGER NOT NULL,
gasCarRange INTEGER NOT NULL DEFAULT 0,
gasCarPrice DOUBLE NOT NULL DEFAULT 0,
gasCarMpg DOUBLE NOT NULL DEFAULT 0,
gasCarAddOn TEXT NOT NULL
);
                
                
-- ELECTRIC CARS
CREATE TABLE IF NOT EXISTS electricCars (
electricCarID VARCHAR(255) PRIMARY KEY,
electricCarMake TEXT NOT NULL,
electricCarModel TEXT NOT NULL,
electricCarYear INTEGER NOT NULL,
electricCarRange INTEGER NOT NULL DEFAULT 0,
electricCarPrice DOUBLE NOT NULL DEFAULT 0,
electricCarKwh DOUBLE NOT NULL DEFAULT 0,
electricCarAddOn TEXT NOT NULL
);

-- PAIRS
CREATE TABLE IF NOT EXISTS car_pairs (
pairID VARCHAR(255) PRIMARY KEY,
gasCarID VARCHAR(255),
electricCarID VARCHAR(255),
userID VARCHAR(255)
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