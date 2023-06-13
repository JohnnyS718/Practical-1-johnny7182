using SMS.Data.Models;              // where our student class is defined
using SMS.Data.Extensions;          // where our List extension method (ToPrettyString) is defined 
using SMS.Data.Repository;          // where our data repository is defined

// call relevant methods here to test
//Question1();
Question3();
//Question4();
//Question5();
//optional question
//Question6();
      
// Question 1 - Query Int List
void Question1()
{
    Console.WriteLine("\nQuestion 1");
    
    //q1.1 - create integer list (data) and intialise with specified values
    var data = new List<int> {23, 4, 7, 1, 12, 45, 19, 7};
    
    // q1.2
    Console.Write("\nq1.2: ");
    Console.Write("[ ");
    data.ForEach(e => Console.Write($"{e}, "));
    Console.Write("]");
    
    // q1.3
    Console.Write("\nq1.3: ");
    var over15 = data.Where(n => n > 15).ToList();
    over15.Print();
    
    // q1.4
    Console.Write("\nq1.4: ");
    var over5less15 = data.Where(n => n > 5 && n < 15).ToList();
    over5less15.Print();

    // q1.5
    Console.Write("\nq1.5: ");
    var distinctover5less15 = data.Where(n => n > 5 && n < 15).Distinct().ToList();
    distinctover5less15.Print();
    
    // q1.6       
    Console.Write("\nq1.6: ");
    var listSorted = data.OrderBy(e => e).ToList();
    listSorted.Print();
}

// Q2 - Seed the Database 
void SeedDatabase(DataContext db)
{    
    // call Initialise method on Database Context 
    db.Initialise();
    
    // create students
    var s1 = new Student{Id = 1, Name = "Homer", Age = 44};
    var s2 = new Student{Id = 2, Name = "Marge", Age = 38};
    var s3 = new Student{Id = 3, Name = "Bart", Age = 12};
    var s4 = new Student{Id = 4, Name = "Lisa", Age = 10};
    var s5 = new Student{Id = 5, Name = "Burns", Age = 80};

    // add students to database and save changes
    db.Students.AddRange(s1,s2,s3,s4,s5);
    db.SaveChanges();
   
}

// Q3 - Student queries
void Question3()
{
    Console.WriteLine("\nQuestion 3");

    // create database context and call seed database
    var db = new DataContext();
    SeedDatabase(db);
  
    // q3.1 - print the students in the database
    var all = db.Students.ToList();
    all.Print();
   
    //q3.2 - Find and print the student with the Id 1
    var first = db.Students.FirstOrDefault(e => e.Id == 1);
    Console.WriteLine(first);
      
    // q3.3 - print students with Age > 20
    Console.WriteLine("\nq3.3: ");
    var ageOver20 = db.Students.Where(s => s.Age > 20).ToList();
    ageOver20.Print();

    // q3.4 Select and print the Name and Age of all students (see custom projection in the notes)
    Console.WriteLine("\nq3.4: ");
    var names = db.Students.Select(s => new {s.Name, s.Age}).ToList();
    names.Print();

    // q3.5 - print the Age of the first student over 20. Use                  FirstOrDefault
    // deal with scenario where a student may not be found before              attempting to print the age
    Console.WriteLine("\nq3.5");
    var age = 20;
    
    var studentsOver20 = db.Students.OrderBy(s => s.Age).FirstOrDefault(s => s.Age > age);
    if(studentsOver20 is not null)
    {
      Console.WriteLine(studentsOver20);
    }
    else
    {
      Console.WriteLine($"There are no students over the age of {age}");
    }
}

// Q4 - More advanced queries
void Question4()
{
    Console.WriteLine("\nQuestion 4");
    
    // create database context and seed database


    //4.1. print the students by descending age
    Console.WriteLine("\nq4.1: ");

    
    //4.2. print count of number of students who are over 18 (should print 3)
    Console.WriteLine("\nq4.3");


    //4.2. print Age of oldest Student (should print 80)
    Console.WriteLine("\nq4.4");
   
}

// Question 5: Update Database
void Question5()
{
    Console.WriteLine("\nQuestion 5");
            
    // create database context and seed database          
    
    //5.1. Update Age of Student with Id 3 to 13
    Console.WriteLine("5.1 - updating Age of Student 3 (Bart)");

   
    //5.2. Update student with name "Burns" to "Mr Burns"
    Console.WriteLine("\nq5.2 - updating Burns name");

    
    //5.3. Delete Marge
    Console.WriteLine("\nq5.3 - delete first student with name Marge");
    
    //5.4 Print the students in the database and verify above updates have been applied.
     Console.WriteLine("\nq5.4 - print students showing updates");

    
}

// Optional Question

// Firstly modify student class by adding Grade property and private classification method (see question)
// Next modify seeder to include new Grade property for each student
// Now complete Question6
void Question6() 
{
    // create database context and seed database          
    
    // create a student with a Grade property

    // Find the student added and print 

}
