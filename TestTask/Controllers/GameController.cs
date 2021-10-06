using System.Threading.Tasks;
using Application.Game;
using Database;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public GameController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get() => Ok(new GetGames(_ctx).Do());

        [HttpPost]
        public IActionResult Create(Game game) => Ok(new CreateGame(_ctx).Do(game));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok((await new DeleteGame(_ctx).Do(id)));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Game game) => Ok((await new UpdateGame(_ctx).Do(id, game)));

        [HttpGet("{genre}")]
        public IActionResult Filter(string genre) => Ok(new FilterGames(_ctx).Do(genre));
    }
}
