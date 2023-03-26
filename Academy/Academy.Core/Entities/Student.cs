using Academy.Core.Interfaces;

namespace Academy.Core.Entities;

public class Student : IEntity
{
    public int Id { get; set ; }
    public string Name { get; set ; }
    public string Surname { get; set ; }
    public int GroupId { get; set; }

    private static int _count;
    private Student()
    {
        Id = _count++;
    }

    public Student(string name, string surname, int groupId) : this()
    {
        Name = name;
        Surname = surname;
        GroupId = groupId;
    }
}
