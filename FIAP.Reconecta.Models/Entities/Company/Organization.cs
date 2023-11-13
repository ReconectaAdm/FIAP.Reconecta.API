namespace FIAP.Reconecta.Models.Entities.Company
{
    public class Organization : Company
    {
        public bool IsFavorite { get => Favorites.Any() && Favorites.First().IsFavorite; }
    }
}
