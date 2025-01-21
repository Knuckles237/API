using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        // GET: /Tarefa
        [HttpGet]
        public IActionResult GetTarefas()
        {
            var tarefas = new[]
            {
 new { Id = 1, Nome = "Tarefa 1", Concluida = false },
 new { Id = 2, Nome = "Tarefa 2", Concluida = true },
 new { Id = 3, Nome = "Tarefa 3", Concluida = false }
 };
            return Ok(tarefas);
        }
    }
}