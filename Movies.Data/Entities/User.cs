using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
