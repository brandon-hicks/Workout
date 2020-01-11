using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Workout1.Models;

namespace Workout1.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IMongoCollection<Exercise> _exercises;

        public ExerciseRepository(IMongoDatabase db)
        {
            _exercises = db.GetCollection<Exercise>("Exercises");
        }

        public async Task<Exercise> AddExercise(Exercise exercise)
        {
            await _exercises.InsertOneAsync(exercise);
            return exercise;
        }

        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            return await _exercises.Find(_ => true).ToListAsync();
        }
        public async Task<Exercise> GetExercise(string id)
        {
            return await _exercises.Find(ex => ex.Id == id ).FirstAsync();
        }

        public async Task<Exercise> DeleteExercise(string name)
        {
            var recordToDelete = _exercises.AsQueryable().First(ex => ex.Id == name);
            await _exercises.DeleteOneAsync(ex => ex.Id == name);
            return recordToDelete;
        }
        public async Task<bool> DeleteAllExercises()
        {
            return _exercises.DeleteManyAsync(_ => true).IsCompletedSuccessfully;
        }
    }
}