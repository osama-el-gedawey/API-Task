using Day1.CustomValidatioin;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Day1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "name must be between 5 and 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(15, 30, ErrorMessage = "age must be in range 15 and 30")]
        public int Age { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "adress must be between 5 and 50")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "*")]
        public string Image { get; set; }
        [DefaultValue(false)]
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "*")]
        [CheckDepartmentID(ErrorMessage ="department id not exist")]
        public int DepartmentId {  get; set; }
        [JsonIgnore]
        public virtual Department? Department { get; set; }
    }
}
