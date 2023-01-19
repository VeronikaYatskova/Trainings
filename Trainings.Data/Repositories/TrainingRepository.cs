using Microsoft.EntityFrameworkCore;
using Trainings.Data.Context;
using Trainings.Data.Models;
using Trainings.Data.Repositories.Abstracts;

namespace Trainings.Data.Repositories
{
    public class TrainingRepository : RepositoryBase<Training>, ITrainingRepository
    {
        public TrainingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Training>> GetTrainings() =>
            await FindAll().ToListAsync();

        public void AddTraining(Training training) =>
            Create(training);

        public async Task<Training> FindTrainingById(Guid? id) =>
            await FindByCondition(t => t.Id == id).FirstOrDefaultAsync();

        public async Task<Training> FindTrainingByIdNoTracking(Guid ? id) =>
            await FindByCondition(t => t.Id == id).AsNoTracking().FirstOrDefaultAsync();

        public async Task UpdateTraining(Training training) =>
            Update(training);
    }
}
