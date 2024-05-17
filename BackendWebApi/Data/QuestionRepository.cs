using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Project.Core;

namespace Project.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CosmosClient cosmosClient;
        private readonly IConfiguration configuration;
        private readonly Container _questionContainer;

        public QuestionRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuration;
            var databaseName = configuration.GetSection("DatabaseName").Value;  
            var questionContainerName = "Question";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionContainerName);
        }

        public async Task<IEnumerable<QuestionModel>> GetQuestionsAsync(string questionID)
        {
            var query = _questionContainer.GetItemLinqQueryable<QuestionModel>()
                .Where(t => t.Equals(questionID))
                .ToFeedIterator();
            var question = new List<QuestionModel>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                question.AddRange(response);
            }
            return question;
        }

        
    }

   
}