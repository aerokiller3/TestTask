using System.Linq;
using System.Threading.Tasks;
using Database;

namespace Application.Game
{
    public class DeleteGame
    {
        private readonly ApplicationDbContext _ctx;

        public DeleteGame(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var game = _ctx.Games.FirstOrDefault(x => x.Id == id);
            _ctx.Games.Remove(game);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
