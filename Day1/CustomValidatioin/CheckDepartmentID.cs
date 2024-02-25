using Day1.Models;
using System.ComponentModel.DataAnnotations;

namespace Day1.CustomValidatioin
{
    public class CheckDepartmentID:ValidationAttribute
    {
        APIDbContext db=new APIDbContext();
        
        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            var dept=db.Departments.FirstOrDefault(d=>d.Id==(int)value);
            if(dept == null) return false;
            return true;
        }
    }
}
