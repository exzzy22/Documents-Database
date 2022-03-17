using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModels
{
    [Table("Document")]
    public partial class Document
    {
        public Document()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("PK_DocumentID")]
        public int PkDocumentId { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Company { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        [StringLength(10)]
        public string FileExt { get; set; } = null!;

        [Column("DOC")]
        public byte[] DOC { get; set; } = null!;

        [InverseProperty(nameof(Item.FkDocument))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
