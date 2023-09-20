namespace ConsoleApp1.Game
{
    internal class GameInfo
    {
        public TimeOnly GameTime { get; set; }
        public int CorrectAnswersCount { get; set; }
        public DateOnly GameDate { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return $"Время игры: {GameTime.Hour}:{GameTime.Minute}:{GameTime.Second}, кол-во правильных ответов: {CorrectAnswersCount}, счет: {Score}, дата игры: {GameDate}";
        }
    }
}
