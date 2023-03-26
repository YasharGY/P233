using CodeCompany.Core.Entities;

namespace CodeCompanyInfrastucture.DBContext;

public static class AppDBContext
{
    public static Employee[]Employees { get; set; } = new Employee[100];
    public static Department[] Departments { get; set; } = new Department[20];
    public static Company[] Companies { get; set; }=new Company[20];
}
