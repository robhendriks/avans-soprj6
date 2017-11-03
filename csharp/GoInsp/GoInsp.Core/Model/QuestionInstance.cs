namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionInstance")]
    public partial class QuestionInstance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionInstance()
        {
            AnswerInstances = new HashSet<AnswerInstance>();
        }

        public Guid QuestionInstanceID { get; set; }

        [Required]
        [StringLength(30)]
        public string QuestionInstanceType { get; set; }

        public Guid QuestionInstanceInspectionID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string QuestionInstanceTitle { get; set; }

        [Column(TypeName = "text")]
        public string QuestionInstanceDescription { get; set; }

        [Column(TypeName = "text")]
        public string QuestionInstanceValue { get; set; }

        [Column(TypeName = "text")]
        public string QuestionInstanceComment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnswerInstance> AnswerInstances { get; set; }

        public virtual Inspection Inspection { get; set; }
    }
}
