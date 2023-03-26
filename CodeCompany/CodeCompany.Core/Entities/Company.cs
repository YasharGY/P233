

namespace CodeCompany.Core.Entities;

public class Company 
{
    
    public int Id { get; }
    public string Name { get; }
    public List<Department> Departments { get; set; }
    private static int _count;
   
    
    public Company(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty.");
        }
        Id = _count++;
        Name = name;
        Departments = new List<Department>();
    }

    public void AddDepartment(Department department)
    {
        department.CompanyId = Id;
        Departments.Add(department);
    }

    public List<Department> GetAllDepartments()
    {
        return Departments;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }



}
