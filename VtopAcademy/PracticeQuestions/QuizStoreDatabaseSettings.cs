using System;
namespace VtopAcademy.PracticeQuestions
{
	public class QuizStoreDatabaseSettings
	{
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BooksCollectionName { get; set; } = null!;
    }
}

