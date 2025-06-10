CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Location VARCHAR(100)
);

CREATE TABLE Jobs (
    JobID INT PRIMARY KEY,
    JobTitle VARCHAR(100),
    JobLevel VARCHAR(50)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    HireDate DATE,
    DepartmentID INT,
    JobID INT,
    Salary DECIMAL(10,2),
    Status VARCHAR(20),
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    FOREIGN KEY (JobID) REFERENCES Jobs(JobID)
);

CREATE TABLE JobHistory (
    HistoryID INT PRIMARY KEY,
    EmployeeID INT,
    JobID INT,
    DepartmentID INT,
    StartDate DATE,
    EndDate DATE,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (JobID) REFERENCES Jobs(JobID),
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);
