
using Microsoft.AspNetCore.Mvc.Rendering;
using Trainings.Data.Models;

namespace Trainings.Models.Request
{
    public class TrainingRequestModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid TechnologyId { get; set; }

        public IEnumerable<SelectListItem> TechnologySelectList { get; set; }
    }
}
