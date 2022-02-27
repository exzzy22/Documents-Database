using EFCoreModels;

namespace Services
{
    public class ItemDTO
    {
        public string Name { get; set; } = null!;
        public int FkDocumentId { get; set; }
        public virtual Document FkDocument { get; set; } = null!;
    }
}
