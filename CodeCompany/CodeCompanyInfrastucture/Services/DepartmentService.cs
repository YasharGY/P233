
using CodeCompany.Core.Entities;
using CodeCompanyInfrastucture.DBContext;
using CodeCompanyInfrastucture.Utilities.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace CodeCompanyInfrastucture.Services;
public class DepartmentService
{
    private static int index_counter = 0;
    public void Create(string name, int max_count, int company_id, int type)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("name");
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBContext.Departments[i].DepartmentName.ToUpper() == name.ToUpper())
            {
                isExist = true;break; 
            } 
        }
        if (isExist)
        {
            throw new DublicateNameException("This department name already exist");
        }
        Department new_department = new(name, max_count, company_id);
        AppDBContext.Departments[index_counter] = new_department;
    }

    public void GetAll()
    {
        for (int i = 0; i <= index_counter; i++)
        {
            String temp_company = String.Empty;
            foreach(var company in AppDBContext.Departments)
            {
                if (company == null) break;
                if (AppDBContext.Departments[i].CompanyId == company.Id)
                {
                    temp_company = company.Name;
                    break;
                }
            }
            Console.WriteLine($"id:{AppDBContext.Departments[i].Id}; Company: {AppDBContext.Departments[i].DepartmentName}");



        }

        
    }


    public void GetById(int id, Company company)
    {
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBContext.Departments[i].Id == id)
            {
                String temp_company = String.Empty;
                foreach (var compant in AppDBContext.Companies)
                {
                    if (company == null) break;
                    if (AppDBContext.Departments[i].DepartmentId == company.Id)
                    {
                        temp_company = company.Name;
                        break;
                    }
                }
                Console.WriteLine($"Group id: {AppDBContext.Departments[i].Id}; " +
                $"Group: {AppDBContext.Departments[i].DepartmentName}; " +
                $"Max Count: {AppDBContext.Departments[i].MaxCount}; " +
                $"Belongs to: {temp_company}");
                return;
            }
        }
    }

    internal void GetById(int departmentId)
    {
        throw new NotImplementedException();
    }
}

