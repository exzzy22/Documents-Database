using EFCoreModels;

namespace Services
{
    public class DocumentDTO
    {
        public int PkDocumentId { get; set; }
        public string Company { get; set; } = null!;
        public DateTime? Date { get; set; }
        public string FileExt { get; set; } = null!;
        public byte[] DOC { get; set; } = null!;
        public List<string> ItemsInString { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
