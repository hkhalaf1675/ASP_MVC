using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Day1_Lab.Models;

namespace WebAPI_Day1_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        WebAPIDBContext context;
        public StudentController(WebAPIDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students = context.Students.ToList();
            if(students?.Count > 0)
            {
                return Ok(students);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            Student student = context.Students.FirstOrDefault(S => S.ID == id);
            if(student == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetsByName(string name)
        {
            var students = context.Students.Where(S => S.Name.Contains(name)).ToList();
            if(students == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(students);
            }
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    return Ok(context.Students.ToList());
                }
                catch(Exception ex)
                {
                    return BadRequest(context);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Student student = context.Students.FirstOrDefault(S => S.ID == id);
            if (student == null)
                return BadRequest();
            else
                return Ok(context.Students.ToList());
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(student);
                    context.SaveChanges();
                    return Ok(context.Students.ToList());
                }
                catch(Exception ex)
                {
                    return BadRequest(context);
                }

            }
            return BadRequest(ModelState);
        }
    }
}
