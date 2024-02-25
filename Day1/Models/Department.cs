using Day1.CustomValidatioin;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Day1.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "name must be between 5 and 50")]
        [uniqeDepartmentName(ErrorMessage ="department name already exist")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public string Location { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "manger name must be between 5 and 50")]
        public string MangerName { get; set; }
        [DefaultValue(false)]
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        
        public virtual ICollection<Student>? Students { get; set; }
    }
}
