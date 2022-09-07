using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("INV_TB_PrmEngine")]
    public partial class InvTbPrmEngine
    {
        public InvTbPrmEngine()
        {
            InvTbPartInfos = new HashSet<InvTbPartInfo>();
        }

        [Key]
        [Column("PartEngineID")]
        public int PartEngineId { get; set; }
        [Column("ModelID")]
        public int? ModelId { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string? PartEngine { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? Fuel { get; set; }
        public int? VehicleType { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? EngineType { get; set; }
        public int? NumberOfCylinder { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? SalesDesignation { get; set; }
        public int? LubCapacity { get; set; }
        [StringLength(50)]
        public string? PartPrefix { get; set; }

        [InverseProperty("Engine")]
        public virtual ICollection<InvTbPartInfo> InvTbPartInfos { get; set; }
    }
}
