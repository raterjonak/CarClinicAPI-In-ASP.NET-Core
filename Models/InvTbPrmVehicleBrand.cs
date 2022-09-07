using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("INV_TB_PrmVehicleBrand")]
    public partial class InvTbPrmVehicleBrand
    {
        public InvTbPrmVehicleBrand()
        {
            InvTbBrandModels = new HashSet<InvTbBrandModel>();
            SerTbVehicleInfos = new HashSet<SerTbVehicleInfo>();
        }

        [Key]
        [Column("BrandID")]
        public int BrandId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? BrandDesc { get; set; }
        public bool? ForSalesOnly { get; set; }
        public byte? Serial { get; set; }
        public byte? AvailableFor { get; set; }

        [InverseProperty("Brand")]
        public virtual ICollection<InvTbBrandModel> InvTbBrandModels { get; set; }
        [InverseProperty("Brand")]
        public virtual ICollection<SerTbVehicleInfo> SerTbVehicleInfos { get; set; }
    }
}
