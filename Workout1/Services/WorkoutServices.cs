using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workout1.Models;
using Workout1.Repositories;
using Workout1.Services;

namespace WorkoutServices.Services
{
    public class WorkoutServices : IWorkoutServices
    {
        private readonly IExerciseRepository _repository;

        public WorkoutServices(IExerciseRepository repository)
        {
            _repository = repository;
        }
        
        public Exercise AddExercise(Exercise item)
        {
            _repository.AddExercise(item);

            return item;
        }

        public async Task<IEnumerable<Exercise>> GetExerciseItems()
        {
           return await _repository.GetExercises();
        }

        public async Task<Exercise> GetExerciseItem(string id)
        {
            return await _repository.GetExercise(id);
        }

        public async void DeleteExercise(string _id)
        {
            
            // Using name.Equals allows us to compare strings regardless of casing
            await _repository.DeleteExercise(_id);
            
            // This does the same thing as above, without linq syntax
            // foreach (var ex in _exercisesDb)
            // {
            //     if (ex.name.Equals(name, StringComparison.OrdinalIgnoreCase))
            //     {
            //         _exercisesDb.Remove(ex);
            //     }
            // }
        }

        public async Task<bool> DeleteAllExercises()
        {
            var result = await _repository.DeleteAllExercises();
            return result;
        }
    }
}