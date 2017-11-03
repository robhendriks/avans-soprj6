namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        public Guid LocationID { get; set; }

        public Guid LocationInspectionID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string LocationTitle { get; set; }

        [Column(TypeName = "text")]
        public string LocationDescription { get; set; }

        public double LocationLat { get; set; }

        public double LocationLong { get; set; }

        public virtual Inspection Inspection { get; set; }
    }
}
