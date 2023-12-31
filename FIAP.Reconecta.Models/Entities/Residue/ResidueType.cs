﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Models.Entities.Residue
{
    [Table("t_tipo_residuo")]
    public class ResidueType
    {
        [Key]
        [Column("tipo_residuo_id")]
        public int Id { get; set; }
        [Column("tipo_residuo_nome")]
        public string? Name { get; set; }
        [Column("caminho")]
        public string? Path { get; set; }
    }
}
