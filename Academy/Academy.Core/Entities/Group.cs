using Academy.Core.Interfaces;

namespace Academy.Core.Entities;

public class Group : IEntity
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string GroupName { get; set; }
    public GroupType Type { get; set; }
    public int MaxCount { get;}
    private static int _count;
    private Group()
    {
        Id = _count++;
    }

    public Group(string group_name,int max_count,int course_id, GroupType type) : this()
    {
        GroupName = group_name;
        MaxCount = max_count;
        Type = type;
        CourseId = course_id;
    }
}

public enum GroupType { Programming=1,Dizayn,Market}
