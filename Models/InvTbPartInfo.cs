using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("INV_TB_PartInfo")]
    public partial class InvTbPartInfo
    {
        public InvTbPartInfo()
        {
            SerTbJobServiceDiagParts = new HashSet<SerTbJobServiceDiagPart>();
        }

        [Key]
        [Column("PartID", TypeName = "numeric(18, 0)")]
        public decimal PartId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PartCode { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string PartDesc { get; set; } = null!;
        [Column("ParentID")]
        public int? ParentId { get; set; }
        [Column("BrandID")]
        public int? BrandId { get; set; }
        [Column("ModelID")]
        public int? ModelId { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PurchasePrice { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? RetailPrice { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? DealerPrice { get; set; }
        public bool? Reorder { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Barcode { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column("ModelYFrom")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ModelYfrom { get; set; }
        [Column("ModelYTo")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ModelYto { get; set; }
        [Column("EngineID")]
        public int? EngineId { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? TotalSold { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Size { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Currency { get; set; }
        public bool? Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? UpdateReason { get; set; }
        public int? PerVehicle { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? SupplyUnit { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? PriceCategory { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? TypeOfMovingParts { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? SourceOfCollection { get; set; }
        public int? Aging { get; set; }
        /// <summary>
        /// It will hold Paint/Local/Oil/Imported
        /// </summary>
        [StringLength(50)]
        [Unicode(false)]
        public string? PartType { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PartSource { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? OwnerShip { get; set; }

        [ForeignKey("EngineId")]
        [InverseProperty("InvTbPartInfos")]
        public virtual InvTbPrmEngine? Engine { get; set; }
        [ForeignKey("ModelId")]
        [InverseProperty("InvTbPartInfos")]
        public virtual InvTbBrandModel? Model { get; set; }
        [InverseProperty("Part")]
        public virtual ICollection<SerTbJobServiceDiagPart> SerTbJobServiceDiagParts { get; set; }
    }
}
