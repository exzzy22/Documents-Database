using Services.Service.IService;
using EFCoreModels;
using AutoMapper;

namespace Services.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly BillsContext _db;
        private readonly IMapper _mapper;

        public DocumentService(BillsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IEnumerable<DocumentDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Document>, IEnumerable<DocumentDTO>>(_db.Documents);
        }
    }
}
