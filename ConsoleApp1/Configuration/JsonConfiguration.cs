using ConsoleApp1.Questions;
using System.Text.Json;

namespace ConsoleApp1.Configuration
{
    internal class JsonConfiguration : IConfiguration
    {

        private readonly RootConfig _rootConfig;
        public JsonConfiguration(string jsonFilePath)
        {
            _rootConfig = GetConfig(jsonFilePath);
        }
        public List<RootQuestion> GetQuestions()
            => _rootConfig.Questions;

        public int GetQuestionsCount()
            => _rootConfig.QuestionsCount;

        private RootConfig GetConfig(string configPath)
        {
            using (var reader = new StreamReader(configPath))
            {
                var jsonString = reader.ReadToEnd();
                return JsonSerializer.Deserialize<RootConfig>(jsonString);
            }
        }
    }
}
