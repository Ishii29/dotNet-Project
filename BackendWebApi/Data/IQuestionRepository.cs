using Project.Core;

namespace Project.Data
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionModel>> GetQuestionsAsync(string questionType);
    }
}