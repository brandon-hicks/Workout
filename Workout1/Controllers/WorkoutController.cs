using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Workout1.Models;
using Workout1.Services;

namespace Workout1.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutServices _services;

        public WorkoutController(IWorkoutServices services)
        {
            _services = services;
        }
        
        [HttpPost]
        [Route("AddWorkoutItems")]
        public ActionResult<WorkoutItems> AddWorkoutItems(WorkoutItems items)
        {
            var workoutItems = _services.AddWorkoutItems(items);

            if (workoutItems == null)
            {
                return NotFound();
            }
            return workoutItems;
        }

        [HttpGet]
        [Route("GetWorkoutItems")]
        public ActionResult<Dictionary<string, WorkoutItems>> GetWorkoutItems()
        {
            var workoutItems = _services.GetWorkoutItems();

            if (workoutItems == null)
            {
                return NotFound();
            }

            return workoutItems;
        }
    }
}