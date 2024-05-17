using BackendWebApi.Core;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Project.Core;
using Project.Data;

namespace BackendWebApi.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly CosmosClient cosmosClient;
        private readonly IConfiguration configuration;
        private readonly Container _applicationContainer;

        public ApplicationRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuration;
            var databaseName = configuration.GetSection("DatabaseName").Value;  
            var applicationContainerName = "Application";
            _applicationContainer = cosmosClient.GetContainer(databaseName, applicationContainerName);
        }
        public async Task<IEnumerable<ApplicationModel>> GetApplicationAsync(string applicationID)
        {
            var query = _applicationContainer.GetItemLinqQueryable<ApplicationModel>()
                .Where(t => t.Equals(applicationID))
                .ToFeedIterator();
            var applications = new List<ApplicationModel>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                applications.AddRange(response);
            }
            return applications;
        }

       
    }
}