using Microsoft.AspNetCore.Mvc;
using TaskShared.Model;


namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new()
{
    new TaskItem { Id = 1, Title = "Learn Blazor", Description = "Components", IsDone = false },
    new TaskItem { Id = 2, Title = "Build API", Description = "Controller", IsDone = true }
};


        [HttpGet]
        public IEnumerable<TaskItem> Get()
            => tasks;

        [HttpPost]
        public TaskItem Create(TaskItem t)
        {
            t.Id = tasks.Count + 1;
            tasks.Add(t);
            return t;
        }

        [HttpPut("{id}")]
        public IActionResult Toggle(int id)
        {
            var t = tasks.FirstOrDefault(x => x.Id == id);
            if (t == null) return NotFound();

            t.IsDone = !t.IsDone;
            return Ok(t);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var t = tasks.FirstOrDefault(x => x.Id == id);
            if (t == null) return NotFound();

            tasks.Remove(t);
            return Ok();
        }
    }
}
