using System.Collections.Generic;
using System.Linq;
using Database;

namespace Application.Game
{
    public class GetGames
    {
        private readonly ApplicationDbContext _ctx;

        public GetGames(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GameViewModel> Do() =>
            _ctx.Games
                .Select(x => new GameViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    StudioDeveloper = x.StudioDeveloper,
                    Genre = x.Genre
                });


        public class GameViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string StudioDeveloper { get; set; }
            public string Genre { get; set; }
        }
    }
}
