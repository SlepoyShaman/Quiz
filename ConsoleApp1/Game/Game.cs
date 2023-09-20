using ConsoleApp1.Configuration;
using ConsoleApp1.Questions;
using ConsoleApp1.Storage;
using System.Diagnostics;

namespace ConsoleApp1.Game
{
    internal class Game
    {
        private readonly int _questionsCount;
        private readonly List<RootQuestion> _questions;
        private readonly IGameInfoStorage _storage;

        private int _score = 0;
        private int _correctAnswersCount = 0;
        private TimeOnly _gameTime = new TimeOnly(0);
        public Game(IConfiguration configuration, IGameInfoStorage storage)
        {
            _questionsCount = configuration.GetQuestionsCount();
            _questions = configuration.GetQuestions();
            _storage = storage;
        }
        public async Task StartGame()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < _questionsCount; i++)
            {
                var question = GetRandomQuestion();
                Console.WriteLine(question.Question);
                Console.WriteLine("Варианты ответа: ");
                foreach (var option in question.AnswerOptions)
                {
                    Console.WriteLine(option);
                }


                var isInTime = CheckUserAnswer(question.NumberOfCorrect).Wait(TimeSpan.FromSeconds(30));
                if (!isInTime) Console.WriteLine("Время вышло!");
            }
            stopWatch.Stop();
            _gameTime = _gameTime.Add(stopWatch.Elapsed);
            await _storage.SaveGameInfo(GetInfo());
        }

        private GameInfo GetInfo()
            => new GameInfo()
            {
                CorrectAnswersCount = _correctAnswersCount,
                GameDate = DateOnly.FromDateTime(DateTime.UtcNow),
                Score = _score,
                GameTime = _gameTime
            };

        private Task CheckUserAnswer(int numberOfCorrectAnswer)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Введите вариант ответа:");
                var answer = int.Parse(Console.ReadLine());
                if (answer == numberOfCorrectAnswer)
                {
                    _correctAnswersCount += 1;
                    _score += 1;
                    Console.WriteLine("Ответ верный!");
                }
                else
                {
                    _score -= 1;
                    Console.WriteLine("Ответ неверный!");
                }
            });
        }

        private RootQuestion GetRandomQuestion()
        {
            var random = new Random();
            var questionIndex = random.Next(0, _questions.Count);
            var question = _questions[questionIndex];
            _questions.RemoveAt(questionIndex);

            return question;
        }
    }
}
