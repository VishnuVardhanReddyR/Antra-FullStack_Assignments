namespace ConsoleApp1;

public abstract class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public abstract void PerformWork();

    public virtual void VirtualMethodDemo()
    {
        Console.WriteLine("Virtual method in base class");
    }
}

public class PartTimeEmployee: Employee
{
    public decimal HourlyPay { get; set; }
    public decimal Benefits { get; set; }
    public override void PerformWork()
    {
        Console.WriteLine("PartTime Employee works 20 hours");
    }

    public override void VirtualMethodDemo()
    {
        Console.WriteLine("Virtual method overridden in PartTime Employee Class");
    }
}

public class FullTimeEmployee: Employee
{
    public decimal BiWeeklyPay { get; set; }
    public decimal Benefits { get; set; }
    public override void PerformWork()
    {
        Console.WriteLine("FullTime Employee works 40 hours");
    }
}