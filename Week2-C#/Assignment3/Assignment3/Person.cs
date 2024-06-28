/*
 * 2. Use /Abstraction/ to define different classes for each person type such as Student
   and Instructor. These classes should have behavior for that type of person.
   3. Use /Encapsulation/ to keep many details private in each class.
   4. Use /Inheritance/ by leveraging the implementation already created in the Person
   class to save code in Student and Instructor classes.
   5. Use /Polymorphism/ to create virtual methods that derived classes could override to
   create specific behavior such as salary calculations.
   6. Make sure to create appropriate /interfaces/ such as ICourseService, IStudentService,
   IInstructorService, IDepartmentService, IPersonService, IPersonService (should have
   person specific methods). IStudentService, IInstructorService should inherit from
   IPersonService.
   Person
   Calculate Age of the Person
   Calculate the Salary of the person, Use decimal for salary
   Salary cannot be negative number
   Can have multiple Addresses, should have method to get addresses
   Instructor
   Belongs to one Department and he can be Head of the Department
   Instructor will have added bonus salary based on his experience, calculate his
   years of experience based on Join Date
   Student
   Can take multiple courses
   Calculate student GPA based on grades for courses
   Each course will have grade from A to F
   Course
   Will have list of enrolled students
   Department
   Will have one Instructor as head
   Will have Budget for school year (start and end Date Time)
   Will offer list of courses.
 */

using System;
using System.Collections.Generic;

// Define interfaces
public interface IPersonService
{
    int CalculateAge();
    decimal CalculateSalary();
    IEnumerable<string> GetAddresses();
}

public interface IStudentService : IPersonService
{
    double CalculateGPA();
}

public interface IInstructorService : IPersonService
{
    int CalculateExperience();
}

// Define base class Person
public abstract class Person : IPersonService
{
    private string name;
    private DateTime birthDate;
    private decimal salary;
    private List<string> addresses = new List<string>();

    public Person(string name, DateTime birthDate, decimal salary)
    {
        this.name = name;
        this.birthDate = birthDate;
        this.salary = salary >= 0 ? salary : throw new ArgumentException("Salary cannot be negative.");
    }

    public int CalculateAge() => DateTime.Now.Year - birthDate.Year;

    public decimal CalculateSalary() => salary;

    public void AddAddress(string address) => addresses.Add(address);

    public IEnumerable<string> GetAddresses() => addresses;
}

// Define derived class Student
public class Student : Person, IStudentService
{
    private List<Course> courses = new List<Course>();

    public Student(string name, DateTime birthDate, decimal salary) : base(name, birthDate, salary) { }

    public void EnrollCourse(Course course) => courses.Add(course);

    public double CalculateGPA()
    {
        // GPA calculation logic
        return 0.0; // Placeholder
    }

    public List<Course> GetCourses()
    {
        return courses;
    }
}

// Define derived class Instructor
public class Instructor : Person, IInstructorService
{
    private DateTime joinDate;
    private Department department;

    public Instructor(string name, DateTime birthDate, decimal salary, DateTime joinDate, Department department)
        : base(name, birthDate, salary)
    {
        this.joinDate = joinDate;
        this.department = department;
    }

    public int CalculateExperience() => DateTime.Now.Year - joinDate.Year;

    // Polymorphism: Override the CalculateSalary method
    public decimal CalculateSalary()
    {
        // Bonus salary calculation logic
        return base.CalculateSalary() + CalculateExperience() * 1000; // Placeholder
    }
}

// Define other classes
public class Course
{
    public string Name { get; set; }
    public List<Student> EnrolledStudents { get; } = new List<Student>();
}

public class Department
{
    public Instructor Head { get; set; }
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Course> Courses { get; } = new List<Course>();
}