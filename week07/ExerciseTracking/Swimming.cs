using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;
        private const double LapLengthMeters = 50;
        private const double MetersToMilesFactor = 0.62137;

        public Swimming(DateTime date, double minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // laps * 50 meters -> km -> miles
            return (_laps * LapLengthMeters / 1000) * MetersToMilesFactor;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }
    }
}
