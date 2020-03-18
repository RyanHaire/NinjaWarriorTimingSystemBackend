using System;
namespace TimeSystem.Domain
{
    public class Time
    {
        public Time()
        {
        }

        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public SpeedWall SpeedWall { get; set; }
        public bool Competitive { get; set; }

    }
}
