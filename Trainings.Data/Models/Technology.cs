using System.ComponentModel.DataAnnotations;

namespace Trainings.Data.Models
{
    public class Technology
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] 
        public string Description { get; set; }

        public virtual IList<Training> Trainings { get; set; }
    }
}
