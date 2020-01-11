using System.Collections.Generic;
using System.Threading.Tasks;
using Workout1.Models;

namespace Workout1.Repositories
{
    public interface IExerciseRepository
    {
        Task<Exercise> AddExercise(Exercise exercise);
        Task<IEnumerable<Exercise>> GetExercises();
        Task<Exercise> GetExercise(string id);
       Task<Exercise> DeleteExercise(string name);

       Task<bool> DeleteAllExercises();
       //Task<Exercise> UpdateExercise(Exercise exercise);
    }
}