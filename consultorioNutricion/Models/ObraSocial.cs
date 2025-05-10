using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace consultorioNutricion.Models;

[Table("obraSocial")]
public partial class ObraSocial
{
    [Key]
    [Column("obraSocialId")]
    public int ObraSocialId { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("nombrePlan")]
    [StringLength(100)]
    public string NombrePlan { get; set; } = null!;

    [InverseProperty("ObraSocial")]
    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
