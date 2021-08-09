using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using game_catalog.Models;

namespace game_catalog.Repositories
{
    public class GameRepository : IGameRepository
    {
        private DataContext dataContext;

        public GameRepository(DataContext dataContext) {
            this.dataContext = dataContext;
        }
        
        public async Task<Game> findById(Guid gameId)
        {
            return await dataContext.Games.FirstOrDefaultAsync(g => g.id == gameId);
        }

        public async Task<Game> create(Game game)
        {
            var newGame = new Game
            {
                id = Guid.NewGuid(),
                name = game.name,
                producer = game.producer,
                price = game.price
            };
            dataContext.Games.Add(newGame);
            await dataContext.SaveChangesAsync();
            return newGame;
        }

        public async Task<Game> update(Guid gameId, Game game)
        {
            var foundGame = findById(gameId);
            if (foundGame != null) {
                foundGame.Result.name = game.name;
                foundGame.Result.producer = game.producer;
                foundGame.Result.price = game.price;
                await dataContext.SaveChangesAsync();
            }
            return await foundGame;
        }

        public async Task<Game> delete(Guid gameId)
        {
            var foundGame = await dataContext.Games.FirstAsync(g => g.id == gameId);
            if (foundGame != null) {
                dataContext.Games.Remove(foundGame);
                await dataContext.SaveChangesAsync();
            }
            return foundGame;
        }

        public async Task<List<Game>> listAll()
        {
            var listGames = await dataContext.Games.ToListAsync();
            return listGames;
        }

        public void Dispose() { }
    }
}
