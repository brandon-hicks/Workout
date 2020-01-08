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
    }
}