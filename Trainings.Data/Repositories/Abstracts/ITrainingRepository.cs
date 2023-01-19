using Trainings.Data.Models;

namespace Trainings.Data.Repositories.Abstracts
{
    public interface ITrainingRepository
    {
        Task<IEnumerable<Training>> GetTrainings();
        Task<Training> FindTrainingById(Guid? id);
        Task<Training> FindTrainingByIdNoTracking(Guid? id);
        void AddTraining(Training training);
        Task UpdateTraining(Training training);
    }
}
