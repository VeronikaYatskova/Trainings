using AutoMapper;
using Trainings.Data.Models;
using Trainings.Data.Repositories.Abstracts;
using Trainings.Models.Request;
using Trainings.Models.Response;
using Trainings.Services.Abstracts;

namespace Trainings.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TrainingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TrainingModel>> GetTrainings()
        {
            var trainings = await unitOfWork.TrainingRepository.GetTrainings();

            return trainings.Select(t => new TrainingModel
            {
                Id = t.Id,
                Name = t.Name,
                Image = t.Image,
                TechnologyName = t.Technology.Name,
            });
        }

        public async Task<TrainingRequestModel> FindTrainingById(Guid? id)
        {
            var training = await unitOfWork.TrainingRepository.FindTrainingById(id);

            return mapper.Map<TrainingRequestModel>(training);
        }

        public async Task<TrainingRequestModel> FindTrainingByIdNoTracking(Guid? id)
        {
            var training = await unitOfWork.TrainingRepository.FindTrainingByIdNoTracking(id);

            return mapper.Map<TrainingRequestModel>(training);
        }

        public async Task AddTraining(TrainingRequestModel trainingRequestModel)
        {
            var training = mapper.Map<Training>(trainingRequestModel);

            unitOfWork.TrainingRepository.AddTraining(training);

            await unitOfWork.SaveAsync();
        }

        public async Task UpdateTraining(TrainingRequestModel trainingRequestModel)
        {
            var training = mapper.Map<Training>(trainingRequestModel);

            unitOfWork.TrainingRepository.UpdateTraining(training);

            await unitOfWork.SaveAsync();
        }
    }
}
