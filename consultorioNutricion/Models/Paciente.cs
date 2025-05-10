using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace consultorioNutricion.Models;

[Table("paciente")]
public partial class Paciente
{
    [Key]
    [Column("pacienteId")]
    public int PacienteId { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("apellido")]
    [StringLength(100)]
    public string Apellido { get; set; } = null!;

    [Column("dni")]
    [StringLength(8)]
    [Unicode(false)]
    public string Dni { get; set; } = null!;

    [Column("calle")]
    [StringLength(100)]
    public string? Calle { get; set; }

    [Column("altura")]
    [StringLength(10)]
    public string? Altura { get; set; }

    [Column("piso")]
    [StringLength(10)]
    public string? Piso { get; set; }

    [Column("depto")]
    [StringLength(10)]
    public string? Depto { get; set; }

    [Column("ciudadId")]
    public int? CiudadId { get; set; }

    [Column("telefono")]
    [StringLength(20)]
    public string? Telefono { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("obraSocialId")]
    public int? ObraSocialId { get; set; }

    [Column("numeroAfiliado")]
    [StringLength(50)]
    public string? NumeroAfiliado { get; set; }

    [Column("fechaNacimiento")]
    public DateOnly? FechaNacimiento { get; set; }

    [Column("antecedentes")]
    public string? Antecedentes { get; set; }

    [Column("alergias")]
    public string? Alergias { get; set; }

    [Column("observaciones")]
    public string? Observaciones { get; set; }

    [Column("fechaAlta")]
    public DateOnly? FechaAlta { get; set; }

    [ForeignKey("CiudadId")]
    [InverseProperty("Pacientes")]
    public virtual Ciudad? Ciudad { get; set; }

    [ForeignKey("ObraSocialId")]
    [InverseProperty("Pacientes")]
    public virtual ObraSocial? ObraSocial { get; set; }

    [InverseProperty("Paciente")]
    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
