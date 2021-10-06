using System.Threading.Tasks;
using Database;

namespace Application.Game
{
    public class CreateGame
    {
        private readonly ApplicationDbContext _ctx;

        public CreateGame(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Domain.Models.Game> Do(Domain.Models.Game game)
        {
            _ctx.Games.Add(game);
            await _ctx.SaveChangesAsync();
            return new Domain.Models.Game()
            {
                Id = game.Id,
                Title = game.Title,
                StudioDeveloper = game.StudioDeveloper,
                Genre = game.Genre,
            };
        }

        public class Request
        {
            public string Title { get; set; }
            public string StudioDeveloper { get; set; }
            public string Genre { get; set; }
        }

        public class Response
        {

            public int Id { get; set; }
            public string Title { get; set; }
            public string StudioDeveloper { get; set; }
            public string Genre { get; set; }
        }
    }
}
