using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtopAcademy.KclassSubjects
{
	public class KclassSubject
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long KclassSubjectID { get; set; }

        public long KclassID { get; set; }
        public long SubjectID { get; set; } 
    }
}

