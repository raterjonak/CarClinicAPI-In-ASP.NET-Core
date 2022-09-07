using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("HRM_TB_PrmDepartment")]
    public partial class HrmTbPrmDepartment
    {
        public HrmTbPrmDepartment()
        {
            HrmTbEmployeeInfos = new HashSet<HrmTbEmployeeInfo>();
        }

        [Key]
        [Column("DeptID")]
        public int DeptId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Department { get; set; }

        [InverseProperty("Dept")]
        public virtual ICollection<HrmTbEmployeeInfo> HrmTbEmployeeInfos { get; set; }
    }
}
