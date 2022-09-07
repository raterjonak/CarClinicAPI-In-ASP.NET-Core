using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_VehicleInfo")]
    public partial class SerTbVehicleInfo
    {
        [Key]
        [Column("VehInfoID")]
        public long VehInfoId { get; set; }
        [Column("VIN")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Vin { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string RegNo { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string? Make { get; set; }
        [Column("BrandID")]
        public int? BrandId { get; set; }
        [Column("ModelID")]
        public int? ModelId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? ModelYear { get; set; }
        [Column("EngineID")]
        public int? EngineId { get; set; }
        [Column("VehicleTypeID")]
        public int? VehicleTypeId { get; set; }
        [Column("OwnerID")]
        public long? OwnerId { get; set; }
        [Column("VatPriceFactorID")]
        public int? VatPriceFactorId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Transmission { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Color { get; set; }
        public int? KeyNumber { get; set; }
        public int? RadioCode { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? DriverContactNumber { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? Fuel { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? EngineType { get; set; }
        public int? LubCapacity { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? SalesDesignation { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("IsGeneratedFSCoupon")]
        public bool? IsGeneratedFscoupon { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey("BrandId")]
        [InverseProperty("SerTbVehicleInfos")]
        public virtual InvTbPrmVehicleBrand? Brand { get; set; }
        [ForeignKey("OwnerId")]
        [InverseProperty("SerTbVehicleInfos")]
        public virtual SerTbOwnerInfo? Owner { get; set; }
        [ForeignKey("VehicleTypeId")]
        [InverseProperty("SerTbVehicleInfos")]
        public virtual SerTbPrmVehicleType? VehicleType { get; set; }
    }
}
