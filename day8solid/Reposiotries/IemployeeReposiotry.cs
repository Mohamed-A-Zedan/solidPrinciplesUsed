using day8solid.Models;

namespace day8solid.Reposiotries
{
    public interface IemployeeReposiotry
    {
        List<employee> getAll();
        employee getById(int id); 
        int Add(employee emp);
        int Edit(employee emp);
        int Delete(int id);
        
    }
}
