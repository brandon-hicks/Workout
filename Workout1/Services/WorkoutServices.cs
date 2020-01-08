using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Workout1.Models;
using Workout1.Services;

namespace WorkoutServices.Services
{
    public class WorkoutServices : IWorkoutServices
    {
        private List<Exercise> _exercisesDb;

        public WorkoutServices()
        {
            _exercisesDb = new List<Exercise>();
        }
        public Exercise AddExercise(Exercise item)
        {
            _exercisesDb.Add(item);

            return item;
        }

        public IEnumerable<Exercise> GetExerciseItems()
        {
            return _exercisesDb;
        }

        public void DeleteExercise(string name)
        {
            
            // Using name.Equals allows us to compare strings regardless of casing
            _exercisesDb.RemoveAll(ex => ex.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            // This does the same thing as above, without linq syntax
            // foreach (var ex in _exercisesDb)
            // {
            //     if (ex.name.Equals(name, StringComparison.OrdinalIgnoreCase))
            //     {
            //         _exercisesDb.Remove(ex);
            //     }
            // }
        }
    }
}