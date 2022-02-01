----- DDL -------
--Data Definition Language----
--Create statement used to create tables
CREATE TABLE Pokemon(
	pokeName varchar(50),
	pokeLevel int,
	pokeAttack int,
	pokeDefense int,
	pokeHealth int,
)

--Alter statement is used to change existing tables
ALTER TABLE Pokemon 
ADD pokeSpecies varchar(50)

ALTER TABLE Pokemon
DROP COLUMN pokeSpecies

--Truncate statement 


--Drop statement will remove the table from our database
DROP TABLE Pokemon

------- DML --------
-- Data Manipulation Language---
--Insert statement is used to add data to the table
INSERT INTO Pokemon
VALUES('Ditto', 10, 55, 52, 100),
	('Bulbasuar', 10, 52, 58, 100)

--Select statement is used to grab data from a table
SELECT pokeName, pokeLevel  FROM Pokemon
--* means to select every column inside of the table
SELECT * FROM Pokemon

--Update statement is used to update data from a table
UPDATE Pokemon SET pokeHealth = 80
WHERE pokeName = 'Bulbasuar'

--Delete statment is used to delete data from a table 
DELETE FROM Pokemon 
WHERE pokeName = 'Ditto'



------- DQL --------
-- Data Query Language---
SELECT pokeName, pokeLevel  FROM Pokemon

SELECT * FROM Pokemon

SELECT pokeName , pokeLevel  FROM Pokemon
WHERE pokeName  = 'Ditto'

--Aliasing, basically renaming a column name
SELECT pokeName as Name, pokeLevel FROM Pokemon

---------------Constraints-------------
-- They are a way for you to limit the data that will come to your table (hence the name "constraints")
-- It is possible to specify more than one constraints 

--Type
--Restricts what datatype can be put in a column 

--Unique
--Data in this column cannot have replicating values
CREATE TABLE Pokemon(
	pokeName varchar(50) UNIQUE,
	pokeLevel int,
	pokeAttack int,
	pokeDefense int,
	pokeHealth int,
)

ALTER TABLE Pokemon 
ADD CONSTRAINT pokeName UNIQUE(pokeName)

ALTER TABLE Pokemon 
DROP CONSTRAINT pokeName

--Not null
--Data in this column cannot be null 
CREATE TABLE Pokemon(
	pokeName varchar(50) UNIQUE NOT NULL,
	pokeLevel int,
	pokeAttack int,
	pokeDefense int,
	pokeHealth int,
)

ALTER TABLE Pokemon 
ALTER COLUMN pokeName varchar(50) NOT NULL 

INSERT INTO Pokemon
VALUES('Ditto', NULL, NULL, NULL, NULL)

--DEFAULT
--Will provide a default value in case a value was not provide 

--Check
--Adds an extra condition on the data 
--pokeLevel > 10

--Primary KEY 
--Data in this column is both unique and not null
--Acts as a unique identifier for ther row in a table 

--Foreign Key 
--Data in this column references another row from a different column 
--Used mainly to establish relationships between two tables 


--------------Multiplicity------------------
--It is a way to describe the relationships between 2 tables 
--We will use primary keys and foreigns keys to establish it 

--One to One 
--One row in Table A is directly related to one row in Table B and it goes 
CREATE TABLE Person(
	SSN int PRIMARY KEY,
	personName varchar(50),
	personAge int,
)

--DROP TABLE Person

CREATE TABLE Heart(
	heartId int PRIMARY KEY,
	heartSize int,
	healthy bit,
	personSSN int UNIQUE FOREIGN KEY REFERENCES Person(SSN)
)

--DROP TABLE Heart


INSERT INTO Person 
VALUES (1, 'Kira', 29)

INSERT INTO Person 
VALUES (2, 'Emily', 28)

INSERT INTO Heart 
VALUES (1, 10, 1, 1)

INSERT INTO Heart 
VALUES (2, 101, 1, 2)

SELECT * FROM Person p 
INNER JOIN Heart h ON p.SSN = h.personSSN 

SELECT p.personName, h.healthy  FROM Person p 
INNER JOIN Heart h ON p.SSN = h.personSSN
WHERE p.personName = 'Emily'

-- One to Many 
--One row in Table A is related to multiple rows in Table B 
CREATE TABLE Finger(
	fingerId int PRIMARY KEY,
	fingerLength int
)

ALTER TABLE Finger
ADD personSSN int FOREIGN KEY REFERENCES Person(SSN)

INSERT INTO Finger 
VALUES (1, 10, 1),
		(2, 5, 1),
		(3, 5, 1)

SELECT *  FROM Person p 
INNER JOIN Finger f ON p.SSN = f.personSSN

--Many to Many 
--Many rows in Table A has many rows in Table B 
--You must create a join table to create many to many relationships 

CREATE TABLE Ability(
	abId int PRIMARY KEY,
	abName varchar(50),
	abPP int,
	abPower int,
	abAccuracy int,
)

INSERT INTO Ability
--VALUES(1, 'Tackle', 52, 55, 80),
	VALUES	(2, 'Thunderbolt', 52, 55, 100)

DROP TABLE Pokemon

CREATE TABLE Pokemon(
	pokeId int PRIMARY KEY,
	pokeName varchar(50),
	pokeLevel int,
	pokeAttack int,
	pokeDefense int,
	pokeHealth int,
)

INSERT INTO Pokemon
VALUES(1, 'Ditto', 10, 55, 52, 100),
	(2, 'Bulbasuar', 10, 52, 58, 100)
	

CREATE TABLE Pokemon_abilities(
	abId int FOREIGN KEY REFERENCES Ability(abId),
	pokeId int FOREIGN KEY REFERENCES Pokemon(pokeId)
)

INSERT INTO Pokemon_abilities 
VALUES (1, 1),
		(1, 2),
		(2, 2) 
		
		
SELECT a.abName, p.pokeName FROM Ability a 
INNER JOIN Pokemon_abilities pa ON a.abId = pa.abId
INNER JOIN Pokemon p ON p.pokeId = pa.pokeId



------------Normalization------------
--It is design pattern that reduces/eliminates data redudancy/data duplication
--Must have Referential Integerity and atomic data 
	--Referential intergerity just means that a goreign key will always point to an existing primary key  
	--atomic data just means the data in your table is at its smallest form

--ONF - Zero Normal Form
--No normalization

--1NF - First Normal Form 
--Every table must have a primary key 
--Must have Atomic data

--2NF - Second Normal Form 
--You must be in 1NF
--Remove any partial dependencies
	-- Just don't do composite primary keys 

--3NF - Third Normal Form 
--You must be in 2NF 
--Remove any transitive dependencies 
	-- Make sure that every column in that table is actually related to the data you are storing 
	-- Ex: Pokemon table shouldn't have ability name, pp, acurracy but Ability should be created instead



