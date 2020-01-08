using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Workout1.Models;

namespace Workout1.Services
{
    public interface IWorkoutServices
    {
        Exercise AddExercise(Exercise item);
        IEnumerable<Exercise> GetExerciseItems();
    }
}