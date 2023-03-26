using Academy.Core.Entities;
using Academy.Infrastructure.DBContext;
using Academy.Infrastructure.Utilities.Exceptions;
using System.Linq;

namespace Academy.Infrastructure.Services;

public class StudentService
{
    private static int index_counter = 0;
    private GroupService groupService;
    public StudentService()
    {
        groupService = new GroupService();
    }
    public void Create(string name, string surname, int group_id)
    {
        if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentNullException();
        }
        foreach (var group in AppDbContext.Groups)
        {
            if (group is null)
            {
                throw new AddGroupFailedException("this group is not exist");
            }
            if (group.Id == group_id) { break; }
        }
        Student new_student = new(name, surname, group_id);
        AppDbContext.Students[index_counter++] = new_student;
    }
    public void GetAll()
    {
        for (int i = 0; i < index_counter; i++)
        {

            Console.WriteLine("\n************************************************************************\n");
            Console.WriteLine($"Student id: {AppDbContext.Students[i].Id}; " +
                $"Student Name: {AppDbContext.Students[i].Name}; " +
                $"Student Surname: {AppDbContext.Students[i].Surname};");
            groupService.GetById(AppDbContext.Students[i].GroupId);
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
            fullname = AppDbContext.Students[i].Name + " " + AppDbContext.Students[i].Surname;
           
            if (fullname.ToUpper().Contains(nameOrSurname.ToUpper()))
            {
                isExsist=true;
                Console.WriteLine("\n************************************************************************\n");
                Console.WriteLine($"Student id: {AppDbContext.Students[i].Id}; " +
                    $"Student Name: {AppDbContext.Students[i].Name}; " +
                    $"Student Surname: {AppDbContext.Students[i].Surname};");
                groupService.GetById(AppDbContext.Students[i].GroupId);
                Console.WriteLine("\n************************************************************************\n");
            }
        }

        if (!isExsist)
        {
            throw new NotFoundException("Student Not Found");
        }
    }
}
