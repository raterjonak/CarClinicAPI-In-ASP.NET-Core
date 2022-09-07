using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("TB_PrmUserRole")]
    public partial class TbPrmUserRole
    {
        public TbPrmUserRole()
        {
            TbPrmUserInfos = new HashSet<TbPrmUserInfo>();
        }

        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? RoleDesc { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<TbPrmUserInfo> TbPrmUserInfos { get; set; }
    }
}
