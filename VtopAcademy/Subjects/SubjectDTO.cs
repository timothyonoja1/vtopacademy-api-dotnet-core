using System;
using System.ComponentModel.DataAnnotations;

namespace VtopAcademy.Subjects
{
    /// <summary> Data Transfer Object for School. </summary>
    public class SubjectDTO
    {
        /// <summary> SubjectID. Default value is 0. </summary>
        public long SubjectID { get; set; }

        /// <summary> Name. </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        /// <summary> Number. </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> SchoolID. </summary>
        [Required]
        [Display(Name = "SchoolID")]
        public long SchoolID { get; set; }
    }
}

