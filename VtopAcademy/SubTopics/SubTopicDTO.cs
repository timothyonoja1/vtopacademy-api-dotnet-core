using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtopAcademy.SubTopics
{
    /// <summary> Data Transfer Object for SubTopic. </summary>
    public class SubTopicDTO
    {
        /// <summary> SubjectID. Default value is 0. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubTopicID { get; set; }

        /// <summary> Name </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        /// <summary> Number </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> IsFree </summary>
        [Required]
        [Display(Name = "IsFree")]
        public bool IsFree { get; set; }

        ///<summary> Hypen-joined KclassID and SubjectID </summary>
        /// <summary> Name. </summary>
        [Required]
        [Display(Name = "TopicID")]
        public long TopicID { get; set; }
    }
}

