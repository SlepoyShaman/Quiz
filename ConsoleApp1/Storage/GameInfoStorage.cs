using ConsoleApp1.Game;
using ConsoleApp1.Storage.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Storage
{
    internal class GameInfoStorage : IGameInfoStorage
    {
        private readonly int _bestGamesCount = 4;
        public GameInfoStorage()
        {

        }
        public async Task<GameInfo[]> LoadBestGamesInfo()
        {
            using (var context = new GamesDbContext())
            {
                return await context.Games.OrderByDescending(g => g.Score).Select(g => GameInfoEntityMapper.Map(g)).Take(_bestGamesCount).ToArrayAsync();
            }
        }

        public async Task SaveGameInfo(GameInfo info)
        {
            using (var context = new GamesDbContext())
            {
                await context.Games.AddAsync(GameInfoEntityMapper.Map(info));
                await context.SaveChangesAsync();
            }
        }
    }
}
