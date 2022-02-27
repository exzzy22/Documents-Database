using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModels
{
    [Table("Item")]
    public partial class Item
    {
        [Key]
        [Column("PK_ItemID")]
        public int PkItemId { get; set; }
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("FK_DocumentID")]
        public int FkDocumentId { get; set; }

        [ForeignKey(nameof(FkDocumentId))]
        [InverseProperty(nameof(Document.Items))]
        public virtual Document FkDocument { get; set; } = null!;
    }
}
