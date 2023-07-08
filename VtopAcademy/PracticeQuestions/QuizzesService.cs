using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace VtopAcademy.PracticeQuestions
{
	public class QuizzesService
	{
        private readonly IMongoCollection<Quiz> _quizzesCollection;

        public QuizzesService(
            IOptions<QuizStoreDatabaseSettings> quizStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                quizStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                quizStoreDatabaseSettings.Value.DatabaseName);
             
            _quizzesCollection = mongoDatabase.GetCollection<Quiz>(
                quizStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Quiz>> GetAsync() =>
            await _quizzesCollection.Find(_ => true).ToListAsync();

        public async Task<Quiz?> GetAsync(string id) =>
            await _quizzesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Quiz newQuiz) =>
            await _quizzesCollection.InsertOneAsync(newQuiz);

        public async Task UpdateAsync(string id, Quiz updatedQuiz) =>
            await _quizzesCollection.ReplaceOneAsync(x => x.Id == id, updatedQuiz);

        public async Task RemoveAsync(string id) =>
            await _quizzesCollection.DeleteOneAsync(x => x.Id == id);
    }
}

