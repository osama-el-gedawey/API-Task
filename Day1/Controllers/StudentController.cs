using Day1.DTOS;
using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudent DB;
        public StudentController(IStudent _Db) 
        { 
            DB = _Db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var std = DB.GetAll();
            if (std is null)
                return NotFound();
            
            List<StudentDto> students = new List<StudentDto>();
            foreach(var student in std)
            {
                StudentDto studentDto = new StudentDto();
                studentDto.Student_Id = student.Id;
                studentDto.Student_Name = student.Name;
                studentDto.Student_Adress = student.Adress;
                studentDto.Student_Image = student.Image;
                studentDto.Student_Age = student.Age;
                studentDto.Student_Department = student.Department.Name;
                students.Add(studentDto);
            }
            return Ok(students);
        }
        [HttpGet("{id:int}", Name ="GetCreated")]
        public IActionResult GetById(int id)
        {
            var student = DB.GetById(id);
            if (student is null)
                return NotFound();
            StudentDto studentDto = new StudentDto();
            studentDto.Student_Id = student.Id;
            studentDto.Student_Name = student.Name;
            studentDto.Student_Adress = student.Adress;
            studentDto.Student_Image = student.Image;
            studentDto.Student_Age = student.Age;
            studentDto.Student_Department = student.Department.Name;
            return Ok(studentDto);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var student = DB.GetByName(name);
            if (student is null)
                return NotFound();
            StudentDto studentDto = new StudentDto();
            studentDto.Student_Id = student.Id;
            studentDto.Student_Name = student.Name;
            studentDto.Student_Adress = student.Adress;
            studentDto.Student_Image = student.Image;
            studentDto.Student_Age = student.Age;
            studentDto.Student_Department = student.Department.Name;
            return Ok(studentDto);
        }
        [HttpPost]
        public IActionResult Add(Student std)
        {
            if (ModelState.IsValid )
            {
                DB.Add(std);
                return Created(Url.Link("GetCreated", new { id = std.Id }), "");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update(Student std)
        {
            if (ModelState.IsValid)
            {
                DB.Update(std);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student? deleted = DB.Delete(id);
            if (deleted is null)
                return NotFound();
            return Ok(deleted);
        }


    }
}
