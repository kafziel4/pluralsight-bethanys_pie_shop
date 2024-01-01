using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies => _bethanysPieShopDbContext.Pies.Include(p => p.Category);

        public IEnumerable<Pie> PiesOfTheWeek =>
            _bethanysPieShopDbContext.Pies
                .Include(p => p.Category)
                .Where(p => p.IsPieOfTheWeek);

        public Pie? GetPieById(int pieId) => _bethanysPieShopDbContext.Pies.Find(pieId);

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _bethanysPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
