namespace Domain.Factory;

using Domain.Model;

public class ProjectFactory
{
    public Project NewProject(string strName, DateOnly dateStart, DateOnly? dateEnd)
    {
        return new Project(strName, dateStart, dateEnd);
    }
}