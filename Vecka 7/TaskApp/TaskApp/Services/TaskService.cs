using System.Net.Http.Json;
using TaskShared.Model;

namespace TaskApp.Services
{
    public class TaskService
    {
        private readonly HttpClient http;

        public TaskService(HttpClient http)
        {
            this.http = http;
        }

        public Task<List<TaskItem>> GetAll()
            => http.GetFromJsonAsync<List<TaskItem>>("api/tasks");

        public Task Create(TaskItem t)
            => http.PostAsJsonAsync("api/tasks", t);

        public Task Toggle(TaskItem t)
            => http.PutAsync($"api/tasks/{t.Id}", null);

        public Task Delete(TaskItem t)
            => http.DeleteAsync($"api/tasks/{t.Id}");
    }
}
