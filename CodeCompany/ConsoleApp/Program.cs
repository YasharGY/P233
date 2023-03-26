using CodeCompany.Core.Entities;
using CodeCompanyInfrastucture.DBContext;
using CodeCompanyInfrastucture.Services;
using CodeCompanyInfrastucture.Utilities.Exceptions;
using System;
using System.Data;

namespace CompanyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyService companyService = new CompanyService();
            DepartmentService departmentService = new DepartmentService();
            EmployeeService employeeService = new EmployeeService();
            while (true)
            {
                Console.WriteLine("\nSelect the option:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Create a new company");
                Console.WriteLine("2: Display all companies");
                Console.WriteLine("3: Create a Department");
                Console.WriteLine("4: Display all Departments");

                string? response = Console.ReadLine();
                int menu;
                bool tryToInt = int.TryParse(response, out menu);
                if (tryToInt)
                {
                    switch (menu)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;
                        case 1:
                            Console.WriteLine("Enter Company Name:");
                            try
                            {
                                string? res_companyname = Console.ReadLine();
                                companyService.Create(res_companyname);
                                Console.WriteLine($"New company is created: {res_companyname}");
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (DuplicateNameException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Companies List:");
                            companyService.GetAll();
                            break;
                        default:
                            Console.WriteLine("Select correct ones from menu!");
                            break;
                        case 3:
                            Console.WriteLine("Enter new department name.");
                            string departmentName = Console.ReadLine();
                            try
                            {
                                departmentService.Create("New Department", 10, 1, 1); 
                                Console.WriteLine("New department created successfully.");
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            catch (DublicateNameException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }

                            
                            departmentService.GetAll();

                            
                          

                            Console.ReadLine();
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Enter correct menu item");
                }
            }
        }
    }
}
