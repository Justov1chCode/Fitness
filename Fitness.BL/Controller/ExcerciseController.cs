using Fitness.BL.Model;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class ExcerciseController : ControllerBase
    {
        private readonly User user;
        private const string EXCERCISES_FILE_NAME = "excercieses.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        public List<Exercise> Exercises;
        public List<Activity> Activities;

        public ExcerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(EXCERCISES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if(act == null)
            {
                Activities.Add(activity);

                var excercise = new Exercise(begin, end, activity, user);
                Exercises.Add(excercise);
            }
            else
            {
                var excercise = new Exercise(begin, end, act, user);
                Exercises.Add(excercise);
            }
            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXCERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXCERCISES_FILE_NAME, Exercises);
        }
    }
}
