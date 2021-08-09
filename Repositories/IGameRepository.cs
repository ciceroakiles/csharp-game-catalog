using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using game_catalog.Models;

namespace game_catalog
{
    public interface IGameRepository : IDisposable
    {
        Task<Game> findById(Guid gameId);
        Task<Game> create(Game game);
        Task<Game> update(Guid gameId, Game game);
        Task<Game> delete(Guid gameId);
        Task<List<Game>> listAll();
    }
}
