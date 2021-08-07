using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using game_catalog.Models;

namespace game_catalog.Controllers
{
    [Route("api/v1/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private DataContext _context;

        public GameController(DataContext dc)
        {
            _context = dc;
        }

        /// <summary>Buscar um jogo pelo id</summary>
        /// <param name="gameId">Id do jogo buscado</param>
        /// <response code="200">Retorna o jogo</response>
        /// <response code="404">Caso não haja jogo com este id</response>
        [HttpGet("{gameId:guid}")]
        public async Task<ActionResult<Game>> getById([FromRoute] Guid gameId)
        {
            var listGames = await _context.Games.ToListAsync();
            foreach (Game game in listGames) {
                if (game.id == gameId) return Ok(game);
            }
            return NotFound();
        }

        /// <summary>Inserir um jogo</summary>
        /// <param name="model">Corpo da requisição</param>
        /// <response code="200">Retorna o jogo</response>
        [HttpPost]
        public async Task<ActionResult<Game>> createGame([FromBody] Game model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Games.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        /// <summary>Atualizar um jogo</summary>
        /// <param name="gameId">Id do jogo buscado</param>
        /// <param name="model">Corpo da requisição</param>
        /// <response code="200">Caso o jogo seja atualizado com sucesso</response>
        /// <response code="404">Caso não haja jogo com este id</response>
        [HttpPut("{gameId:guid}")]
        public async Task<ActionResult<Game>> updateGame([FromRoute] Guid gameId,
                                                         [FromBody] Game model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var listGames = await _context.Games.ToListAsync();
            foreach (Game game in listGames) {
                if (game.id == gameId) {
                    model.id = gameId;
                    game.name = model.name;
                    game.producer = model.producer;
                    game.price = model.price;
                    await _context.SaveChangesAsync();
                    return Ok(model);
                }
            }
            return NotFound();
        }

        /// <summary>Excluir um jogo</summary>
        /// <param name="gameId">Id do jogo a ser excluído</param>
        /// <response code="200">Caso seja removido com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este id</response>
        [HttpDelete("{gameId:guid}")]
        public async Task<ActionResult> deleteById([FromRoute] Guid gameId)
        {
            var listGames = await _context.Games.ToListAsync();
            foreach (Game game in listGames) {
                if (game.id == gameId) {
                    listGames.Remove(game);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            return NotFound();
        }

        /// <summary>Listar todos os jogos</summary>
        /// <response code="200">Retorna os jogos</response>
        /// <response code="204">Caso não haja jogos</response>
        [HttpGet]
        public async Task<ActionResult<List<Game>>> listAll([FromServices] DataContext context)
        {
            var listGames = await _context.Games.ToListAsync();
            if (listGames.Count == 0) return NoContent();
            return Ok(listGames);
        }

    }
}
