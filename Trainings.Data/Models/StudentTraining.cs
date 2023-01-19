namespace Trainings.Data.Models
{
    public class StudentTraining
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public virtual User Student { get; set; }

        public Guid TrainingId { get; set; }
        public virtual Training Training { get; set; }
    }
}
