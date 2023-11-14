using FIAP.Reconecta.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public int CompanyId { get { return Convert.ToInt32(User.FindFirst("CompanyId")?.Value); } }
        public int UserId { get { return Convert.ToInt32(User.FindFirst("UserId")?.Value); } }
        public CompanyType CompanyType { get { return (CompanyType)Convert.ToInt32(User.FindFirst("Type")?.Value); } }
    }
}
