namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnswerInstance")]
    public partial class AnswerInstance
    {
        public Guid AnswerInstanceID { get; set; }

        public Guid AnswerInstanceQuestionInstanceID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string AnswerInstanceTitle { get; set; }

        [Column(TypeName = "text")]
        public string AnswerInstanceDescription { get; set; }

        public virtual QuestionInstance QuestionInstance { get; set; }
    }
}
