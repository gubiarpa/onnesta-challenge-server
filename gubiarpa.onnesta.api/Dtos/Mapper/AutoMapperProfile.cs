using AutoMapper;
using gubiarpa.onnesta.api.Models;

namespace gubiarpa.onnesta.api.Dtos.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<Employer, EmployerDto>();
            CreateMap<Job, JobDto>();
        }
    }
}
