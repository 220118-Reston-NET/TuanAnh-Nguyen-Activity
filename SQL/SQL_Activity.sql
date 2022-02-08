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





--------
---Create statement--
create table Employee(
	empId int identity(1,1) primary key,
	empName varchar(50),
	empSalary smallmoney
);

create table Department(
	depId int identity(1,1) primary key,
	depName varchar(50)
);

--Established relationships--
create table employees_departments(
	empId int foreign key references Employee(empId),
	depId int foreign key references Department(depId)
);

--Inserting values--
insert into Employee 
values('John Doe', 65000),
	('Ollie Abbott', 80000),
	('Emanual Dean', 110000),
	('Ernest Rowe', 55000),
	('Janice Oliver', 65000);

insert into Department
values ('Software Engineer'),
	('Manager');

insert into employees_departments 
values (1,1),
	(2,1),
	(3,2),
	(4,1),
	(5,1);
------Aggregation functions ------
--They are functions that will use all the data of a column to do some sort

--Count
--Will return how many rows there are in a column 
SELECT Count(e.empName) FROM Employee e

--SUM 
--Will add all the numbers in a column
SELECT Sum(e.empSalary) as 'Total Salaries' FROM Employee e 

--Avg
--Will average all the numbers in a column 
SELECT Avg(e.empSalary) as 'Average Salary' FROM Employee e 

--Min 
--Grabs the lowest numnber in a column 


--Max 
--Grabs the highest number in a column

--What if I want to show how many employess right now that have the same salary
SELECT Count(e.empName) as 'Total Employees', e.empSalary FROM Employee e 
GROUP BY e.empSalary 

-- Subquery ----

--I want to take all the average of all software engineer's salary 
SELECT Avg(empSalary) as 'Average Salary of SE' FROM Employee e 
INNER JOIN employees_departments ed ON e.empId = ed.empId
INNER JOIN Department d ON d.depId = ed.depId
WHERE d.depId = 1

--I want to select every software engineer that have a higher than average salary
SELECT e.empName, e.empSalary  FROM Employee e 
INNER JOIN employees_departments ed ON e.empId = ed.empId
INNER JOIN Department d ON d.depId = ed.depId
WHERE d.depId = 1 and e.empSalary  > (SELECT Avg(empSalary) as 'Average Salary of SE' FROM Employee e 
										INNER JOIN employees_departments ed ON e.empId = ed.empId
										INNER JOIN Department d ON d.depId = ed.depId
										WHERE d.depId = 1);

						
-- Joins ----
									
--Inner Join--
--It will show data from both tables if they match the condition
SELECT * FROM Employee e 
INNER JOIN employees_departments ed ON e.empId = ed.empId 
INNER JOIN Department d ON d.depId = ed.depId 
									
--Left Join
--It will show everything from the left table even if they didn't match to anything on the right 
SELECT * FROM Employee e 
LEFT JOIN employees_departments ed ON e.empId = ed.empId 
LEFT JOIN Department d ON d.depId = ed.depId

--Right join 
--It will show everything from the right table even if they didn't match to anything on the left table 
SELECT * FROM Employee e 
RIGHT JOIN employees_departments ed ON e.empId = ed.empId 
RIGHT JOIN Department d ON d.depId = ed.depId

--Full JOIN 
--It will show everything from both tables regardless if they match or NOT 
SELECT * FROM Employee e 
FULL JOIN employees_departments ed ON e.empId = ed.empId 
FULL JOIN Department d ON d.depId = ed.depId

--Set Operations
--Special type of JOIN 
--It doesn't care about matching anything unlike a join 
--It will combine two queries together but they need to be the same datatype and same # of column 

--Union
--It will only show duplicate value once
SELECT e.empName as 'Union' FROM Employee e 
UNION
SELECT d.depName FROM Department d 

SELECT d.depName FROM Department d 
UNION
SELECT d.depName FROM Department d 

--Union all 
--It will show duplicate value 
--It will show everything from both queries 
SELECT d.depName FROM Department d 
UNION ALL
SELECT d.depName FROM Department d 

--Except 
--It will show only unique values from the right query
--It will not ashow duplicated values 
SELECT d.depName FROM Department d 
EXCEPT
SELECT d.depName FROM Department d 

--Intersection
--It will show only duplicated values 
SELECT d.depName FROM Department d 
INTERSECT
SELECT d.depName FROM Department d 



------------------------------
------Stored Procedure -------
-- Almost like a function except it has certain unique things about 
-- You can return multiple things unlike C# methods
	-- It can accept input parameters and multiploe output parameters 
-- It can output multiple datatypes
-- You can have optional parameters 

-- Add data depending on what was given
CREATE PROCEDURE proc_addData(
	@name varchar(50) = NULL,
	@salary smallmoney = 10, -- By adding "=" I have made this parameter optional
	@department varchar(50) = NULL,
	@status bit OUTPUT--By adding output keyword, this parameter will return back after executing the procedure
)
AS 
BEGIN 
	--Adds data to Employee table if emplouee name was given
	--When comparing with a null value, you have to use is/is not null
	--When comparing with a normal value, you can use != or <>
	IF (@name IS NOT NULL)
	BEGIN 
		INSERT INTO Employee
		VALUES(@name, @salary);
		SET @status = 1;
	END
	
	IF (@department IS NOT NULL)
	BEGIN 
		INSERT INTO Department 
		VALUES(@department);
		SET @status = 1;
	END
	
	--status fails if both optional parameters was not given
	IF (@name IS NULL)
	BEGIN 
		IF(@department = NULL)
		BEGIN 
			SET @status = 0;
		END
	END
END;

DROP PROCEDURE proc_addData;

DECLARE @currentStatus bit;
DECLARE @moneys smallmoney = 100000.0000
EXEC proc_addData @name = 'Jose', @salary = @moneys, @department = 'CEO', @status = @currentStatus OUTPUT
SELECT @currentStatus;


--- Triggers ----
-- They are a special type of stored procedure
-- They will run when a certain event happens such as insert, update, delete, or etc.

--
CREATE TRIGGER trig_employee_added ON Employee
AFTER INSERT 
AS
BEGIN 
	UPDATE Employee 
	SET empSalary = empSalary - 1000;
END;

INSERT INTO Employee 
VALUES('Terrance', 500);



