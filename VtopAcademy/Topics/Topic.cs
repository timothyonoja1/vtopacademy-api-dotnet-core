using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtopAcademy.Topics
{
	public class Topic
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TopicID { get; set; }

        public string Name { get; set; } = null!;
        public int Number { get; set; }


        public long KclassID { get; set; }
        public long SubjectID { get; set; }
    }
}

