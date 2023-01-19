using Trainings.Models.Response;

namespace Trainings.Services.Abstracts
{
    public interface ITechnologyService
    {
        Task<IEnumerable<TechnologyModel>> GetTechnologies();
    }
}
