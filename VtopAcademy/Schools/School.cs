﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtopAcademy.Schools
{
	public class School
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SchoolID { get; set; }

        public string Name { get; set; } = null!;
        public int Number { get; set; }
    }
}

