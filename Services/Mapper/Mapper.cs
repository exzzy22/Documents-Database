using AutoMapper;
using EFCoreModels;

namespace Services.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Document, DocumentDTO>().ReverseMap();
            CreateMap<DocumentDTO, Document>().ReverseMap().ForMember(d => d.ItemsInString, f => f.MapFrom(s => s.Items.Select(i=>i.Name)));
            CreateMap<Item, ItemDTO>().ReverseMap();
        }
    }
}
