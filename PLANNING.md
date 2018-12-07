# Planning Document
# Hair Salon
Create an MVC web application for a hair salon. The owner should be able to ADD STYLIST, and for each stylist, ADD CLIENT who see that stylist. The stylists work independently, so each client only belongs to a single stylist.

## User Stories
Salon employees should to be able to:
VIEW ALL STYLISTS,
ADD STYLIST
FIND STYLIST,
VIEW STYLIST DETAILS,
VIEW LIST OF ALL STYLIST CLIENTS.
ADD CLIENT TO STYLIST
A client cannot be added if no stylists have been added.

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

* FOR TESTING HOUSEKEEPING:
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

* FOR TESTING HOUSEKEEPING:
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

### CREATE DATABASE scott_bergler
### CREATE TABLE `scott_bergler`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `first_name` VARCHAR(255) NOT NULL , `last_name` VARCHAR(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

### CREATE TABLE `scott_bergler`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `first_name` VARCHAR(255) NOT NULL , `last_name` VARCHAR(255) NOT NULL ,`phone_number` VARCHAR(255) NOT NULL , `stylist_id` INT(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

* Outline Classes/Tables
* Outline Models/Methods
* Create Database/tables
* Create Test Database
* Export Database
* Add Exported Database to HairSalon.Solution folder
* Create Models folder
* Create .cs file for each Class in Models folder
* Create ControllerTest file for each Class and Home
* Create ModelTests folder
* Create Test Files for each Class in the ModelTests folder
* Create basic content for all files
* Set up test files for working with the database
* Test that class properties can be retrieved
* Implement teardown using Dispose() and ClearAll() so that test data is cleared between each test
* Add Equals() method to type cast objects, "clients" in this case, that are in different parts of memory - one in RAM, one from the database - as the same object.
* Test that Save() saves to Database & GetAll() gets all clients.


### Stylist Columns/Properties
* ID
* Name

### Client Columns/Properties
* ID
* Name
* Region
* Maker
* Stylist ID

### Stylist Model
<!-- * public int GetId() -->
* public string GetName()
* public void Add()
* public void Delete()
* public List<Stylist> GetAll()
* public void Save()


### Client Model
<!-- * public int GetId() -->
* public string GetName()
* public void Add()
* public void Delete()
* public List<Client> GetAll()
* public void Save()

###  Specs
#### Client Model Specs
##### Spec 0: Client returns client
**Example:**
Input:  'Zinfandel', "Mexico", "Don Giovanni", 1, 1
Output: Client
##### Spec: Client returns client id
**Example:**
Input:  'Zinfandel', "Mexico", "Don Giovanni", 1, 1
Output: 1
##### Spec: Client returns client name
**Example:**
Input:  'Zinfandel', "Mexico", "Don Giovanni", 1, 1
Output: 'Zinfandel'
##### Spec: Client returns client region
**Example:**
Input:  'Zinfandel', "Mexico", "Don Giovanni", 1, 1
Output: "Mexico"
##### Spec: Client returns client maker
**Example:**
Input:  'Zinfandel', "Mexico", "Don Giovanni", 1, 1
Output: "Don Giovanni"
##### Spec: Client returns stylist id
**Example:**
Input:  'Zinfandel', "Mexico", "Don Giovanni", 1, 1
Output: 1
##### Spec: Client returns empty list
**Example:**
Input:
clientOne: ('Zinfandel', "Mexico", "Don Giovanni", 1, 1), clientTwo: ('PortoPort', "California", "Paul's Vineyard", 2, 1)
Output: List<Client>{}
### Spec: Test that ClearAll() clears database
**Example:**
Input:
clientOne: ('Zinfandel', "Mexico", "Don Giovanni", 1, 1), clientTwo: ('PortoPort', "California", "Paul's Vineyard", 2, 1)
Output: List<Client>{}
### Spec: Test that Save() saves to database
**Example:**
Input:
clientOne: ('Zinfandel', "Mexico", "Don Giovanni", 1, 1), clientTwo: ('PortoPort', "California", "Paul's Vineyard", 2, 1)
Output: List<Client>{clientOne, clientTwo}
##### Spec: Client returns a list of all clients
**Example:**
Input:
clientOne: ('Zinfandel', "Mexico", "Don Giovanni", 1, 1), clientTwo: ('PortoPort', "California", "Paul's Vineyard", 2, 1)
Output: List<Client>{clientOne, clientTwo}

##### Spec: Client add new client
**Example:**
Input: 'New Item: Cabernet'
Output: 'Cabernet'
******NOT TESTED *** TO BE CONTINUED***
##### Spec: Client delete from list array of things(Cabernet)
**Example:**
Input: 'Zinfandel' 'Cabernet'
Output: 'Cabernet'
##### Spec: Client saves item (new item)
**Example:**
Input:  'New Item: Cabernet'
Output: 'Cabernet'

#### Stylist Model Specs
##### Spec 1: StylistConstructor returns Stylist
**Example:**
Input: "test stylist", 2.
Output: Stylist

##### Spec 2: Stylist returns name (GetName_ReturnsName_String())
**Example:**
Input: "test stylist", 2
Output: "test stylist"
##### Spec 3: Stylist return id (GetId_ReturnsStylistId_Int())
**Example:**
Input: 2
Output: 2
##### Spec 4: Stylist add new item
**Example:**
Input: 'New Item: Cabernet'
Output: 'Cabernet'
##### Spec 3: Stylist delete from list array of things(Cabernet)
**Example:**
Input: 'Zinfandel' 'Cabernet'
Output: 'Cabernet'
##### Spec 4: Stylist returns a list of all varieties
**Example:**
Input: Method call
Output: 'Zinfandel' 'Cabernet'
##### Spec 5: Stylist saves item (new item)
**Example:**
Input:  'New Item: Cabernet'
Output: 'Cabernet'
