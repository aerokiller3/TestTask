using System.Collections.Generic;
using System.Linq;
using Database;

namespace Application.Game
{
    public class FilterGames
    {
        private readonly ApplicationDbContext _ctx;

        public FilterGames(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Domain.Models.Game> Do(string genre)
        {
            var games = _ctx.Games.Where(x => x.Genre.Contains(genre));

            return games;
        }
    }
}
