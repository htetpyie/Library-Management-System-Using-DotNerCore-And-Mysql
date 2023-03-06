# Library-Management-System-Using-DotNerCore-And-Mysql

```sql

CREATE TABLE Books (
   BookID INT IDENTITY(1,1) PRIMARY KEY,
   Title VARCHAR(100) NOT NULL,
   Author VARCHAR(50) NOT NULL,
   Publisher VARCHAR(50) NOT NULL,
   PublishDate DATE NOT NULL,
   ISBN VARCHAR(20) NOT NULL
);

CREATE TABLE Members (
   MemberID INT IDENTITY(1,1) PRIMARY KEY,
   FirstName VARCHAR(50) NOT NULL,
   LastName VARCHAR(50) NOT NULL,
   Email VARCHAR(100) NOT NULL,
   Phone VARCHAR(20) NOT NULL,
   Address VARCHAR(200) NOT NULL
);

CREATE TABLE Loans (
   LoanID INT IDENTITY(1,1) PRIMARY KEY,
   BookID INT NOT NULL,
   MemberID INT NOT NULL,
   LoanDate DATE NOT NULL,
   DueDate DATE NOT NULL,
   ReturnDate DATE NULL,
   CONSTRAINT FK_Loans_Books FOREIGN KEY (BookID) REFERENCES Books(BookID),
   CONSTRAINT FK_Loans_Members FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);

``` Data

INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('To Kill a Mockingbird', 'Harper Lee', 'J. B. Lippincott & Co.', '1960-07-11', '9780446310789');
INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('1984', 'George Orwell', 'Secker and Warburg', '1949-06-08', '9780451524935');
INSERT INTO books (title, author, publisher, PublishDate, isbn) VALUES ('The Great Gatsby', 'F. Scott Fitzgerald', 'Charles Scribner''s Sons', '1925-04-10', '9780743273565');
INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('One Hundred Years of Solitude', 'Gabriel Garcia Marquez', 'Editorial Sudamericana', '1967-06-05', '9780060883287');
INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('Pride and Prejudice', 'Jane Austen', 'T. Egerton, Whitehall', '1813-01-28', '9780141439518');
INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('The Catcher in the Rye', 'J. D. Salinger', 'Little, Brown and Company', '1951-07-16', '9780316769488');
INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('The Hobbit', 'J. R. R. Tolkien', 'George Allen & Unwin', '1937-09-21', '9780547928227');
INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('The Lord of the Rings', 'J. R. R. Tolkien', 'George Allen & Unwin', '1954-07-29', '9780345339706');
INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('The Da Vinci Code', 'Dan Brown', 'Doubleday', '2003-03-18', '9780307474278');
INSERT INTO books (title, author, publisher, publishDate, isbn) VALUES ('The Girl with the Dragon Tattoo', 'Stieg Larsson', 'Norstedts förlag', '2005-08-01', '9780307949486');

INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('John', 'Doe', 'johndoe@gmail.com', '123-456-7890', '123 Main St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('Jane', 'Doe', 'janedoe@gmail.com', '555-555-5555', '456 Elm St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('Bob', 'Smith', 'bobsmith@gmail.com', '123-456-7890', '789 Oak St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('Samantha', 'Jones', 'samanthajones@gmail.com', '555-555-5555', '987 Pine St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('David', 'Lee', 'davidlee@gmail.com', '123-456-7890', '246 Maple St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('Sarah', 'Johnson', 'sarahjohnson@gmail.com', '555-555-5555', '369 Spruce St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('Michael', 'Chang', 'michaelchang@gmail.com', '123-456-7890', '135 Cedar St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('Alicia', 'Garcia', 'aliciagarcia@gmail.com', '555-555-5555', '579 Birch St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('Peter', 'Kim', 'peterkim@gmail.com', '123-456-7890', '792 Walnut St, Anytown USA');
INSERT INTO members (firstName, lastName, email, phone, address) VALUES ('Lauren', 'Nguyen', 'laurennguyen@gmail.com', '555-555-5555', '246 Oakwood St, Anytown USA');

```
