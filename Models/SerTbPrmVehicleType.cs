using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_PrmVehicleType")]
    public partial class SerTbPrmVehicleType
    {
        public SerTbPrmVehicleType()
        {
            SerTbVehicleInfos = new HashSet<SerTbVehicleInfo>();
        }

        [Key]
        [Column("VehicleTypeID")]
        public int VehicleTypeId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? VehicleType { get; set; }
        public bool? CommercialVehicle { get; set; }

        [InverseProperty("VehicleType")]
        public virtual ICollection<SerTbVehicleInfo> SerTbVehicleInfos { get; set; }
    }
}
