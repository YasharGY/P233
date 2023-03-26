//Create student and add any group
//GetAll students
//GetStudentByName
//GetGroupById
using Academy.Core.Entities;
using Academy.Infrastructure.Services;
using Academy.Infrastructure.Utilities.Exceptions;

CourseService courseService = new CourseService();
GroupService groupService = new GroupService();
StudentService studentService = new StudentService();
Console.WriteLine("Welcome!");
while (true)
{
    Console.WriteLine("0->Exit" +
        "\n1->Create Course" +
        "\n2->List Courses" +
        "\n3->Create Group" +
        "\n4->List Group" +
        "\n5->Create student" +
        "\n6->List students" +
        "\n7->Search students by name");
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
                Console.WriteLine("Enter Course Name:");
                try
                {
                    string? res_coursename = Console.ReadLine();
                    courseService.Create(res_coursename);
                    Console.WriteLine($"New course is created: {res_coursename}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                break;
            case 2:
                Console.WriteLine("Courses List:");
                courseService.GetAll();
                break;
            case 3:
                Console.WriteLine("Enter Group Name:");
                string? group_name = Console.ReadLine();
            max_count:
                Console.WriteLine("Enter Group Max Number:");
                string? group_max = Console.ReadLine();
                int max_count;
                bool tryToIntMax = int.TryParse(group_max, out max_count);
                if (!tryToIntMax)
                {
                    Console.WriteLine("Enter correct Format");
                    goto max_count;
                }
            group_type:
                Console.WriteLine("Enter Group Type (number):");
                foreach (var groupType in Enum.GetValues(typeof(GroupType)))
                {
                    Console.WriteLine((int)groupType + "-" + groupType);
                }
                string? group_type = Console.ReadLine();
                int type_count;
                bool tryToIntType = int.TryParse(group_type, out type_count);
                if (!tryToIntType)
                {
                    Console.WriteLine("Enter correct Format");
                    goto group_type;
                }

            select_course:
                Console.WriteLine("Enter Course (Id):");
                courseService.GetAll();
                string? select_course = Console.ReadLine();
                int course_Id;
                bool tryToIdCourse = int.TryParse(select_course, out course_Id);
                if (!tryToIdCourse)
                {
                    Console.WriteLine("Enter correct Course Id");
                    goto select_course;
                }

                try
                {
                    groupService.Create(group_name, max_count, course_Id, type_count);
                    Console.WriteLine("Succesfully created");
                }
                catch (NotExistException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto group_type;
                }
                catch (AddCourseFailedException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto select_course;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case 3;
                }
                break;
            case 4:
                Console.WriteLine("Groups' List:");
                groupService.GetAll();
                break;
            case 5:
                Console.WriteLine("Enter Student Name:");
                string? student_name = Console.ReadLine();
                Console.WriteLine("Enter Student Surname:");
                string? student_surname = Console.ReadLine();
            select_group:
                groupService.GetAll();
                Console.WriteLine("Enter Group (Id):");
                string? select_group = Console.ReadLine();
                int group_Id;
                bool tryToIdGroup = int.TryParse(select_group, out group_Id);
                if (!tryToIdGroup)
                {
                    Console.WriteLine("Enter correct Group Id");
                    goto select_group;
                }

                try
                {
                    studentService.Create(student_name, student_surname, group_Id);
                    Console.WriteLine("Succesfully created");
                }
                catch (AddGroupFailedException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto select_group;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case 5;
                }
                break;
            case 6:
                Console.WriteLine("Student List");
                studentService.GetAll();
                break;
            case 7:
                Console.WriteLine("Enter name:");
                string? nameOrSurname = Console.ReadLine();
                try
                {
                    studentService.GetByName(nameOrSurname);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            default:
                Console.WriteLine("Select correct ones from menu!!!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Enter correct menu item");
    }
}
