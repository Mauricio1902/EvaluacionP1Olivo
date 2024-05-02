using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EvaluacionP1Olivo.Models
{
    public class EstudianteO
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public double numDecimal { get; set; }
        public Boolean verdadero { get; set; }
        public DateTime fecha { get; set; }

        [ForeignKey("CarreraNum")]
        public int? carreraID { get; set; }
        public Carrera? Carreras { get; set; }
    }
}
