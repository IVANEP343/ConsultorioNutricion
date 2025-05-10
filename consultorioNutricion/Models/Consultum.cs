using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace consultorioNutricion.Models;

[Table("consulta")]
public partial class Consultum
{
    [Key]
    [Column("consultaId")]
    public int ConsultaId { get; set; }

    [Column("turnoId")]
    public int TurnoId { get; set; }

    [Column("peso", TypeName = "decimal(5, 2)")]
    public decimal? Peso { get; set; }

    [Column("grasaTotal", TypeName = "decimal(5, 2)")]
    public decimal? GrasaTotal { get; set; }

    [Column("grasaVisceral", TypeName = "decimal(5, 2)")]
    public decimal? GrasaVisceral { get; set; }

    [Column("masaMuscular", TypeName = "decimal(5, 2)")]
    public decimal? MasaMuscular { get; set; }

    [Column("medicacion")]
    public string? Medicacion { get; set; }

    [Column("pesoPosible", TypeName = "decimal(5, 2)")]
    public decimal? PesoPosible { get; set; }

    [Column("actividadFisica")]
    public string? ActividadFisica { get; set; }

    [Column("habitosNutricionales")]
    public string? HabitosNutricionales { get; set; }

    [Column("alimentosNoConsumidos")]
    public string? AlimentosNoConsumidos { get; set; }

    [Column("observaciones")]
    public string? Observaciones { get; set; }

    [Column("diagnosticoNutricional")]
    public string? DiagnosticoNutricional { get; set; }

    [Column("indicaciones")]
    public string? Indicaciones { get; set; }

    [ForeignKey("TurnoId")]
    [InverseProperty("Consulta")]
    public virtual Turno Turno { get; set; } = null!;
}
