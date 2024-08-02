-- Drop the database if it exists
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'PizzaOrderSystem')
BEGIN
    DROP DATABASE PizzaOrderSystem;
END
GO

-- Create the database
CREATE DATABASE PizzaOrderSystem;
GO

-- Use the newly created database
USE PizzaOrderSystem;
GO

-- Create the Crust table
CREATE TABLE Crust (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    type NVARCHAR(100) NOT NULL
);

-- Create the Size table
CREATE TABLE Size (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    description NVARCHAR(100) NOT NULL,
    price DECIMAL(10,2) NOT NULL
);

-- Create the Customer table
CREATE TABLE Customer (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(20) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    address NVARCHAR(200) NOT NULL,
    password NVARCHAR(100) NOT NULL,
	isadmin BIT NOT NULL,
    state BIT NOT NULL
);

-- Create the Toppings table
CREATE TABLE Toppings (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

-- Create the Sides table
CREATE TABLE Sides (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

-- Create the Drinks table
CREATE TABLE Drinks (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

-- Create the Pizza table
CREATE TABLE Pizza (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    crustID INT,
    sizeID INT,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (crustID) REFERENCES Crust(ID),
    FOREIGN KEY (sizeID) REFERENCES Size(ID)
);

-- Create the PizzaTopping table
CREATE TABLE PizzaTopping (
    pizzaID INT,
    toppingID INT,
    PRIMARY KEY (pizzaID, toppingID),
    FOREIGN KEY (pizzaID) REFERENCES Pizza(ID),
    FOREIGN KEY (toppingID) REFERENCES Toppings(ID)
);

-- Create the Order table
CREATE TABLE [Order] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    orderDate DATE NOT NULL,
    orderTime TIME NOT NULL,
    customerID INT,
    shippingAddress NVARCHAR(100) NOT NULL,
    FOREIGN KEY (customerID) REFERENCES Customer(ID)
);

-- Create the PizzaOrder table
CREATE TABLE PizzaOrder (
    pizzaID INT,
    orderID INT,
    quantity INT NOT NULL,
    PRIMARY KEY (pizzaID, orderID),
    FOREIGN KEY (pizzaID) REFERENCES Pizza(ID),
    FOREIGN KEY (orderID) REFERENCES [Order](ID)
);

-- Create the SideOrder table
CREATE TABLE SideOrder (
    sideID INT,
    orderID INT,
    quantity INT NOT NULL,
    PRIMARY KEY (sideID, orderID),
    FOREIGN KEY (sideID) REFERENCES Sides(ID),
    FOREIGN KEY (orderID) REFERENCES [Order](ID)
);

-- Create the DrinkOrder table
CREATE TABLE DrinkOrder (
    drinkID INT,
    orderID INT,
    quantity INT NOT NULL,
    PRIMARY KEY (drinkID, orderID),
    FOREIGN KEY (drinkID) REFERENCES Drinks(ID),
    FOREIGN KEY (orderID) REFERENCES [Order](ID)
);

-- Insert data into Crust table
INSERT INTO Crust (type) VALUES
('Normal'),
('Cheesy'),
('Sausage');

-- Insert data into Size table
INSERT INTO Size (description, price) VALUES
('Small', 4.00),
('Medium', 7.00),
('Large', 10.00),
('Extra Large', 13.00);

-- Insert data into Toppings table
INSERT INTO Toppings (name, price) VALUES
('Pepperoni', 0.75),
('Extra Cheese', 0.75),
('Mushroom', 0.75),
('Ham', 0.75),
('Bacon', 0.75),
('Ground Beef', 0.75),
('Jalapeno', 0.75),
('Pineapple', 0.75),
('Dried Shrimps', 0.75),
('Anchovies', 0.75),
('Sun Dried Tomatoes', 0.75),
('Spinach', 0.75),
('Roasted Garlic', 0.75),
('Shredded Chicken', 0.75);

-- Insert data into Drinks table
INSERT INTO Drinks (name, price) VALUES
('Coke', 1.45),
('Diet Coke', 1.45),
('Iced Tea', 1.45),
('Ginger Ale', 1.45),
('Sprite', 1.45);

-- Insert data into Sides table
INSERT INTO Sides (name, price) VALUES
('Chicken Wings', 3.00),
('Poutine', 3.00),
('Onion Rings', 3.00),
('Cheesy Garlic Bread', 3.00),
('Garlic Dip', 0.00);
