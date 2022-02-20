SELECT * FROM Departments;

-- COMMENTS
-- SELECT -> Getting Data from a table
-- * -> All
-- FROM -> Choosing the table(or view, or Stored Procedures)

SELECT * FROM Employees E WHERE E.Dept_Id = 2;

SELECT 
	COUNT(*) AS Num_Of_Employees
FROM Employees E
WHERE
	E.Dept_Id = 2;

UPDATE Departments
	SET Num_Employees = (
		SELECT 
			COUNT(*) AS Num_Of_Employees
		FROM Employees E
		);

