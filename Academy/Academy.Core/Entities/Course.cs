using Academy.Core.Interfaces;

namespace Academy.Core.Entities;

public class Course : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    private static int _count;
    private Course()
    {
        Id = _count++;
    }

    public Course(string name) : this()
    {
        Name = name;
    }
}