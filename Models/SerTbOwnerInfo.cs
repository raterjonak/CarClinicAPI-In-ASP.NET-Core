using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_OwnerInfo")]
    public partial class SerTbOwnerInfo
    {
        public SerTbOwnerInfo()
        {
            SerTbVehicleInfos = new HashSet<SerTbVehicleInfo>();
        }

        [Key]
        [Column("OwnerID")]
        public long OwnerId { get; set; }
        [Column("OwnerTypeID")]
        public int? OwnerTypeId { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? ContactName { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? CompanyName { get; set; }
        [Column("COCellPhone")]
        [StringLength(100)]
        [Unicode(false)]
        public string? CocellPhone { get; set; }
        [Column("COEmail")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Coemail { get; set; }
        [Column("COAddress")]
        [StringLength(150)]
        [Unicode(false)]
        public string? Coaddress { get; set; }
        [Column("CUName")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Cuname { get; set; }
        [Column("CUCellPhone")]
        [StringLength(50)]
        [Unicode(false)]
        public string? CucellPhone { get; set; }
        [Column("CUEmail")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Cuemail { get; set; }
        [Column("CUAddress")]
        [StringLength(150)]
        [Unicode(false)]
        public string? Cuaddress { get; set; }
        [Column("CUArea")]
        [StringLength(200)]
        [Unicode(false)]
        public string? Cuarea { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string? BillingAddress { get; set; }
        [Column("AssignedSalesPersonID")]
        public int? AssignedSalesPersonId { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? GroupOfCompany { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("SerTbOwnerInfos")]
        public virtual TbOwnerCategory? Category { get; set; }
        [ForeignKey("OwnerTypeId")]
        [InverseProperty("SerTbOwnerInfos")]
        public virtual TbOwnerType? OwnerType { get; set; }
        [InverseProperty("Owner")]
        public virtual ICollection<SerTbVehicleInfo> SerTbVehicleInfos { get; set; }
    }
}
