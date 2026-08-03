using System;

namespace ExerciseTracking
{
    // Base class containing attributes and behavior shared by all activities.
    public class Activity
    {
        private DateTime _date;
        private double _minutes;

        public Activity(DateTime date, double minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        // Exposed to derived classes so they can use it in their calculations,
        // but still not directly settable from outside (encapsulation).
        protected double Minutes => _minutes;

        // Declared here so every activity can be summarized the same way,
        // but each derived class must provide its own calculation.
        public virtual double GetDistance()
        {
            return 0;
        }

        public virtual double GetSpeed()
        {
            return 0;
        }

        public virtual double GetPace()
        {
            return 0;
        }

        // Shared by all activities; relies on the (overridden) calculation
        // methods above, so it does not need to be overridden itself.
        public virtual string GetSummary()
        {
            return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
                   $"Distance {GetDistance():F1} miles, " +
                   $"Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }
}
