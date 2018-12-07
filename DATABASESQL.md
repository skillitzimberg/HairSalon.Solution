## BUILD DATABASE & TEST DATABASE
CREATE DATABASE scott_bergler;  

CREATE TABLE scott_bergler.stylists ( id INT NOT NULL AUTO_INCREMENT , first_name VARCHAR(255) NOT NULL , last_name VARCHAR(255) NOT NULL , PRIMARY KEY (id)) ENGINE = InnoDB;  

CREATE TABLE scott_bergler.clients ( id INT NOT NULL AUTO_INCREMENT , first_name VARCHAR(255) NOT NULL , last_name VARCHAR(255) NOT NULL ,phone_number VARCHAR(255) NOT NULL , stylist_id INT(255) NOT NULL , PRIMARY KEY (id)) ENGINE = InnoDB;

USE scott_bergler  

CREATE DATABASE scott_bergler_test;

CREATE TABLE scott_bergler_test.stylists ( id INT NOT NULL AUTO_INCREMENT , first_name VARCHAR(255) NOT NULL , last_name VARCHAR(255) NOT NULL , PRIMARY KEY (id)) ENGINE = InnoDB;

CREATE TABLE scott_bergler_test.clients ( id INT NOT NULL AUTO_INCREMENT , first_name VARCHAR(255) NOT NULL , last_name VARCHAR(255) NOT NULL ,phone_number VARCHAR(255) NOT NULL , stylist_id INT(255) NOT NULL , PRIMARY KEY (id)) ENGINE = InnoDB;
