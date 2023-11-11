﻿using FIAP.Reconecta.Contracts.Models.Residue;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IResidueService : IBaseService<Residue>
    {
        IEnumerable<Residue> Get(int organizationId = 0);
    }
}
