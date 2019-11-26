using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("grade")]
    public class Grade
    {
        [Key]
        [Column("grade_id")]
        public int GradeId { get; set; }
        [Column("grade_name")]
        public string GradeName { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
