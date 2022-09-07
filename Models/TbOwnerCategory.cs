using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("TB_Owner_Category")]
    public partial class TbOwnerCategory
    {
        public TbOwnerCategory()
        {
            SerTbOwnerInfos = new HashSet<SerTbOwnerInfo>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Category { get; set; }
        [Column("OwnerTypeID")]
        public int? OwnerTypeId { get; set; }

        [ForeignKey("OwnerTypeId")]
        [InverseProperty("TbOwnerCategories")]
        public virtual TbOwnerType? OwnerType { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<SerTbOwnerInfo> SerTbOwnerInfos { get; set; }
    }
}
