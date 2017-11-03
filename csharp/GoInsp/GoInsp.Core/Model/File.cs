namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("File")]
    public partial class File
    {
        public Guid FileID { get; set; }

        public Guid FileInspectionID { get; set; }

        [Required]
        [StringLength(255)]
        public string FileFileName { get; set; }

        public virtual Inspection Inspection { get; set; }
    }
}
