namespace CodeCompany.Core.Entities;

public class Employee
{
    
    public int Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public double Salary { get; }
    private static int _count;
    public int DepartmentId { get; set; }

    public Employee(string name, string surname, double salary)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || salary <= 0)
        {
            throw new ArgumentException("Name, Surname and Salary cannot be null or empty.");
        }
        Id = _count++;
        Name = name;
        Surname = surname;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Surname: {Surname}";
    }

}
