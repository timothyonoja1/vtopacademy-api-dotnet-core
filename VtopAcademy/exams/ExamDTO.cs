using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using VtopAcademy.schools;

namespace VtopAcademy.exams
{
    /// <summary> Data Transfer Object for Exam. </summary>
	public class ExamDTO
    {
        /// <summary> SchoolID. Default value is 0. </summary>
        [Display(Name = "ExamID")]
        public long ExamID { get; set; }

        /// <summary> Name </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        /// <summary> Number </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> SchoolID </summary>
        [Required]
        [Display(Name = "SchoolID")]
        public long SchoolID { get; set; }
    }
}

