using ConsoleApp1.Game;
using ConsoleApp1.Storage.Mapping;

namespace ConsoleApp1.Storage
{
    internal class GameInfoStorage : IGameInfoStorage
    {
        private readonly GamesDbContext _context;

        private readonly int _bestGamesCount = 4;
        public GameInfoStorage()
        {
            _context = new GamesDbContext();
        }
        public IQueryable<GameInfo> LoadBestGamesInfo()
            => _context.Games.OrderByDescending(g => g.Score).Select(g => GameInfoEntityMapper.Map(g)).Take(_bestGamesCount);

        public async Task SaveGameInfo(GameInfo info)
        {
            await _context.Games.AddAsync(GameInfoEntityMapper.Map(info));
            await _context.SaveChangesAsync();
        }
    }
}
