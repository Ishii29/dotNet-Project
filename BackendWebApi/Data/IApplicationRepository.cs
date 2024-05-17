using BackendWebApi.Core;
using Project.Core;

namespace Project.Data
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<ApplicationModel>> GetApplicationAsync(string applicationID);
    }
}