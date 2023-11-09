﻿namespace FIAP.Reconecta.Contracts.DTO.Residue
{
    public class PutResidue
    {
        public string? Name { get; set; }
        public string? UnitOfMeasure { get; set; }
        public int Type { get; set; }

        public static explicit operator Models.Residue.Residue(PutResidue residue)
            => new() { Name = residue.Name, UnitOfMeasure = residue.UnitOfMeasure, Type = residue.Type };
    }
}
