﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_residuo")]
    public class Residue
    {
        [HiddenInput]
        [Key]
        [Column("residuo_id")]
        public int Id { get; set; }

        [Display(Name = "Nome tipo de residuo")]
        [Column("residuo_nome")]
        public string? Nome { get; set; }

        [Display(Name = "Unidade de Medida do resíduo")]
        [Column("unidade_medida")]
        public string? UnidadeMedida { get; set; }

        [Display(Name = "Categoria do resíduo")]
        [Column("tipo_residuo_id")]
        public int Tipo { get; set; }

        [Column("residuo_data_criacao")]
        [NotMapped]
        public DateTime DataCriacao { get; set; }

        [Column("residuo_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }

        //public IList<Collect>? Coletas { get; set; }
        //public IList<Company>? Estabelecimentos { get; set; }
        //public IList<Company>? Organizacoes { get; set; }
    }
}
