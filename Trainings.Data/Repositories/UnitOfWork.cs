using Trainings.Data.Context;
using Trainings.Data.Repositories.Abstracts;

namespace Trainings.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;

            TrainingRepository = new TrainingRepository(context);
            TechnologyRepository = new TechnologyRepository(context);
        }

        public ITrainingRepository TrainingRepository { get; private set; }

        public ITechnologyRepository TechnologyRepository { get; private set; }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
