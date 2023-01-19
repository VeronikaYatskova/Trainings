using System.ComponentModel.DataAnnotations;

namespace Trainings.Data.Models
{
    public class Training
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }

        [Required]
        public Guid TechnologyId { get; set; }
        public virtual Technology Technology { get; set; }
    }
}
