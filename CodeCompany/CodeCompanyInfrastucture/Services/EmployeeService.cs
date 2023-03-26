using CodeCompany.Core.Entities;
using CodeCompanyInfrastucture.DBContext;
using CodeCompanyInfrastucture.Utilities.Exceptions;

namespace CodeCompanyInfrastucture.Services;

public class EmployeeService
{
    private static int index_counter = 0;
    private DepartmentService departmentService;
    public EmployeeService()
    {
        departmentService = new DepartmentService();
    }
    public void Create(string name, string surname, int department_id)
    {
        if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentNullException();
        }
        foreach (var department in AppDBContext.Departments)
        {
            if (department is null)
            {
                throw new AddDepartmentFailedException("This Department is not exist");
            }
            if (department.Id == department_id) { break; }
        }
        Employee new_employee = new(name, surname, department_id);
        AppDBContext.Employees[index_counter++] = new_employee;
    }
    public void GetAll()
    {
        for (int i = 0; i < index_counter; i++)
        {

            Console.WriteLine("\n************************************************************************\n");
            Console.WriteLine($"Student id: {AppDBContext.Employees[i].Id}; " +
                $"Student Name: {AppDBContext.Employees[i].Name}; " +
                $"Student Surname: {AppDBContext.Employees[i].Surname};");
            departmentService.GetById(AppDBContext.Employees[i].Id);
            departmentService.GetById(AppDBContext.Employees[i].DepartmentId);
            Console.WriteLine("\n************************************************************************\n");
        }
    }

    public void GetByName(string nameOrSurname)
    {
        if (String.IsNullOrEmpty(nameOrSurname))
        {
            throw new ArgumentNullException();
        }

        bool isExsist = false;
        string fullname = String.Empty;
        for (int i = 0; i < index_counter; i++)
        {
            fullname = AppDBContext.Employees[i].Name + " " + AppDBContext.Employees[i].Surname;

            if (fullname.ToUpper().Contains(nameOrSurname.ToUpper()))
            {
                isExsist = true;
                Console.WriteLine("\n************************************************************************\n");
                Console.WriteLine($"Student id: {AppDBContext.Employees[i].Id}; " +
                    $"Student Name: {AppDBContext.Employees[i].Name}; " +
                    $"Student Surname: {AppDBContext.Employees[i].Surname};");
                departmentService.GetById(AppDBContext.Employees[i].DepartmentId);
                Console.WriteLine("\n************************************************************************\n");
            }
        }

        if (!isExsist)
        {
            throw new NotFoundException("Employee is Not Found");
        }

    }
}
