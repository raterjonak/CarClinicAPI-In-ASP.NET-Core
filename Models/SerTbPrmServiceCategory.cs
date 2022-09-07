using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarClinicAPI.Repository.Models
{
    [Table("SER_TB_PrmServiceCategory")]
    public partial class SerTbPrmServiceCategory
    {
        public SerTbPrmServiceCategory()
        {
            InverseParent = new HashSet<SerTbPrmServiceCategory>();
            SerTbPrmJobTasks = new HashSet<SerTbPrmJobTask>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string? ServiceCategory { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual SerTbPrmServiceCategory? Parent { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<SerTbPrmServiceCategory> InverseParent { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<SerTbPrmJobTask> SerTbPrmJobTasks { get; set; }
    }
}
