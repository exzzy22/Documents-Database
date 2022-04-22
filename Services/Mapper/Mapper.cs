using AutoMapper;
using EFCoreModels;

namespace Services.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<DocumentDTO, Document>().ReverseMap();

        }
    }
}
