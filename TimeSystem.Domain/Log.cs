using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSystem.Domain
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public User User { get; set; }
        public int Computer { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }

    }
}
