using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace consultorioNutricion.Models;

[Table("provincia")]
public partial class Provincium
{
    [Key]
    [Column("provinciaId")]
    public int ProvinciaId { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Provincia")]
    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
}
