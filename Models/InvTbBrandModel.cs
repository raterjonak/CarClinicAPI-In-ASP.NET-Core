using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("INV_TB_BrandModel")]
    public partial class InvTbBrandModel
    {
        public InvTbBrandModel()
        {
            InvTbPartInfos = new HashSet<InvTbPartInfo>();
        }

        [Key]
        [Column("ModelID")]
        public int ModelId { get; set; }
        [Column("BrandID")]
        public int BrandId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Model { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string? SalesDesignation { get; set; }

        [ForeignKey("BrandId")]
        [InverseProperty("InvTbBrandModels")]
        public virtual InvTbPrmVehicleBrand Brand { get; set; } = null!;
        [InverseProperty("Model")]
        public virtual ICollection<InvTbPartInfo> InvTbPartInfos { get; set; }
    }
}
