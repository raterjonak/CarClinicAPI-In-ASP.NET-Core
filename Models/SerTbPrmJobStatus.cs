using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_PrmJobStatus")]
    public partial class SerTbPrmJobStatus
    {
        public SerTbPrmJobStatus()
        {
            SerTbJobInfos = new HashSet<SerTbJobInfo>();
        }

        [Key]
        [Column("JobStatusID")]
        public int JobStatusId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? JobStatus { get; set; }

        [InverseProperty("JobStatus")]
        public virtual ICollection<SerTbJobInfo> SerTbJobInfos { get; set; }
    }
}
