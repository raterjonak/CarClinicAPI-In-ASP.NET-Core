using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("HRM_TB_PrmDesignation")]
    public partial class HrmTbPrmDesignation
    {
        public HrmTbPrmDesignation()
        {
            HrmTbEmployeeInfos = new HashSet<HrmTbEmployeeInfo>();
        }

        [Key]
        [Column("DesignationID")]
        public int DesignationId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? DesignationDesc { get; set; }

        [InverseProperty("Desg")]
        public virtual ICollection<HrmTbEmployeeInfo> HrmTbEmployeeInfos { get; set; }
    }
}
