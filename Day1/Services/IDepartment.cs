using Day1.Models;

namespace Day1.Services
{
    public interface IDepartment
    {
        List<Department> GetAll();
        Department? GetById(int id);
        Department? GetByName(string id);
        void Add(Department department);
        void Update(Department department);
        Department? Delete(int id);
    }
}
