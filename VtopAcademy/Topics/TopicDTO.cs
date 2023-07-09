using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtopAcademy.Topics
{
    /// <summary> Data Transfer Object for Topic. </summary>
	public class TopicDTO
	{
        /// <summary> TopicID. Default value is 0. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TopicID { get; set; }

        /// <summary> Name </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        /// <summary> Number </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> KclassID </summary>
        [Required]
        [Display(Name = "KclassID")]
        public long KclassID { get; set; }

        /// <summary> Name </summary>
        [Required]
        [Display(Name = "SubjectID")]
        public long SubjectID { get; set; }
    }
}

