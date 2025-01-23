using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaRepositorio _context;

        public TarefaController(TarefaRepositorio context)
        {
            _context = context;
        }

        // GET: /Tarefa
        [HttpGet]
        public IActionResult GetTarefas()
        {
            var tarefas = _context.Tarefas.ToList(); // Use ToList()
            return Ok(tarefas);
        }

        // GET: /Tarefa/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetTarefaById(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
                return NotFound("Tarefa não encontrada.");

            return Ok(tarefa);
        }

        // POST: /Tarefa
        [HttpPost]
        public IActionResult CreateTarefa([FromBody] Tarefa tarefa)
        {
            if (tarefa.Titulo == "")
            {
                throw new Exception("Envie o título");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges(); // Use SaveChanges() em vez de SaveChangesAsync()

            return CreatedAtAction(nameof(GetTarefaById), new { id = tarefa.Id }, tarefa);
        }

        // PUT: /Tarefa/{id}
        [HttpPut("{id:int}")]
        public IActionResult UpdateTarefa(int id, [FromBody] Tarefa tarefaAtualizada)
        {
            var tarefaExistente = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefaExistente == null)
                return NotFound("Tarefa não encontrada.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Atualizando os dados da tarefa
            tarefaExistente.Titulo = tarefaAtualizada.Titulo;
            tarefaExistente.Descricao = tarefaAtualizada.Descricao;
            tarefaExistente.Prazo = tarefaAtualizada.Prazo;
            tarefaExistente.Concluida = tarefaAtualizada.Concluida;

            _context.SaveChanges(); // Use SaveChanges() em vez de SaveChangesAsync()
            return NoContent();
        }

        // DELETE: /Tarefa/{id}
        [HttpDelete("{id:int}")]
        public IActionResult DeleteTarefa(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
                return NotFound("Tarefa não encontrada.");

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges(); // Use SaveChanges() em vez de SaveChangesAsync()
            return NoContent();
        }
    }
}