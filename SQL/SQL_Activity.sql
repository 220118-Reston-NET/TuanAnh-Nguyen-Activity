--------TUAN ANH NGUYEN--------

--CREATING TABLES
CREATE TABLE Salemans(
	salemanId int PRIMARY KEY,
	salemanName varchar(50),
	phoneNumber varchar(12)
)

CREATE TABLE Routes(
	routeId int PRIMARY KEY,
	routeName varchar(3)
)

CREATE TABLE Products(
	productId int PRIMARY KEY,
	productName varchar(30)
)

--CREATING Many to Many TABLES
CREATE TABLE Saleman_Routes(
	salemanId int FOREIGN KEY REFERENCES Salemans(salemanId),
	routeId int FOREIGN KEY REFERENCES Routes(routeId)
)

CREATE TABLE Saleman_Products(
	salemanId int FOREIGN KEY REFERENCES Salemans(salemanId),
	productId int FOREIGN KEY REFERENCES Products(productId)
)

--DROP TABLES
DROP TABLE Salemans
DROP TABLE Routes
DROP TABLE Products
DROP TABLE Saleman_Routes
DROP TABLE Saleman_Products

--INSERT VALUES TO TABLE
INSERT INTO Salemans
VALUES (1, 'Bob The Builder', '510-BUI-LDIT'),
		(2, 'Fred Belotte', '415-HEY-FRED'),
		(3, 'Nick Enscalada', '888-GET-COFI'),
		(4, 'Pushpinder Kaur', '213-TRA-INER'),
		(5, 'Mark "Less is" Moore', '635-SLI-DES!'),
		(6, 'Jacob Davis', '415-SEA-HAWK'),
		(7, 'Marielle The Martian', '510-FLY-MARS')
		
SELECT * FROM Salemans 


INSERT INTO Routes
VALUES (1, 'SFO'), (2, 'LAX'),
		(3, 'DFW'), (4, 'IAH'),
		(5, 'SAT'), (6, 'DAL'),
		(7, 'AUS'), (8, 'TPA'),
		(9, 'SEA'), (10, 'STL'),
		(11, 'OAK'), (12, 'MNL')

SELECT * FROM Routes


INSERT INTO Products 
VALUES (1, 'hammer'), (2, 'nails'),
		(3, 'screws'), (4, 'pizza'),
		(5, 'coffee'), (6, 'espresso'),
		(7, 'latte'), (8, 'cookies'),
		(9, 'cakes'), (10, 'books'),
		(11, 'tea'), (12, 'hot chocolate')

SELECT * FROM Products


INSERT INTO Saleman_Routes 
VALUES (1, 1), (1, 2),
		(2, 3), (2, 4), (2, 5), 
		(3, 6), (3, 4), (3, 7),
		(4, 8), (4, 3), (4, 6),
		(5, 3),
		(6, 9), (6, 10), (6, 4),
		(7, 11), (7, 1), (7, 12), (7, 6)

SELECT * FROM Saleman_Routes 


INSERT INTO Saleman_Products 
VALUES (1, 1), (1, 2), (1, 3),
		(2, 4),
		(3, 5), (3, 6), (3, 7),
		(4, 8), (4, 9),
		(5, 10),
		(6, 5),
		(7, 5), (7, 11), (7, 12)
		
SELECT * FROM Saleman_Products 


-------- Get Routes of Saleman named = 'Marielle The Martian'
SELECT r.routeName as Routes
FROM Salemans s
INNER JOIN Saleman_Routes sr ON s.salemanId = sr.salemanId
INNER JOIN Routes r ON sr.routeId  = r.routeId
WHERE s.salemanName = 'Marielle The Martian'

-------- Get all saleman names that have route 'IAH' and product 'coffee'
SELECT s.salemanName as Name
FROM Salemans s
INNER JOIN Saleman_Routes sr ON s.salemanId = sr.salemanId
INNER JOIN Routes r ON sr.routeId  = r.routeId
INNER JOIN Saleman_Products sp ON s.salemanId = sp.salemanId
INNER JOIN Products p ON sp.productId = p.productId 
WHERE r.routeName = 'IAH' AND p.productName = 'coffee' 
	AND s.salemanId = sr.salemanId AND sr.routeId = r.routeId 
	AND s.salemanId = sp.salemanId AND sp.productId = p.productId

-----------------------------------

SELECT s.salemanName as Name, s.phoneNumber as 'Phone Number', STRING_AGG(r.routeName, ', ') as Routes
FROM Salemans s
INNER JOIN Saleman_Routes sr ON s.salemanId = sr.salemanId
INNER JOIN Routes r ON sr.routeId  = r.routeId
GROUP BY s.salemanName, s.phoneNumber


SELECT s.salemanName as Name, STRING_AGG(p.productName, ', ') as Products
FROM Salemans s
LEFT JOIN Saleman_Products sp ON s.salemanId = sp.salemanId
LEFT JOIN Products p ON sp.productId = p.productId
GROUP BY s.salemanName

SELECT STRING_AGG(p1.productName, ', ') as Products
FROM Salemans s1
RIGHT JOIN Saleman_Products sp ON s1.salemanId = sp.salemanId
RIGHT JOIN Products p1 ON sp.productId = p1.productId
GROUP BY s1.salemanName

SELECT s.salemanName as Name, s.phoneNumber as 'Phone Number', sri.Routes as Routes, spi.Products as Products
FROM Salemans s, 
	(
		SELECT s1.salemanId as IDs, STRING_AGG(p1.productName, ', ') as Products
		FROM Salemans s1
		INNER JOIN Saleman_Products sp1 ON s1.salemanId = sp1.salemanId
		INNER JOIN Products p1 ON sp1.productId = p1.productId
		GROUP BY s1.salemanId
	) spi,
	(
		SELECT s2.salemanId as IDs, STRING_AGG(r1.routeName, ', ') as Routes
		FROM Salemans s2
		INNER JOIN Saleman_Routes sr1 ON s2.salemanId = sr1.salemanId
		INNER JOIN Routes r1 ON sr1.routeId = r1.routeId
		GROUP BY s2.salemanId
	) sri
WHERE s.salemanId = spi.IDs AND s.salemanId = sri.IDs
GROUP BY s.salemanName, s.phoneNumber, sri.Routes, spi.Products

