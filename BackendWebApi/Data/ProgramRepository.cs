using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Project.Core;

namespace Project.Data
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly CosmosClient cosmosClient;
        private readonly IConfiguration configuration;
        private readonly Container _programContainer;

        public ProgramRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuration;
            var databaseName = configuration.GetSection("DatabaseName").Value;  
            var programContainerName = "Program";
            _programContainer = cosmosClient.GetContainer(databaseName, programContainerName);
        }
        public async Task<IEnumerable<ProgramsModel>> GetProgramsAsync(string employerID)
        {
            var query = _programContainer.GetItemLinqQueryable<ProgramsModel>()
                .Where(t => t.Equals(employerID))
                .ToFeedIterator();
            var program = new List<ProgramsModel>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                program.AddRange(response);
            }
            return program;
        }

    }
}