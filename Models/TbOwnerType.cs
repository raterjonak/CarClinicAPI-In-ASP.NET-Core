using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("TB_OwnerType")]
    public partial class TbOwnerType
    {
        public TbOwnerType()
        {
            SerTbOwnerInfos = new HashSet<SerTbOwnerInfo>();
            TbOwnerCategories = new HashSet<TbOwnerCategory>();
        }

        [Key]
        [Column("OwnerTypeID")]
        public int OwnerTypeId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? OwnerType { get; set; }

        [InverseProperty("OwnerType")]
        public virtual ICollection<SerTbOwnerInfo> SerTbOwnerInfos { get; set; }
        [InverseProperty("OwnerType")]
        public virtual ICollection<TbOwnerCategory> TbOwnerCategories { get; set; }
    }
}
