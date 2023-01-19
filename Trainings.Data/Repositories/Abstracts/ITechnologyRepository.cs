using Trainings.Data.Models;

namespace Trainings.Data.Repositories.Abstracts
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<Technology>> GetTechnologies();
    }
}
