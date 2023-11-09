﻿using FIAP.Reconecta.Contracts.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public int CompanyId { get { return Convert.ToInt32(User.FindFirst("CompanyId")?.Value); } }
        public CompanyType CompanyType { get { return (CompanyType)Convert.ToInt32(User.FindFirst("CompanyId")?.Value); } }
    }
}