﻿using FIAP.Reconecta.Models.Enums;

namespace FIAP.Reconecta.Models.DTO.Residue
{
    public class PostResidue
    {
        public string? Name { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public int Type { get; set; }
        public decimal AmountPaid { get; set; }

        public static explicit operator Entities.Residue.Residue(PostResidue dto)
            => new() { Name = dto.Name, UnitMeasure = dto.UnitMeasure, TypeId = dto.Type, AmountPaid = dto.AmountPaid };
    }
}
