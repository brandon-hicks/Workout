namespace Workout1.Models
{
    public class Exercise
    {
        public string name { get; set; }
        public double weight { get; set; }    
        public double reps { get; set; }
        public double sets { get; set; }

        public Exercise()
        {
            name = "";
            weight = 0.0;
            reps = 0.0;
            sets = 0.0;
        }
    }
}