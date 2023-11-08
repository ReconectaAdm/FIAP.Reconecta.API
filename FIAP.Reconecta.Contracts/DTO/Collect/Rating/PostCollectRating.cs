using FIAP.Reconecta.Contracts.Models.Collect;

namespace FIAP.Reconecta.Contracts.DTO.Collect.Rating
{
    public class PostCollectRating
    {
        public string? Comment { get; set; }
        public decimal Punctuality { get; set; }
        public decimal Satisfaction { get; set; }
        public int CollectId { get; set; }

        public static explicit operator CollectRating(PostCollectRating rating) => new()
        {
            Punctuality = rating.Punctuality,
            Satisfaction = rating.Satisfaction,
            Comment = rating.Comment,
            CollectId = rating.CollectId
        };
    }
}
