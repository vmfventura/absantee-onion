namespace Domain.Factory;

using Domain.Model;
public interface IProjectFactory
{
    Project NewProject(string strName, DateOnly dateStart, DateOnly? dateEnd);
}