using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_JobServiceDiagParts")]
    public partial class SerTbJobServiceDiagPart
    {
        [Key]
        [Column("DiagPartID")]
        public long DiagPartId { get; set; }
        [Column("JobID")]
        public long? JobId { get; set; }
        [Column("ServiceID")]
        public long ServiceId { get; set; }
        [Column("PartID", TypeName = "numeric(18, 0)")]
        public decimal PartId { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PartQty { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CustomerPart { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? EstPrice { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? SellPrice { get; set; }
        public long? AvailableQty { get; set; }
        public bool? Approved { get; set; }
        public bool Ordered { get; set; }
        public bool IsRecommended { get; set; }
        public bool? ReqDone { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? ServicePayBy { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PartPayBy { get; set; }
        public bool? SrvApproved { get; set; }
        public bool? Picked { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PickedQty { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PickedOn { get; set; }
        public bool? Booked { get; set; }
        public int? BookedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BookedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BookedUntil { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public bool? IsEstimated { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EstimatedOn { get; set; }
        public int? Estimatedby { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? Remarks { get; set; }
        public string? Recommendation { get; set; }
        [Column("TStamp")]
        public byte[]? Tstamp { get; set; }
        [Column("JobLocationID")]
        public long? JobLocationId { get; set; }

        [ForeignKey("JobId")]
        [InverseProperty("SerTbJobServiceDiagParts")]
        public virtual SerTbJobInfo? Job { get; set; }
        [ForeignKey("PartId")]
        [InverseProperty("SerTbJobServiceDiagParts")]
        public virtual InvTbPartInfo Part { get; set; } = null!;
    }
}
