using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_JobInfo")]
    public partial class SerTbJobInfo
    {
        public SerTbJobInfo()
        {
            SerTbJobServiceDiagParts = new HashSet<SerTbJobServiceDiagPart>();
            SerTbJobServiceDiagnostics = new HashSet<SerTbJobServiceDiagnostic>();
        }

        [Key]
        [Column("JobID")]
        public long JobId { get; set; }
        [Column("JobReferenceID")]
        public long? JobReferenceId { get; set; }
        [Column("LocationID", TypeName = "numeric(18, 0)")]
        public decimal? LocationId { get; set; }
        [Column("VehicleID")]
        public long? VehicleId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? CustomerName { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PreviousMileage { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? InMileage { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CurrentMileage { get; set; }
        [StringLength(2000)]
        [Unicode(false)]
        public string? Remarks { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TranDate { get; set; }
        [Column("JobStatusID")]
        public int? JobStatusId { get; set; }
        public bool? JobClosed { get; set; }
        /// <summary>
        /// When gate pass generated, this time will be recorded as Job Closed date
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? JobClosedOn { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? CustomerComplain { get; set; }
        [StringLength(4000)]
        [Unicode(false)]
        public string? AdditionalTask { get; set; }
        [StringLength(2000)]
        [Unicode(false)]
        public string? AdditionalParts { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PromisedDeliveryDate { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? MiscAmount { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? MiscAmountLeft { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column("CurrentOwnerID")]
        public long? CurrentOwnerId { get; set; }
        [StringLength(30)]
        public string? JobTeam { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("SerTbJobInfos")]
        public virtual TbPrmUserInfo? CreatedByNavigation { get; set; }
        [ForeignKey("JobStatusId")]
        [InverseProperty("SerTbJobInfos")]
        public virtual SerTbPrmJobStatus? JobStatus { get; set; }
        [InverseProperty("Job")]
        public virtual ICollection<SerTbJobServiceDiagPart> SerTbJobServiceDiagParts { get; set; }
        [InverseProperty("Job")]
        public virtual ICollection<SerTbJobServiceDiagnostic> SerTbJobServiceDiagnostics { get; set; }
    }
}
