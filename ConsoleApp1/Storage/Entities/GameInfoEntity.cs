namespace ConsoleApp1.Storage.Entities
{
    internal class GameInfoEntity
    {
        public int Id { get; set; }
        public string GameTime { get; set; }
        public int CorrectAnswersCount { get; set; }
        public string GameDate { get; set; }
        public int Score { get; set; }
    }
}
