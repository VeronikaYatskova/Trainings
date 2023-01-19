namespace Trainings.Data.Repositories.Abstracts
{
    public interface IUnitOfWork
    {
        ITrainingRepository TrainingRepository { get; }
        ITechnologyRepository TechnologyRepository { get; }

        public Task SaveAsync();
    }
}
