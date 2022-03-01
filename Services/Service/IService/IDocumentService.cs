namespace Services.Service.IService
{
    public interface IDocumentService
    {
        public DocumentDTO Get(int id);
        public IEnumerable<DocumentDTO> GetAll();
    }
}
