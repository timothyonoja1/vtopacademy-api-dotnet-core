using System;
using System.ComponentModel.DataAnnotations;

namespace VtopAcademy.KclassSubjects
{
    /// <summary> Data Transfer Object for KclassSubject.</summary>
    public class KclassSubjectDTO
    {
        // <summary> KclassSubjectID. Default value is 0. </summary>
        [Display(Name = "KclassSubjectID")]
        public long KclassSubjectID { get; set; }

        /// <summary> KclassID </summary>
        [Required]
        [Display(Name = "KclassID")]
        public long KclassID { get; set; }

        /// <summary> SubjectID </summary>
        [Required]
        [Display(Name = "SubjectID")]
        public long SubjectID { get; set; }

    }
}

