# Planning Document
# Hair Salon
Create an MVC web application for a hair salon. The owner should be able to ADD STYLIST, and for each stylist, ADD CLIENT who see that stylist. The stylists work independently, so each client only belongs to a single stylist.

## User Stories
Salon employees should to be able to:
* VIEW ALL STYLISTS,
* ADD STYLIST
* FIND STYLIST,
* VIEW STYLIST DETAILS,
* VIEW LIST OF ALL STYLIST CLIENTS.
* ADD CLIENT TO STYLIST
* A client cannot be added if no stylists have been added.

## Requirements
**Naming**
* Use your first name and last name to name your databases in the following way:

- Production Database: first_last
- Test Database: first_last_test
* Use the following names for your directories:

- Main Project Folder: HairSalon
- Test Project Folder: HairSalon.Tests

### Classes
* Client
* Stylist

### Stylist database columns/class properties
- id: PRIMARY KEY, AUTO_INCREMENT
- first_name
- last_name

### Client database columns/class properties
- id: PRIMARY KEY, AUTO_INCREMENT
- first_name
- last_name
- phone_number
- stylist_id: FOREIGN KEY

## Models/Methods
### Client
- public int GetId()
- public string GetFirstName()
- public string GetLastName()
- public string GetPhoneNumber()
- public List<Client> GetAll()
- public void Save()
- public Client Find(int id)

**FOR TESTING HOUSEKEEPING:**
- public override bool Equals(System.Object otherClient)
- public void ClearAll()

### Stylist
- public int GetId()
- public string GetFirstName()
- public string GetLastName()
- public List<Stylist> GetAll()
- public void Save()
- public Stylist Find(int id)
- public List<Client> GetClients()

**FOR TESTING HOUSEKEEPING:**
- public override bool Equals(System.Object otherClient)
- public void ClearAll()

### HomeController
[HttpGet("/")] Index()

### ClientController
[HttpGet("/clients")] Index() - @Model: none  
[HttpGet("/clients/new")] New(int stylistId) - @Model: none  
[HttpPost("/clients")] Create() - @Model: Dictionary<string, object>  
[HttpGet("/clients/show")] Show(int id) - @Model: Dictionary<string, object>

### StylistController
[HttpGet("/stylists")] Index() - @Model: none  
[HttpGet("/stylists/new")] New() - @Model: none  
[HttpPost("/stylists")] Create() - @Model: Dictionary<string, object>  
[HttpGet("/stylists/show")] Show(int id) - @Model: Dictionary<string, object>  

## BUILD DATABASE
CREATE DATABASE scott_bergler;  

CREATE TABLE `scott_bergler`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `first_name` VARCHAR(255) NOT NULL , `last_name` VARCHAR(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;  

CREATE TABLE `scott_bergler`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `first_name` VARCHAR(255) NOT NULL , `last_name` VARCHAR(255) NOT NULL ,`phone_number` VARCHAR(255) NOT NULL , `stylist_id` INT(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

### BUILD TEST DATABASE
CREATE DATABASE scott_bergler_test;



CREATE TABLE `scott_bergler_test`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `first_name` VARCHAR(255) NOT NULL , `last_name` VARCHAR(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;



CREATE TABLE `scott_bergler_test`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `first_name` VARCHAR(255) NOT NULL , `last_name` VARCHAR(255) NOT NULL ,`phone_number` VARCHAR(255) NOT NULL , `stylist_id` INT(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

#### GENERAL STEPS TAKEN
Outline Classes/Tables  
Outline Models/Methods  
Create Database/tables  
Create Test Database  
Export Database  
Add Exported Database to HairSalon.Solution folder  
Create Models folder  
Create .cs file for each Class in Models folder  
Create ControllerTest file for each Class and Home  
Create ModelTests folder  
Create Test Files for each Class in the ModelTests folder  
Create basic content for all files  
Set up test files for working with the database  
Test that class properties can be retrieved  
Implement teardown using Dispose() and ClearAll() so that test data is cleared between each test  
Add Equals() method to type cast objects, "clients" in this case, that are in different parts of memory - one in RAM, one from the database - as the same object.  
Test that Save() saves to Database & GetAll() gets all clients.  

###  Specs
#### Client Model Specs
##### Spec: ClientConstructor returns Client
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: Client - Scott Bergler
##### Spec: Client returns client id
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: 1
##### Spec: Client returns client first name
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "Scott"
##### Spec: Client returns client last name
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "Bergler"
##### Spec: Client returns client phone number
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "5038905118"
##### Spec: Client returns stylist id
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: 1
##### Spec: Client returns empty list
**Example:**  
Input:
clientOne: ("Scott", "Bergler", "5038905118", 1, 1),  
clientTwo: ("Millicent", "Zimdars", "5034217832", 2, 1)  
Output: List<Client>{}
### Spec: Client clears database
**Example:**  
Input:
clientOne: ("Scott", "Bergler", "5038905118", 1, 1),  
clientTwo: ("Millicent", "Zimdars", "5034217832", 2, 1)  
Output: List<Client>{}
### Spec: Client saves to database
**Example:**  
Input:
clientOne: ("Scott", "Bergler", "5038905118", 1, 1),  
clientTwo: ("Millicent", "Zimdars", "5034217832", 2, 1)  
Output: List<Client>{clientOne, clientTwo}
##### Spec: Client returns a list of all clients
**Example:**  
Input:
clientOne: ("Scott", "Bergler", "5038905118", 1, 1),  
clientTwo: ("Millicent", "Zimdars", "5034217832", 2, 1)  
Output: List<Client>{clientOne, clientTwo}

##### Spec: Stylist deletes a client
**Example:**  
Input:
clientOne: ("Scott", "Bergler", "5038905118", 1, 1),  
clientTwo: ("Millicent", "Zimdars", "5034217832", 2, 1)  
Output: "Millicent", "Zimdars", "5034217832", 2, 1

#### Stylist Model Specs
##### Spec: StylistConstructor returns Stylist
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: Stylist - Scott Bergler
##### Spec: Stylist returns stylist id
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: 1
##### Spec: Stylist returns stylist first name
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "Scott"
##### Spec: Stylist returns stylist last name
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "Bergler"
##### Spec: Stylist returns stylist phone number
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: "5038905118"
##### Spec: Stylist returns stylist id
**Example:**  
Input:  "Scott", "Bergler", "5038905118", 1, 1  
Output: 1
##### Spec: Stylist returns empty list
**Example:**  
Input:
stylistOne: ("Stephan", "Blair", "5109083751", 1, 1),  
stylistTwo: ("Holly", "Kindred", "312859047", 2, 1)  
Output: List<Stylist>{}
### Spec: Stylist clears database
**Example:**  
Input:
stylistOne: ("Stephan", "Blair", "5109083751", 1, 1),  
stylistTwo: ("Holly", "Kindred", "312859047", 2, 1)  
Output: List<Stylist>{}
### Spec: Stylist saves to database
**Example:**  
Input:
stylistOne: ("Stephan", "Blair", "5109083751", 1, 1),  
stylistTwo: ("Holly", "Kindred", "312859047", 2, 1)  
Output: List<Stylist>{stylistOne, stylistTwo}
##### Spec: Stylist adds new stylist
**Example:**  
Input: stylistOne: ("Stephan", "Blair", "5109083751", 1, 1)  
Output: List<Stylist>{stylistOne}
##### Spec: Stylist adds new client
**Example:**  
Input: clientOne: ("Scott", "Bergler", "5038905118", 1, 1)  
Output: List<Client>{clientOne}
##### Spec: Stylist returns a list of all stylists
**Example:**  
Input:
stylistOne: ("Stephan", "Blair", "5109083751", 1, 1),  
stylistTwo: ("Holly", "Kindred", "312859047", 2, 1)  
Output: List<Stylist>{stylistOne, stylistTwo}
##### Spec: Stylist deletes a stylist
**Example:**  
Input:
stylistOne: ("Stephan", "Blair", "5109083751", 1, 1),  
stylistTwo: ("Holly", "Kindred", "312859047", 2, 1)  
Output: "Holly", "Kindred", "312859047", 2, 1
