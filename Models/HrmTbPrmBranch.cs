using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("HRM_TB_PrmBranch")]
    public partial class HrmTbPrmBranch
    {
        public HrmTbPrmBranch()
        {
            HrmTbEmployeeInfos = new HashSet<HrmTbEmployeeInfo>();
        }

        [Key]
        [Column("BranchID")]
        public int BranchId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? BranchDesc { get; set; }

        [InverseProperty("Branch")]
        public virtual ICollection<HrmTbEmployeeInfo> HrmTbEmployeeInfos { get; set; }
    }
}
