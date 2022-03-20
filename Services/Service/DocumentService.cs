using EFCoreModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Services.Service
{
    public interface IDocumentService
    {
        /// <summary>
        /// Gets document by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DocumentDTO> Get(int id);
        /// <summary>
        /// Get all documents from the database
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<DocumentDTO>> GetAll();
        /// <summary>
        /// Updates given document
        /// </summary>
        /// <param name="docDTO"></param>
        public Task Update(DocumentDTO docDTO);
        /// <summary>
        /// Deletes document entry
        /// </summary>
        /// <param name="docDTO"></param>
        public Task Delete(DocumentDTO docDTO);
        /// <summary>
        /// Creates new document entry
        /// </summary>
        /// <param name="docDTO"></param>
        /// <returns></returns>
        public Task Create(DocumentDTO docDTO);
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
        public async Task Delete(DocumentDTO docDTO)
        {
            var doc = await _db.Documents.FirstAsync(d => d.PkDocumentId == docDTO.PkDocumentId);
            _db.Documents.Remove(doc);
            await _db.SaveChangesAsync();
        }
        public async Task<DocumentDTO> Get(int id)
        {
            var doc = await _db.Documents.FirstOrDefaultAsync(d => d.PkDocumentId == id);
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
        public async Task Update(DocumentDTO docDTO)
        {
            var docDb = await _db.Documents.FirstAsync(d => d.PkDocumentId == docDTO.PkDocumentId);
            var doc = _mapper.Map<DocumentDTO, Document>(docDTO);
            docDb.Items = doc.Items;
            _db.Entry(docDb).CurrentValues.SetValues(doc);
            await _db.SaveChangesAsync();
        }
    }
}
