using Academy.Core.Entities;
using Academy.Infrastructure.DBContext;
using Academy.Infrastructure.Utilities.Exceptions;

namespace Academy.Infrastructure.Services;

public class GroupService
{
    private static int index_counter = 0;

    public void Create(string? name, int max_count, int course_id, int type)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDbContext.Groups[i].GroupName.ToUpper() == name.ToUpper())
            {
                isExist = true; break;
            }
        }
        if (isExist)
        {
            throw new DuplicateNameException("This group name already exist");
        }
        GroupType groupType;
        if (Enum.IsDefined(typeof(GroupType), type))
        {
            groupType = (GroupType)type;
        }
        else
        {
            throw new NotExistException("Select correct group's type");
        }
        foreach (var course in AppDbContext.Courses)
        {
            if (course is null)
            {
                throw new AddCourseFailedException("this course is not exist");
            }

            if (course.Id == course_id) { break;}
        }

        Group new_group = new(name, max_count, course_id, groupType);
        AppDbContext.Groups[index_counter++] = new_group;
    }

    public void GetAll()
    {
        for (int i = 0; i < index_counter; i++)
        {
            String temp_course = String.Empty;
            foreach (var course in AppDbContext.Courses)
            {
                if (course == null) break;
                if (AppDbContext.Groups[i].CourseId == course.Id)
                {
                    temp_course = course.Name;
                    break;
                }
            }
            Console.WriteLine($"id: {AppDbContext.Groups[i].Id}; " +
                $"Group: {AppDbContext.Groups[i].GroupName}; " +
                $"Type: {AppDbContext.Groups[i].Type}; " +
                $"Max Count: {AppDbContext.Groups[i].MaxCount}; " +
                $"Belongs to: {temp_course}");
        }
    }

    public void GetById(int id)
    {
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDbContext.Groups[i].Id == id)
            {
                String temp_course = String.Empty;
                foreach (var course in AppDbContext.Courses)
                {
                    if (course == null) break;
                    if (AppDbContext.Groups[i].CourseId == course.Id)
                    {
                        temp_course = course.Name;
                        break;
                    }
                }
                Console.WriteLine($"Group id: {AppDbContext.Groups[i].Id}; " + 
                $"Group: {AppDbContext.Groups[i].GroupName}; " +
                $"Type: {AppDbContext.Groups[i].Type}; " +
                $"Max Count: {AppDbContext.Groups[i].MaxCount}; " +
                $"Belongs to: {temp_course}");
                return;
            }

        }

    }
}
