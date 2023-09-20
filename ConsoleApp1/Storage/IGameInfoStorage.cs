using ConsoleApp1.Game;

namespace ConsoleApp1.Storage
{
    internal interface IGameInfoStorage
    {
        public Task SaveGameInfo(GameInfo info);
        public Task<GameInfo[]> LoadBestGamesInfo();
    }
}
