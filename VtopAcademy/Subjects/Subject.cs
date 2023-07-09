using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using VtopAcademy.Schools;

namespace VtopAcademy.Subjects
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubjectID { get; set; }

        public string Name { get; set; } = null!;
        public int Number { get; set; }

        public long SchoolID { get; set; }

        [IgnoreDataMember]
        public virtual School School { get; set; } = null!;
    }
}