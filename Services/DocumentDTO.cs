using EFCoreModels;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class DocumentDTO
    {
        public int PkDocumentId { get; set; }
        [Required(ErrorMessage = "Comapny name is required")]
        public string Company { get; set; } = null!;
        public DateTime? Date { get; set; }
        public string FileExt { get; set; } = null!;
        public byte[] DOC { get; set; } = null!;
        public List<string> ItemsInString { get; set; }
        [Required(ErrorMessage = "Select a file")]
        [Range(typeof(bool),"true", "true", ErrorMessage = "Select a file")]
        public bool FileExist { get; set; } = false;
        public virtual ICollection<Item> Items { get; set; }
    }
}
