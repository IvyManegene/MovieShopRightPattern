using MovieShopRightPattern.Models;

namespace MovieShopRightPattern.Data.EFCore
{
    public class EfCoreMovieRepository : EfCoreRepository<Movie, MovieShopRightPatternContext>
    {
        public EfCoreMovieRepository(MovieShopRightPatternContext Context)
            : base(Context)
        {
        }
    }
}
