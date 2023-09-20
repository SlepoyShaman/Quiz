using ConsoleApp1.Game;
using ConsoleApp1.Storage.Entities;

namespace ConsoleApp1.Storage.Mapping
{
    internal static class GameInfoEntityMapper
    {
        public static GameInfoEntity Map(GameInfo gameInfo)
            => new GameInfoEntity()
            {
                GameDate = gameInfo.GameDate.ToString(),
                Score = gameInfo.Score,
                GameTime = $"{gameInfo.GameTime.Hour}:{gameInfo.GameTime.Minute}:{gameInfo.GameTime.Second}",
                CorrectAnswersCount = gameInfo.CorrectAnswersCount
            };

        public static GameInfo Map(GameInfoEntity gameInfoEntity)
            => new GameInfo()
            {
                Score = gameInfoEntity.Score,
                CorrectAnswersCount = gameInfoEntity.CorrectAnswersCount,
                GameDate = DateOnly.Parse(gameInfoEntity.GameDate),
                GameTime = TimeOnly.Parse(gameInfoEntity.GameTime)
            };

    }
}
