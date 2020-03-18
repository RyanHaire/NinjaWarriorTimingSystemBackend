using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSystem.Domain
{
    public class Token
    {
        public int Id { get; set; }
        public string TokenString { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
