namespace Services.Service.IService
{
    public interface IDocumentService
    {
        public IEnumerable<DocumentDTO> GetAll();
    }
}
