namespace FIAP.Reconecta.Models.DTO.Collect.Summary
{
    public class GetCollectSummary
    {
        public int Collects { get; set; }
        public int Points { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<GetRankingSummary> Residues { get; set; } = Enumerable.Empty<GetRankingSummary>();
        public IEnumerable<GetRankingSummary> Status { get; set; } = Enumerable.Empty<GetRankingSummary>();

        public void GenerateResiduesSummary(IEnumerable<Entities.Collect.Collect> collects)
        {
            foreach (var collect in collects)
            {
                if (collect is not null && collect.Residues is not null)
                {
                    foreach (var residue in collect.Residues)
                    {
                        if (Residues.Any(rs => rs.Id == residue.Residue.Type.Id))
                            Residues.First(rs => rs.Id == residue.Residue.Type.Id).Qtd += 1;

                        else
                            Residues = Residues.Append(new GetRankingSummary
                            {
                                Id = residue.Residue.Type.Id,
                                Name = residue.Residue.Type.Name,
                                Qtd = 1
                            });
                    }
                }
            }
        }

        public void GenerateStatusSummary(IEnumerable<Entities.Collect.Collect> collects)
        {
            foreach (var collect in collects)
            {
                if (Status.Any(s => s.Id == (int)collect.Status))
                    Status.First(s => s.Id == (int)collect.Status).Qtd += 1;

                else
                    Status = Status.Append(new GetRankingSummary { Id = (int)collect.Status, Name = collect.Status.ToString(), Qtd = 1 });
            }
        }
    }
}
