using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSystem.Domain
{
    public class Time
    {
        public Time()
        {
        }

        public int Id { get; set; }
        [Column("date_time")]
        public DateTime DateTime { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Column("speed_wall_id")]
        public int SpeedWallId { get; set; }
        public SpeedWall SpeedWall { get; set; }
        public bool Competitive { get; set; }

    }
}
