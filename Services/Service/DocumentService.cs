using Services.Service;
using EFCoreModels;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Service
{
    public interface IDocumentService
    {
        public DocumentDTO Get(int id);
        public Task<IEnumerable<DocumentDTO>> GetAll();
        public void Update(DocumentDTO docDTO);
        public void Delete(DocumentDTO docDTO);
        public Task Create(DocumentDTO docDTO);
        public IEnumerable<string?> GetTags();
    }
    public class DocumentService : IDocumentService
    {
        private readonly BillsContext _db;
        private readonly IMapper _mapper;

        public DocumentService(BillsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(DocumentDTO docDTO)
        {
            var doc = _mapper.Map<DocumentDTO, Document>(docDTO);
            await _db.Documents.AddAsync(doc);
            await _db.SaveChangesAsync();

        }

        public void Delete(DocumentDTO docDTO)
        {
            var doc = _db.Documents.First(d => d.PkDocumentId == docDTO.PkDocumentId);
            _db.Documents.Remove(doc);
            _db.SaveChanges();
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

        public async Task<IEnumerable<DocumentDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Document>, IEnumerable<DocumentDTO>>(_db.Documents);
        }

        public IEnumerable<string?> GetTags()
        {
            return _db.Documents.Select(d=>d.Tag).Distinct();
        }

        public void Update(DocumentDTO docDTO)
        {
            var docDb = _db.Documents.First(d => d.PkDocumentId == docDTO.PkDocumentId);
            var doc = _mapper.Map<DocumentDTO, Document>(docDTO);
            docDb.Items = doc.Items;
            _db.Entry(docDb).CurrentValues.SetValues(doc);
            _db.SaveChanges();
        }
    }
}
