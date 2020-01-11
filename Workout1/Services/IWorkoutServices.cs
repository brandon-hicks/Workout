using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workout1.Models;

namespace Workout1.Services
{
    public interface IWorkoutServices
    {
        Exercise AddExercise(Exercise item);
        Task<IEnumerable<Exercise>> GetExerciseItems();
        Task<Exercise> GetExerciseItem(string id);
        void DeleteExercise(string Id);
        Task<bool> DeleteAllExercises();
    }
}