using Academy.Core.Entities;
using Academy.Infrastructure.DBContext;
using System.Data;

namespace Academy.Infrastructure.Services;

public class CourseService 
{
    private static int index_counter = 0;
    public void Create(string? name)           
    {
        if(String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDbContext.Courses[i].Name.ToUpper() == name.ToUpper())
            {
                isExist = true; break;
            }
        }
        if (isExist)
        {
            throw new DuplicateNameException("This course name already exist");
        }
        Course new_course = new(name);
        AppDbContext.Courses[index_counter++] =new_course;
    }

    public void GetAll()
    {
        for (int i = 0; i < index_counter; i++)
        {
            Console.WriteLine($"ID:{AppDbContext.Courses[i].Id} -> Name:{AppDbContext.Courses[i].Name} ");
        }
    }
}
