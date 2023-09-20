using ConsoleApp1.Questions;

namespace ConsoleApp1.Configuration
{
    internal interface IConfiguration
    {
        public int GetQuestionsCount();
        public List<RootQuestion> GetQuestions();
    }
}
