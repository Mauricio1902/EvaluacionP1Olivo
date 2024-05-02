using System.ComponentModel.DataAnnotations;

namespace EvaluacionP1Olivo.Models
{
    public class Carrera
    {
        [Key]
        public int CarreraNum { get; set; }

        public string nombre_carrera { get; set; }

        public int numero_semestres { get; set; }
    }
}
