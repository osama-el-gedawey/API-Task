using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Services
{
    public class DepartmentRepo:IDepartment
    {
        APIDbContext db;
        public DepartmentRepo(APIDbContext _dp)
        {
            db = _dp;
        }
        public List<Department> GetAll()
        {
            return db.Departments.Include(d=>d.Students.Where(s => s.IsDeleted == false))
                .Where(d => d.IsDeleted == false).ToList();

        }
        public Department? GetById(int id)
        {
            return db.Departments.Include(d => d.Students.Where(s => s.IsDeleted == false))
                .FirstOrDefault(d => d.Id == id && d.IsDeleted == false);
        }
        public Department? GetByName(string name)
        {
            return db.Departments.Include(d => d.Students.Where(s => s.IsDeleted == false))
                .FirstOrDefault(d => d.Name == name && d.IsDeleted == false);
        }

        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public Department? Delete(int id)
        {
            Department? department = GetById(id);
            if (department != null)
            {
                department.IsDeleted = true;
                if (department.Students != null)
                {
                    foreach (var item in department.Students)
                    {
                        item.IsDeleted = true;
                    }
                }
                
                db.SaveChanges();
            }
            return department;
        }
        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }

    }
}
