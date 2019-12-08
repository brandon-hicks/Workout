using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Workout1.Models;
using Workout1.Services;

namespace WorkoutServices.Services
{
    public class WorkoutServices : IWorkoutServices
    {
        private readonly Dictionary<string, WorkoutItems> _workoutItems;

        public WorkoutServices()
        {
            _workoutItems = new Dictionary<string, WorkoutItems>();
        }
        public WorkoutItems AddWorkoutItems(WorkoutItems items)
        {
            _workoutItems.Add(items.name, items);

            return items;
        }

        public ActionResult<Dictionary<string, WorkoutItems>> GetWorkoutItems()
        {
            return _workoutItems;
        }
    }
}