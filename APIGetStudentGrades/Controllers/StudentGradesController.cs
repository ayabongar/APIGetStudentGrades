#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGetStudentGrades.Data;
using APIGetStudentGrades.Models;

namespace APIGetStudentGrades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradesController : ControllerBase
    {
        private readonly APIGetStudentGradesContext _context;

        public StudentGradesController(APIGetStudentGradesContext context)
        {
            _context = context;
        }

        // GET: api/StudentGrades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentGrades>>> GetStudentGrades()
        {



            string path = @"C:\Users\bbdnet2624\source\repos\APIGetStudentGrades\StudentGrades.txt";
            using (StreamWriter stream = new StreamWriter(path))
            {
                int sqlQueryResult = (from StudentGrades
                           in _context.StudentGrades
                                      select "Id").Count();



                stream.WriteLine("No. of Records in Student Grades Table: " + sqlQueryResult);


            }



            return await _context.StudentGrades.ToListAsync();

        }

        // GET: api/StudentGrades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentGrades>> GetStudentGrades(int id)
        {
            var studentGrades = await _context.StudentGrades.FindAsync(id);

            if (studentGrades == null)
            {
                return NotFound();
            }


            string path = @"C:\Users\bbdnet2624\source\repos\APIGetStudentGrades\StudentGrades.txt";
            using (StreamWriter stream = new StreamWriter(path))
            {
                int sqlQueryResult = (from StudentGrades
                           in _context.StudentGrades
                                select "Id").Count();

                stream.WriteLine("No. of Records in Student Grades Table: " + sqlQueryResult);

            }


            return studentGrades;
        }

        // PUT: api/StudentGrades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentGrades(int id, StudentGrades studentGrades)
        {
            if (id != studentGrades.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentGrades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGradesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }



            string path = @"C:\Users\bbdnet2624\source\repos\APIGetStudentGrades\StudentGrades.txt";
            using (StreamWriter stream = new StreamWriter(path))
            {
                int sqlQueryResult = (from StudentGrades
                           in _context.StudentGrades
                                select "Id").Count();

                stream.WriteLine("No. of Records in Student Grades Table: " + sqlQueryResult);

            }


            return NoContent();
        }

        // POST: api/StudentGrades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentGrades>> PostStudentGrades(StudentGrades studentGrades)
        {
            _context.StudentGrades.Add(studentGrades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentGrades", new { id = studentGrades.Id }, studentGrades);
        }

        // DELETE: api/StudentGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentGrades(int id)
        {
            var studentGrades = await _context.StudentGrades.FindAsync(id);
            if (studentGrades == null)
            {
                return NotFound();
            }

            _context.StudentGrades.Remove(studentGrades);
            await _context.SaveChangesAsync();


            string path = @"C:\Users\bbdnet2624\source\repos\APIGetStudentGrades\StudentGrades.txt";
            using (StreamWriter stream = new StreamWriter(path))
            {
                int sqlQueryResult = (from StudentGrades
                           in _context.StudentGrades
                           select "Id").Count();

                stream.WriteLine("No. of Records in Student Grades Table: " + sqlQueryResult);
                
            }


            return NoContent();
        }

        private bool StudentGradesExists(int id)
        {
            return _context.StudentGrades.Any(e => e.Id == id);
        }
    }
}
