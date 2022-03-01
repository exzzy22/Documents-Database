using Services.Service.IService;
using EFCoreModels;
using AutoMapper;
using System.Linq;

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

        public DocumentDTO Get(int id)
        {
            var doc = _db.Documents.FirstOrDefault(d => d.PkDocumentId == id);
            if (doc != null)
            {
                return _mapper.Map<Document, DocumentDTO>(doc);
            }
            return null;
        }

        public IEnumerable<DocumentDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Document>, IEnumerable<DocumentDTO>>(_db.Documents);
        }
    }
}
