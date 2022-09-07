using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("HRM_TB_EmployeeInfo")]
    public partial class HrmTbEmployeeInfo
    {
        public HrmTbEmployeeInfo()
        {
            TbPrmUserInfos = new HashSet<TbPrmUserInfo>();
        }

        [Key]
        [Column("EmpAutoID")]
        public int EmpAutoId { get; set; }
        [Column("EmpID")]
        [StringLength(50)]
        [Unicode(false)]
        public string? EmpId { get; set; }
        [Column("FingerPrintID")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FingerPrintId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? MiddleName { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? PreAddress { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? PerAddress { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? FatherName { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? MotherName { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Nationality { get; set; }
        [Column("NationalID")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NationalId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Religion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [Column("DesgID")]
        public int? DesgId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? JoiningDate { get; set; }
        [StringLength(5)]
        [Unicode(false)]
        public string? BloodGrp { get; set; }
        public bool? Sex { get; set; }
        public bool? Married { get; set; }
        [Column("TIN")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Tin { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? Reference { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PicPath { get; set; }
        [Column("DeptID")]
        public int? DeptId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Email2 { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Email3 { get; set; }
        [Column("IPAddress")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Ipaddress { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Telephone { get; set; }
        [Column("PABX")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Pabx { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TerminationDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? EmployeeStatus { get; set; }
        [Column("BranchID")]
        public int? BranchId { get; set; }
        [Column(TypeName = "image")]
        public byte[]? EmpPicture { get; set; }
        public byte[]? EmpSignature { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(120)]
        [Unicode(false)]
        public string? EmerPerson { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? SpouseName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? EmerPhone { get; set; }
        [StringLength(100)]
        public string? EmerRelation { get; set; }
        [Column("SupervisorID")]
        public int? SupervisorId { get; set; }
        [Column("LeaveApproverID")]
        public int? LeaveApproverId { get; set; }
        public bool? EmpDeleted { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LoginName { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Transfer { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Company { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? WorkType { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CellPhoneNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PermanentOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProbationTill { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ResignedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransferredOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TemporaryTill { get; set; }
        public bool? IsOnTraining { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? EmpSalary { get; set; }
        [Column("SalaryACNo")]
        [StringLength(50)]
        [Unicode(false)]
        public string? SalaryAcno { get; set; }

        [ForeignKey("BranchId")]
        [InverseProperty("HrmTbEmployeeInfos")]
        public virtual HrmTbPrmBranch? Branch { get; set; }
        [ForeignKey("DeptId")]
        [InverseProperty("HrmTbEmployeeInfos")]
        public virtual HrmTbPrmDepartment? Dept { get; set; }
        [ForeignKey("DesgId")]
        [InverseProperty("HrmTbEmployeeInfos")]
        public virtual HrmTbPrmDesignation? Desg { get; set; }
        [InverseProperty("EmpAuto")]
        public virtual ICollection<TbPrmUserInfo> TbPrmUserInfos { get; set; }
    }
}
