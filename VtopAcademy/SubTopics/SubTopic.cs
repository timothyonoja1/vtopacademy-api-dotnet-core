using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using VtopAcademy.Topics;

namespace VtopAcademy.SubTopics
{
	public class SubTopic
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubTopicID { get; set; }

        public string Name { get; set; } = null!;
        public int Number { get; set; }
        public bool IsFree { get; set; }


        public long TopicID { get; set; }

        [IgnoreDataMember]
        public virtual Topic Topic { get; set; } = null!;

    }
}

