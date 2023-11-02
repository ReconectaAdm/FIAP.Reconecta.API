//using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace FIAP.Reconecta.Contracts.Models
//{
//    [Table("t_residuo_empresa")]
//    public class CompanyResidue
//    {
//        [HiddenInput]
//        [Key]
//        [Column("residuo_empresa_id")]
//        public int Id { get; set; }

//        [Column("valor_pago")]
//        public decimal ValorPago { get; set; }

//        [Column("residuo_empresa_data_criacao")]
//        public DateTime DataCriacao { get; set; }

//        [Column("residuo_empresa_data_atualizacao")]
//        public DateTime DataAtualizacao { get; set; }

//        [Column("residuo_id")]
//        public int ResiduoId { get; set; }

//        [Column("empresa_id")]
//        public int EmpresaId { get; set; }

//        public Residue? Residuo { get; set; }
//        public Company? Estabelecimento { get; set; }
//    }
//}
