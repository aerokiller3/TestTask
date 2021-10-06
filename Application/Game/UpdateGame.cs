using System.Linq;
using System.Threading.Tasks;
using Database;

namespace Application.Game
{
    public class UpdateGame
    {
        private readonly ApplicationDbContext _ctx;

        public UpdateGame(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Domain.Models.Game> Do(int id, Domain.Models.Game gameUpdate)
        {
            if (id != gameUpdate.Id)
                return null;

            var game = _ctx.Games.FirstOrDefault(x => x.Id == id);

            game.Title = gameUpdate.Title;
            game.StudioDeveloper = gameUpdate.StudioDeveloper;
            game.Genre = gameUpdate.Genre;
            await _ctx.SaveChangesAsync();

            return game;
        }
    }
}
