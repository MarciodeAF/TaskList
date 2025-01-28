using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public TasksController(ApplicationDbContext tasksDbContext)
        {
            _tasksDbContext = tasksDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Task>>> GetAllTask()
        {
            return Ok(await _tasksDbContext.Tasks.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Entities.Task>> Create([FromBody] Entities.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _tasksDbContext.Tasks.AddAsync(task);
            await _tasksDbContext.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Entities.Task>> Update(int id, [FromBody] Entities.Task taskFromJson)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var task = await _tasksDbContext.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            task.Name = taskFromJson.Name;
            task.Description = taskFromJson.Description;
            await _tasksDbContext.SaveChangesAsync();

            return Ok(task);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entities.Task>> Delete(int id)
        {
            var task = await _tasksDbContext.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            _tasksDbContext.Remove(task);
            await _tasksDbContext.SaveChangesAsync();

            return Ok(task);
        }
    }
}
