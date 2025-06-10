SELECT setval(pg_get_serial_sequence('"Employees"', 'EmployeeID'), MAX("EmployeeID")) FROM "Employees";
SELECT setval(pg_get_serial_sequence('"Departments"', 'DepartmentID'), MAX("DepartmentID")) FROM "Departments";
SELECT setval(pg_get_serial_sequence('"Jobs"', 'JobID'), MAX("JobID")) FROM "Jobs";