namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        public int AnswerID { get; set; }

        public int AnswerQuestionID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string AnswerTitle { get; set; }

        [Column(TypeName = "text")]
        public string AnswerDescription { get; set; }

        public virtual Question Question { get; set; }
    }
}
