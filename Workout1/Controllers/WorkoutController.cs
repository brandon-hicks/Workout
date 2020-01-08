using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Workout1.Models;
using Workout1.Services;

namespace Workout1.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutServices _services;

        public WorkoutController(IWorkoutServices services)
        {
            _services = services;
        }
        
        [HttpPost]
        [Route("addExerciseItem")]
        public ActionResult<Exercise> Exercise(Exercise item)
        {
            var exerciseItem = _services.AddExercise(item);

            if (exerciseItem == null)
            {
                return NotFound();
            }
            return exerciseItem;
        }

        [HttpGet]
        [Route("getExerciseItems")]
        public ActionResult<IEnumerable<Exercise>> GetExerciseItems()
        {
            var exerciseItems = _services.GetExerciseItems().ToList();

            return !exerciseItems.Any() ? NoContent() : new ActionResult<IEnumerable<Exercise>>(exerciseItems);
        }

        [HttpDelete]
        [Route("deleteExercise/{name}")]
        public ActionResult DeleteExercise([FromRoute]string name)
        {
            _services.DeleteExercise(name);
            return NoContent();
        }
    }
}