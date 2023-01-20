using System.ComponentModel.DataAnnotations;

namespace Trainings.Data.Models
{
    public class Training
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Technology is required")]
        public Guid TechnologyId { get; set; }
        public virtual Technology Technology { get; set; }
    }
}
