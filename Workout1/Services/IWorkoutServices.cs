using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Workout1.Models;

namespace Workout1.Services
{
    public interface IWorkoutServices
    {
        WorkoutItems AddWorkoutItems(WorkoutItems items);
        ActionResult<Dictionary<string, WorkoutItems>> GetWorkoutItems();
    }
}