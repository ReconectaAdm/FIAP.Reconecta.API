﻿using System.ComponentModel;

namespace FIAP.Reconecta.Contracts.Enums
{
    public enum CompanyType
    {
        [Description("Empresa")]
        BASE = 0,
        [Description("Organização")]
        ORGANIZATION = 1,
        [Description("Estabelecimento")]
        ESTABLISHMENT = 2
    }
}
