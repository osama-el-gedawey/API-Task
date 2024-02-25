using Day1.Models;

namespace Day1.Services
{
    public interface IStudent
    {
        List<Student> GetAll();
        Student? GetById(int id);
        Student? GetByName(string id);
        void Add(Student student);
        void Update(Student student);
        Student? Delete(int id);
    }
}
