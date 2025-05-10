using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace consultorioNutricion.Models;

[Table("profesionalSalud")]
public partial class ProfesionalSalud
{
    [Key]
    [Column("profesionalSaludId")]
    public int ProfesionalSaludId { get; set; }

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

    [Column("matricula")]
    [StringLength(50)]
    public string Matricula { get; set; } = null!;

    [Column("especialidad")]
    [StringLength(100)]
    public string? Especialidad { get; set; }

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

    [ForeignKey("CiudadId")]
    [InverseProperty("ProfesionalSaluds")]
    public virtual Ciudad? Ciudad { get; set; }

    [InverseProperty("ProfesionalSalud")]
    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
