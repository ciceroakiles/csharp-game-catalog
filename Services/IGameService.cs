using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using game_catalog.Models;

namespace game_catalog
{
    public interface IGameService : IDisposable
    {
        Task<ActionResult<Game>> getById(Guid gameId);
        Task<ActionResult<Game>> create(Game game);
        Task<ActionResult<Game>> update(Guid gameId, Game game);
        Task<ActionResult<Game>> delete(Guid gameId);
        Task<ActionResult<List<Game>>> listAll();
    }
}
