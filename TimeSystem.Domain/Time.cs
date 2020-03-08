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
        public Course Course { get; set; }
        public bool Competitive { get; set; }

    }
}
