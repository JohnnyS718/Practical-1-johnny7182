# COM741 - Practical 1

The template for this project (found on replit.com and for backup in Practical1.zip in BBL),  contains a console project called SMS.Data. To run the project click green Run button (in replit) or at the prompt type ```$ dotnet run --project SMS.Data```
## Exercises

In the following exercises, the methods to be completed can be found in ```Program.cs``` within the ```SMS.Data``` project.

1. Complete outline method Question1 as follows
    1. Create an integer list called ```data``` and intialise with the following values ```23,4,7,1,12,45,19,7``` (you can use list initialisation syntax or call the list Add method to add each element in sequence.)
    2. Print the list (use a standard ```foreach``` loop, the list ```ForEach``` extension method, or our custom extension method ```Print()``` mentioned in the notes).
    3. Query and print data list elements > 15 ```[ 23, 45, 19 ]```
    4. Query and print data list elements > 5 and < 15 ```[ 7, 12, 7 ]```
    5. Query and print distinct data list elements > 5 and < 15 ```[ 7, 12 ]```
    6. Print the data list in ascending order ```[ 1, 4, 7, 7, 12, 19, 23, 45 ]```


2. Complete outline method ```SeedDatabase``` so that by using the database context parameter (db) it: 
    1. Creates 5 student objects as described in table below, 
    3. Adds these students to the database Students table (db.Students), 
    4. Saves the changes. 
    
    This is a good example of where you should use the object initialiser syntax (see week 1 notes) when creating a student ```var s1 = new Student { Id = 1, Name = "Homer", Age = 44 };```. 

    **NOTE:** Normally we don't provide a value for Id property as the database will add a unique value. We are just doing so here so we know each students unique Id for some queries below.


    | Id | Name   | Age |
    |--- |------- |---- | 
    | 1  | Homer  | 44  |
    | 2  | Marge  | 38  |
    | 3  | Bart   | 12  |
    | 4  | Lisa   | 10  |
    | 5  | Burns  | 80  |


3.  Complete outline method Question3 by carrying out queries below:

    **Note** that the outline method firstly creates a DataContext object ```var db = new DataContext()```, then calls ```SeedDatabase(db)``` to ensure the database is created and initialised with seed data. You should use the context ```db``` variable to query the database.

    1. Select and print the students in the database 
    2. Select and print the student with the Id 1
    3. Select and print all students with Age > 20 
    4. Select and print (**Name, Age**) of all students (see custom projection in the notes)
    4. Print the Name of the FIRST student with Age > 20. You should deal with scenario where a student may not be found that meets this criterion e.g. Age > 80. Use an if/else to decide what to print when found/not found.   
        
4. Complete outline method Question4() by carrying out following queries:

    1. Print the students in descending age as follows.
	```
		Id: 5 Name: Burns Age: 80 
		Id: 1 Name: Homer Age: 41
		Id: 2 Name: Marge Age: 36
		Id: 3 Name: Bart  Age: 12
		Id: 4 Name: Lisa  Age: 10
	```	
    2. Print the number of students who are over 18 (should print 3) 
    3. Print the age of the oldest student (should print 80).


5. The following questions involve updating the data in the database 
    1. Find student with Id of ```3``` (Bart) and update their Age to ```13```
    2. Find first student with name name ```Burns``` and update their Name to ```Mr Burns```
    3. Delete first student with name ```Marge```.
    4. Print the students in the database and verify above updates have been applied.


**OPTIONAL** 
6. Modify the Student class in ```SMS.Data.Models``` (package) by 
 
 - add a property ```Grade (double)``` to store the students grade
 - add a private method ```Classify()``` so that it returns the degree classification as a string according to the following table

	| Grade | Classification |
	|---    | ---            |
	| 0-49  | Fail           | 
	| 50-69 | Pass           |   
	| 70-79 | Commendation   |
	| 80+   | Distinction    |   
	
 - Add a readonly string property called ```Classification``` that returns the result of calling the ```Classify()``` method as follows ``` public string Classification => Classify();```
 - Amend the Student ```ToString``` method to include the Classification
 
 - Complete ```Question6()``` method in the ```Program.cs``` as follows to try out your new Student amendments

    1. Create a DataContext object (db) and call call SeedDatabase(db);
    3. Create a new Student (with a Grade) and add to database (you could also update the seeder to include a grade for existing students).
    4. Query the database for the student and print to verify the Classification is correct.	
    5. Use the Sqlite Browser tool (download from internet) to examine the database and verify that the student table now includes a Grade column (but no Classification column - why is this?)
    

  