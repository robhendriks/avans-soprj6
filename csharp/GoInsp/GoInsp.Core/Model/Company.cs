namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            Inspections = new HashSet<Inspection>();
            Users = new HashSet<User>();
        }

        public int CompanyID { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(255)]
        public string CompanyEmail { get; set; }

        [StringLength(30)]
        public string CompanyPhone { get; set; }

        [StringLength(50)]
        public string CompanyAddress { get; set; }

        [StringLength(50)]
        public string CompanyCity { get; set; }

        [StringLength(30)]
        public string CompanyZip { get; set; }

        public bool? CompanyDefaultFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspection> Inspections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
