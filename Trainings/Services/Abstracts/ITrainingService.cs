using Trainings.Data.Models;
using Trainings.Models.Request;
using Trainings.Models.Response;

namespace Trainings.Services.Abstracts
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingModel>> GetTrainings();
        Task<TrainingRequestModel> FindTrainingById(Guid? id);
        Task<TrainingRequestModel> FindTrainingByIdNoTracking(Guid? id);
        Task AddTraining(TrainingRequestModel trainingRequestModel);
        Task UpdateTraining(TrainingRequestModel trainingRequestModel);
    }
}
