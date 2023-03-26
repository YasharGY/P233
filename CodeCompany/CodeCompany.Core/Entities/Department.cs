namespace CodeCompany.Core.Entities;




public class Department 
{
   
    public int Id { get; }
    public string Name { get; set; }
    public int EmployeeLimit { get; set; }
    public string DepartmentName { get; set; }
    public int CompanyId { get; set; }
    public List<Employee> Employees { get; set; }
    public int DepartmentId { get; set; }
    public object MaxCount { get; set; }

    private static int _count;
    
    public Department(string name, int employeeLimit, int companyId)
    {
        if (string.IsNullOrEmpty(name) || employeeLimit <= 0)
        {
            throw new ArgumentException("Name and EmployeeLimit cannot be null or empty.");
        }
        Id = _count++;
        Name = name;
        EmployeeLimit = employeeLimit;
        CompanyId = companyId;
        Employees = new List<Employee>();
    }

   
   

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }

}
