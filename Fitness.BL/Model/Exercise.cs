using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public Activity Activity{ get; set; }

        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException(nameof(activity));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
