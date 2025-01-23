using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Model
{
    [Table("Tarefas")]
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }
        [MaxLength(500)]
        public string Descricao { get; set; }
        // Código comentado para fazermos uma atividade extra 
        //[Required]
        //public DateTime DataCriacao { get; set; } = DateTime.Now; 
        //public DateTime? DataConclusao { get; set; } 
        [Required]
        public DateTime Prazo { get; set; }
        [Required]
        public bool Concluida { get; set; } = false;
    }
}