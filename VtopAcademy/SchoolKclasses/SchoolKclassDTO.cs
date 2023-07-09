using System;
using System.ComponentModel.DataAnnotations;

namespace VtopAcademy.SchoolKclasses
{
    /// <summary> Data Transfer Object for SchoolKclass. </summary>
    public class SchoolKclassDTO
    {
        /// <summary> SchoolKclassID. Default value is 0. </summary>
        [Display(Name = "SchoolKclassID")]
        public long SchoolKclassID { get; set; }

        /// <summary> SchoolID </summary>
        [Required]
        [Display(Name = "SchoolID")]
        public long SchoolID { get; set; }

        /// <summary> KclassID </summary>
        [Required]
        [Display(Name = "KclassID")]
        public long KclassID { get; set; }
    }
}

