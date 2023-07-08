using System;
using System.Runtime.InteropServices;

namespace VtopAcademy.PracticeQuestions
{
	public class PracticeQuestion
	{
		public long VideoID { get; set; }

        public long examID { get; set; }

        public int number { get; set; }

        public String question { get; set; } = null!;

        public String optionA { get; set; } = null!;

        public String optionB { get; set; } = null!;

        public String optionC { get; set; } = null!;

        public String optionD { get; set; } = null!;

        public Option correctOption { get; set; } 
    }
}

