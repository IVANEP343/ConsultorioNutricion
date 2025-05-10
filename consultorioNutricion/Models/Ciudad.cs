using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace consultorioNutricion.Models;

[Table("ciudad")]
public partial class Ciudad
{
    [Key]
    [Column("ciudadId")]
    public int CiudadId { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("provinciaId")]
    public int ProvinciaId { get; set; }

    [InverseProperty("Ciudad")]
    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    [InverseProperty("Ciudad")]
    public virtual ICollection<ProfesionalSalud> ProfesionalSaluds { get; set; } = new List<ProfesionalSalud>();

    [ForeignKey("ProvinciaId")]
    [InverseProperty("Ciudads")]
    public virtual Provincium Provincia { get; set; } = null!;
}
