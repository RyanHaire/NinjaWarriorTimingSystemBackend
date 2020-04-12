using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSystem.Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public bool Admin { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public bool Hidden { get; set; }

        public bool Verified { get; set; }

        public virtual ICollection<Time> Times { get; set; }

    }
}
