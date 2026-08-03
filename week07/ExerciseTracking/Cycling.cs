using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed; // mph

        public Cycling(DateTime date, double minutes, double speed)
            : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetDistance()
        {
            return (GetSpeed() * Minutes) / 60;
        }

        public override double GetPace()
        {
            return 60 / GetSpeed();
        }
    }
}
