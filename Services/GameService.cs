using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using game_catalog.Models;

namespace game_catalog.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;

        // Injeção de dependência
        public GameService(IGameRepository gameRepository) {
            this.gameRepository = gameRepository;
        }

        // GET
        public async Task<ActionResult<Game>> getById(Guid gameId) {
            return await gameRepository.findById(gameId);
        }

        // POST
        public async Task<ActionResult<Game>> create(Game game)
        {
            return await gameRepository.create(game);
        }

        // PUT
        public async Task<ActionResult<Game>> update(Guid gameId, Game game)
        {
            return await gameRepository.update(gameId, game);
        }

        // DELETE
        public async Task<ActionResult<Game>> delete(Guid gameId)
        {
            return await gameRepository.delete(gameId);
        }

        // listAll
        public async Task<ActionResult<List<Game>>> listAll()
        {
            return await gameRepository.listAll();
        }

        public void Dispose() { }
    }
}
