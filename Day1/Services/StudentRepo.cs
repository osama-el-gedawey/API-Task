using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Services
{
    public class StudentRepo:IStudent
    {
        APIDbContext db;
        public StudentRepo(APIDbContext _dp)
        {
            db= _dp;
        }
        public List<Student> GetAll()
        {
            return db.Students.Include(s=>s.Department).Where(d => d.IsDeleted == false&&d.Department.IsDeleted==false).ToList();
            
        }
        public Student? GetById(int id)
        {
            return db.Students.Include(s => s.Department).FirstOrDefault(d=>d.Id==id && d.IsDeleted==false && d.Department.IsDeleted == false);
        }
        public Student? GetByName(string name)
        {
            return db.Students.Include(s => s.Department).FirstOrDefault(d => d.Name == name && d.IsDeleted == false && d.Department.IsDeleted == false);
        }

        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public Student? Delete(int id)
        {
            Student? student = GetById(id);
            if (student != null) { 
            student.IsDeleted = true;
            db.SaveChanges();
            }
            return student;
        }
        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
    }
}
