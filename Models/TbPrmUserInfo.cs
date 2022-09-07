using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("TB_PrmUserInfo")]
    public partial class TbPrmUserInfo
    {
        public TbPrmUserInfo()
        {
            SerTbJobInfos = new HashSet<SerTbJobInfo>();
            SerTbJobServiceDiagnostics = new HashSet<SerTbJobServiceDiagnostic>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("LoginID")]
        [StringLength(50)]
        [Unicode(false)]
        public string? LoginId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("RoleID")]
        public int? RoleId { get; set; }
        [Column("EmpAutoID")]
        public int? EmpAutoId { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public byte? LoginSuccess { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LoginTime { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? HostName { get; set; }
        [Column("IPAddress")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Ipaddress { get; set; }
        public bool? Active { get; set; }

        [ForeignKey("EmpAutoId")]
        [InverseProperty("TbPrmUserInfos")]
        public virtual HrmTbEmployeeInfo? EmpAuto { get; set; }
        [ForeignKey("RoleId")]
        [InverseProperty("TbPrmUserInfos")]
        public virtual TbPrmUserRole? Role { get; set; }
        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<SerTbJobInfo> SerTbJobInfos { get; set; }
        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<SerTbJobServiceDiagnostic> SerTbJobServiceDiagnostics { get; set; }
    }
}
