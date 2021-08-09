using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using game_catalog.Models;

namespace game_catalog.Controllers
{
    [Route("api/v1/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        /// <summary>Buscar um jogo pelo id</summary>
        /// <param name="gameId">Id do jogo buscado</param>
        /// <response code="200">Retorna o jogo</response>
        /// <response code="204">Caso não haja jogo com este id</response>
        [HttpGet("{gameId:guid}")]
        public async Task<ActionResult<Game>> getById([FromRoute] Guid gameId)
        {
            var game = await gameService.getById(gameId);
            if (game == null) return NotFound();
            return Ok(game.Value);
        }

        /// <summary>Inserir um jogo</summary>
        /// <param name="model">Corpo da requisição</param>
        /// <response code="200">Retorna o jogo</response>
        [HttpPost]
        public async Task<ActionResult<Game>> createGame([FromBody] Game model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var game = await gameService.create(model);
            return Ok(game.Value);
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
            try {
                var game = await gameService.update(gameId, model);
                if (game != null) return Ok(game.Value);
            } catch (System.NullReferenceException) { }
            return NotFound();
        }

        /// <summary>Excluir um jogo</summary>
        /// <param name="gameId">Id do jogo a ser excluído</param>
        /// <response code="200">Caso seja removido com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este id</response>
        [HttpDelete("{gameId:guid}")]
        public async Task<ActionResult<Game>> deleteById([FromRoute] Guid gameId)
        {
            try {
                var game = await gameService.delete(gameId);
                if (game != null) return Ok();
            } catch (System.InvalidOperationException) { }
            return NotFound();
        }

        /// <summary>Listar todos os jogos</summary>
        /// <response code="200">Retorna os jogos</response>
        /// <response code="204">Caso não haja jogos</response>
        [HttpGet]
        public async Task<ActionResult<List<Game>>> listAll()
        {
            var listGames = await gameService.listAll();
            if (listGames.Value.Count == 0) return NoContent();
            return Ok(listGames.Value);
        }
    }
}
