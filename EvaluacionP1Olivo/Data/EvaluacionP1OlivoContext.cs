using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EvaluacionP1Olivo.Models;

namespace EvaluacionP1Olivo.Data
{
    public class EvaluacionP1OlivoContext : DbContext
    {
        public EvaluacionP1OlivoContext (DbContextOptions<EvaluacionP1OlivoContext> options)
            : base(options)
        {
        }

        public DbSet<EvaluacionP1Olivo.Models.EstudianteO> EstudianteO { get; set; } = default!;
        public DbSet<EvaluacionP1Olivo.Models.Carrera> Carrera { get; set; } = default!;
    }
}
