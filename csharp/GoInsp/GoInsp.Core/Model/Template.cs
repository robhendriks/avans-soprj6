namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Template")]
    public partial class Template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Template()
        {
            Questions = new HashSet<Question>();
        }

        public int TemplateID { get; set; }

        public int? TemplateUserID { get; set; }

        [Required]
        [StringLength(50)]
        public string TemplateName { get; set; }

        [Column(TypeName = "text")]
        public string TemplateDescription { get; set; }

        public bool? TemplateDefaultFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }

        public virtual User User { get; set; }
    }
}
