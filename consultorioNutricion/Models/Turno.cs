using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace consultorioNutricion.Models;

[Table("turno")]
public partial class Turno
{
    [Key]
    [Column("turnoId")]
    public int TurnoId { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column("motivo")]
    [StringLength(255)]
    public string? Motivo { get; set; }

    [Column("pacienteId")]
    public int PacienteId { get; set; }

    [Column("profesionalSaludId")]
    public int ProfesionalSaludId { get; set; }

    [InverseProperty("Turno")]
    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    [ForeignKey("PacienteId")]
    [InverseProperty("Turnos")]
    public virtual Paciente Paciente { get; set; } = null!;

    [ForeignKey("ProfesionalSaludId")]
    [InverseProperty("Turnos")]
    public virtual ProfesionalSalud ProfesionalSalud { get; set; } = null!;
}
