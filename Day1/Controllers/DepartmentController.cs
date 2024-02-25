using Day1.CustomFilters;
using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartment DB;
        public DepartmentController(IDepartment _Db)
        {
            DB = _Db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (DB.GetAll() is null)
                return NotFound();
            return Ok(DB.GetAll());
        }
        [HttpGet("{id:int}", Name = "GetCreated2")]
        public IActionResult GetById(int id)
        {
            if (DB.GetById(id) is null)
                return NotFound();
            return Ok(DB.GetById(id));
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            if (DB.GetByName(name) is null)
                return NotFound();
            return Ok(DB.GetByName(name));
        }
        [HttpPost]
        [DepartmentLocationCustomFilter]
        public IActionResult Add(Department dept)
        {
            
            if (ModelState.IsValid)
            {
                DB.Add(dept);
                return Created(Url.Link("GetCreated2", new { id = dept.Id }), "");
            }
            return BadRequest();
        }
        [HttpPut]
        [DepartmentLocationCustomFilter]
        public IActionResult Update(Department dept)
        {
            if (ModelState.IsValid)
            {
                DB.Update(dept);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Department? deleted = DB.Delete(id);
            if (deleted is null)
                return NotFound();
            return Ok(deleted);
        }
    }
}
