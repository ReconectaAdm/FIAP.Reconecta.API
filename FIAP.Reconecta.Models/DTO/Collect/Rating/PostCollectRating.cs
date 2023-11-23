using FIAP.Reconecta.Models.Entities.Collect;

namespace FIAP.Reconecta.Models.DTO.Collect.Rating
{
    public class PostCollectRating
    {
        public string? Comment { get; set; }
        public decimal Punctuality { get; set; }
        public decimal Satisfaction { get; set; }
        public int CollectId { get; set; }

        public static explicit operator CollectRating(PostCollectRating dto) => new()
        {
            Punctuality = dto.Punctuality,
            Satisfaction = dto.Satisfaction,
            Comment = dto.Comment,
            CollectId = dto.CollectId
        };
    }
}
