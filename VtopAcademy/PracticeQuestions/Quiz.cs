using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VtopAcademy.PracticeQuestions
{
	public class Quiz
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public long VideoID { get; set; }

        public List<PracticeQuestion>? PracticeQuestions { get; set; }
    }
}

