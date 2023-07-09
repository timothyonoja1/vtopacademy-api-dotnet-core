using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using VtopAcademy.SubTopics;

namespace VtopAcademy.Videos
{
	public class VideoDTO
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VideoID { get; set; }

        public string QuizID { get; set; } = null!;
        public string MainYoutubeID { get; set; } = null!;
        public string CorrectionYoutubeID { get; set; } = null!;
        public bool IsFree { get; set; }

        public long SubTopicID { get; set; }

        [IgnoreDataMember]
        public virtual SubTopic SubTopic { get; set; } = null!;
    }
}

