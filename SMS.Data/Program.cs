using SMS.Data.Models;              // where our student class is defined
using SMS.Data.Extensions;          // where our List extension method (ToPrettyString) is defined 
using SMS.Data.Repository;          // where our data repository is defined

// call relevant methods here to test
Question1();
Question3();
Question4();
Question5();
// optional question
//Question6();
      

// Question 1 - Query Int List
void Question1()
{
    Console.WriteLine("\nQuestion 1");
    
    //q1.1 - create integer list (data) and intialise with specified values
    var data = new List<int> { 23,4,7,1,12,45,19,7 };
    
    // q1.2
    Console.Write("\nq1.2: ");
    Console.WriteLine(data.ToPrettyString());
    
    // q1.3
    Console.Write("\nq1.3: ");
    var over15 = data.Where(e => e > 15).ToList();
    over15.Print();
    
    // q1.4
    Console.Write("\nq1.4: ");
    var between5and15 = data.Where(e => e > 5 && e < 15).ToList();
    between5and15.Print();

    // q1.5
    Console.Write("\nq1.5: ");
    var allunique = data.Distinct().ToList();
    allunique.Print();
    
    // q1.6       
    Console.Write("\nq1.6: ");
    var allinorder = data.OrderBy(e => e).ToList();
    allinorder.Print();
}

// Q2 - Seed the Database 
void SeedDatabase(DataContext db)
{    
    // call Initialise method on Database Context 
    db.Initialise();
    
    // create students
    var s1 = new Student {Name = "Homer", Age = 44};
    var s2 = new Student {Name = "Marge", Age = 38};
    var s3 = new Student {Name = "Bart", Age = 12};
    var s4 = new Student {Name = "Lisa", Age = 10};
    var s5 = new Student {Name = "Burns", Age = 80};

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
    Console.WriteLine("\nq3.1: ");
    var all = db.Students.ToList();
    all.Print();
   
    //q3.2 - Find and print the student with the Id 1
    Console.WriteLine("\nq3.2");
    var s = db.Students.FirstOrDefault(s => s.Id == 1);
    Console.WriteLine(s);
      
    // q3.3 - print students with Age > 20
    Console.WriteLine("\nq3.3: ");
    var over20 = db.Students.Where(s => s.Age > 20).ToList();
    over20.Print();  
      
    // q3.4 Select and print the Name and Age of all students (see custom projection in the notes)
    Console.WriteLine("\nq3.4: ");
    var q4 = db.Students.Select(s => new {s.Name, s.Age}).ToList();
    q4.Print();  

    // q3.5 - print the Age of the first student over 20. Use FirstOrDefault
    //        deal with scenario where a student may not be found before attempting to print the age
    Console.WriteLine("\nq3.5");
    //var sover20 = db.Students.OrderBy.(s => s.Age )FirstOrDefault.(s => s.Age > 20);
    //if (sover20 is not null)
    //{
    //  Console.WriteLine($"Age of first student over 20 is: {sover20.Age}");
    //}else
    //  {
    //    Console.WriteLine("Student does not exist");
    //  }
    
    
}

// Q4 - More advanced queries
void Question4()
{
    Console.WriteLine("\nQuestion 4");
    
    // create database context and seed database
    var db = new DataContext();
    SeedDatabase(db);

    //4.1. print the students by descending age
    Console.WriteLine("\nq4.1: ");
    var agedesc = db.Students.OrderByDescending(e => e.Age).ToList();
    agedesc.Print();
    
    //4.2. print count of number of students who are over 18 (should print 3)
    Console.WriteLine("\nq4.3");
    var over18 = db.Students.Count(s => s.Age > 18);
    Console.WriteLine($"Number over 18 is: {over18}");

    //4.2. print Age of oldest Student (should print 80)
    Console.WriteLine("\nq4.4");
    var oldest = db.Students.OrderByDescending(e => e.Age).FirstOrDefault();
    Console.WriteLine(oldest);
   
}

// Question 5: Update Database
void Question5()
{
    Console.WriteLine("\nQuestion 5");
            
    // create database context and seed database          
    var db = new DataContext();
    SeedDatabase(db);
    
    //5.1. Update Age of Student with Id 3 to 13
    Console.WriteLine("5.1 - updating Age of Student 3 (Bart)");
    var bart = db.Students.Find(3);
    Console.WriteLine($"Bart's old age: {bart.Age}");
    bart.Age = 13;
    db.SaveChanges();
    Console.WriteLine($"Bart's new age is: {bart.Age}");
   
    //5.2. Update student with name "Burns" to "Mr Burns"
    Console.WriteLine("\nq5.2 - updating Burns name");
    var burnschange = db.Students.Where(e => e.Name == "Burns");
    Console.WriteLine($"Name before change: {burnschange.Name}");
    burnschange.Name = "Mr Burns";
    db.SaveChanges();  
    burnschange = db.Students.Where(e => e.Name == "Mr Burns");
    Console.WriteLine($"Name after change: {burnschange.Name}");    
    
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
