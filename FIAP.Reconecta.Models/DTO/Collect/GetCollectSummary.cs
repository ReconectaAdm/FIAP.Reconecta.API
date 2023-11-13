using FIAP.Reconecta.Models.Entities.Residue;

namespace FIAP.Reconecta.Models.DTO.Collect
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
                //var types = collect.Residues!.GroupBy(cr => new { cr.Residue.Type.Id, cr.Residue.Type.Name });

                //foreach (var type in types)
                //{
                //    if (Residues.Any(rs => rs.Id == type.Key.Id))
                //        Residues.First(rs => rs.Id == type.Key.Id).Qtd += 1;

                //    else
                //        Residues = Residues.Append(new GetRankingSummary { Id = type.Key.Id, Name = type.Key.Name, Qtd = 1 });
                //}

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

    public class GetRankingSummary
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Qtd { get; set; }
    }
}
