
namespace SMS.Data.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { set; get; }
   

    // return a printable version of a Student
    public override string ToString() 
    {
        return $"Id: {Id} Name: {Name} Age: {Age}";
    }
}