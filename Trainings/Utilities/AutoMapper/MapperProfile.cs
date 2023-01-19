using AutoMapper;
using Trainings.Data.Models;
using Trainings.Models.Request;
using Trainings.Models.Response;

namespace Trainings.Utilities.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Training, TrainingRequestModel>();
            CreateMap<Technology, TechnologyModel>();
            CreateMap<TrainingRequestModel, Training>();
        }
    }
}
