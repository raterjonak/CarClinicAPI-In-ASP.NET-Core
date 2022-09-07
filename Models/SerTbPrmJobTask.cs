using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_PrmJobTask")]
    public partial class SerTbPrmJobTask
    {
        public SerTbPrmJobTask()
        {
            SerTbJobServiceDiagnostics = new HashSet<SerTbJobServiceDiagnostic>();
        }

        [Key]
        [Column("TaskID")]
        public long TaskId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? Task { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? TaskCode { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("RootID")]
        public int? RootId { get; set; }

        [ForeignKey("ParentId")]
        [InverseProperty("SerTbPrmJobTasks")]
        public virtual SerTbPrmServiceCategory? Parent { get; set; }
        [InverseProperty("Service")]
        public virtual ICollection<SerTbJobServiceDiagnostic> SerTbJobServiceDiagnostics { get; set; }
    }
}
