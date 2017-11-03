namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inspection")]
    public partial class Inspection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inspection()
        {
            Files = new HashSet<File>();
            Locations = new HashSet<Location>();
            QuestionInstances = new HashSet<QuestionInstance>();
        }

        public Guid InspectionID { get; set; }

        public int InspectionTypeID { get; set; }

        public int? InspectionUserID { get; set; }

        public int? InspectionCompanyID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string InspectionTitle { get; set; }

        [Column(TypeName = "text")]
        public string InspectionDescription { get; set; }

        public DateTime? InspectionStartTime { get; set; }

        public DateTime? InspectionEndTime { get; set; }

        public virtual Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<File> Files { get; set; }

        public virtual InspectionType InspectionType { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Locations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionInstance> QuestionInstances { get; set; }
    }
}
