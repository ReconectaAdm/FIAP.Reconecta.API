namespace FIAP.Reconecta.Models.DTO.Collect
{
    public class PutCollect
    {
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int EstablishmentId { get; set; }
        public int OrganizationId { get; set; }
        public decimal Value { get; set; }

        public static explicit operator Entities.Collect.Collect(PutCollect collect) => new()
        {
            Date = collect.Date,
            Status = collect.Status,
            EstablishmentId = collect.EstablishmentId,
            OrganizationId = collect.OrganizationId,
            Value = collect.Value
        };
    }
}
