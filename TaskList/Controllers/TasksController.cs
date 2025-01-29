using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.DataContext;

namespace TaskList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _tasksDbContext;

        private readonly IConfiguration _configuration;
        private string _connectionString;
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        public TasksController(IConfiguration configuration)
        {
            _configuration = configuration;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _connectionString = _configuration.GetConnectionString("SqlConnection");
            _optionsBuilder.UseSqlServer(_connectionString);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Task>>> GetAllTask()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return Ok(await _context.Tasks.ToListAsync());
            }
        }

        [HttpPost]
        public async Task<ActionResult<Entities.Task>> Create([FromBody] Entities.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();
            }

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Entities.Task>> Update(int id, [FromBody] Entities.Task taskFromJson)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                task.Name = taskFromJson.Name;
                task.Description = taskFromJson.Description;
                await _context.SaveChangesAsync();
                return Ok(task);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Entities.Task>> Delete(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                _context.Remove(task);
                await _context.SaveChangesAsync();

                return Ok(task);
            }              
        }
    }
}
