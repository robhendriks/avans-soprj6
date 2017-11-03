namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionID { get; set; }

        public int QuestionTypeID { get; set; }

        public int QuestionTemplateID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string QuestionTitle { get; set; }

        [Column(TypeName = "text")]
        public string QuestionDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public virtual Template Template { get; set; }
    }
}
