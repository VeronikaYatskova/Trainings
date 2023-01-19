using AutoMapper;
using Trainings.Data.Repositories.Abstracts;
using Trainings.Models.Response;
using Trainings.Services.Abstracts;

namespace Trainings.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TechnologyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TechnologyModel>> GetTechnologies()
        {
            var technologies = await unitOfWork.TechnologyRepository.GetTechnologies();

            return mapper.Map<IEnumerable<TechnologyModel>>(technologies);
        }
    }
}
