using Project.Core;

namespace Project.Data
{
    public interface IProgramRepository
    {
        Task<IEnumerable<ProgramsModel>> GetProgramsAsync(string employerID);
    }
}