using System.Collections.Generic;

namespace Movies.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
