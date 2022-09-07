using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_JobServiceDiagnostic")]
    public partial class SerTbJobServiceDiagnostic
    {
        [Key]
        [Column("ServiceDiagID")]
        public long ServiceDiagId { get; set; }
        [Column("JobID")]
        public long JobId { get; set; }
        [Column("JobLocationID")]
        public long? JobLocationId { get; set; }
        [Column("ServiceID")]
        public long ServiceId { get; set; }
        public bool? DiagReq { get; set; }
        public bool? IsForEstimation { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CustomerPart { get; set; }
        public bool? ReturnJob { get; set; }
        [Column("TeamID")]
        public int? TeamId { get; set; }
        [Column("AssignedEngineerID")]
        public int? AssignedEngineerId { get; set; }
        [Column("AcceptedEngineerID")]
        public int? AcceptedEngineerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AcceptOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FinishedOn { get; set; }
        public bool? IsApproved { get; set; }
        public bool IsRecommended { get; set; }
        [StringLength(2000)]
        [Unicode(false)]
        public string? TaskRemarks { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? ServicePayBy { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("SERemarks")]
        [StringLength(1000)]
        public string? Seremarks { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("SerTbJobServiceDiagnostics")]
        public virtual TbPrmUserInfo CreatedByNavigation { get; set; } = null!;
        [ForeignKey("JobId")]
        [InverseProperty("SerTbJobServiceDiagnostics")]
        public virtual SerTbJobInfo Job { get; set; } = null!;
        [ForeignKey("ServiceId")]
        [InverseProperty("SerTbJobServiceDiagnostics")]
        public virtual SerTbPrmJobTask Service { get; set; } = null!;
    }
}
