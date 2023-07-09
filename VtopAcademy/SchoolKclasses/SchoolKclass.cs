
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtopAcademy.SchoolKclasses
{
	public class SchoolKclass
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SchoolKclassID { get; set; }

        public long SchoolID { get; set; } 
        public long KclassID { get; set; }
    }
}

