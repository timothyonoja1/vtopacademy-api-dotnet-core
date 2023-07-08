
using System;
using System.ComponentModel.DataAnnotations;

namespace VtopAcademy.kclasses
{
    /// <summary> Data Transfer Object for Kclass. </summary>
    public class KclassDTO
    {
        /// <summary> SchoolID. Default value is 0. </summary>
        [Display(Name = "Id")]
        public long KclassId { get; set; }

        /// <summary> Name </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

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

