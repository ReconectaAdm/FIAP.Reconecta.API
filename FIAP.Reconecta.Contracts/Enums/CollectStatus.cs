using System.ComponentModel;

namespace FIAP.Reconecta.Contracts.Enums
{
    public enum CollectStatus
    {
        [Description("Pendente")]
        PENDING = 1,
        [Description("Em andamento")]
        IN_PROGRESS = 2,
        [Description("Concluído")]
        CONCLUDED = 3,
        [Description("Cancelado")]
        CANCELLED = 4,
        [Description("Agendado")]
        SCHEDULED = 5,
    }
}
