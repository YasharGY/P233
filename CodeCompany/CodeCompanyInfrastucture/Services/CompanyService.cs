using CodeCompany.Core.Entities;
using CodeCompanyInfrastucture.DBContext;
using System.Data;

namespace CodeCompanyInfrastucture.Services;

public class CompanyService
{
    private static int index_counter = 0;   
    public void Create(string name)
    {
        if(String.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++) 
        {
            if (AppDBContext.Companies[i].Name.ToUpper()==name.ToUpper())
            {
                isExist = true; break;
            }
            if (isExist)
            {
                throw new DuplicateNameException("This Company name already Exist");
            }
            Company new_company = new(name);
            AppDBContext.Companies[index_counter] = new_company;


        }
    }
    public void GetAll()
    {
        for (int i = 0; i<index_counter; i++)
        {
            Console.WriteLine($"ID:{AppDBContext.Companies[i].Id}");
        }
    }



}
