using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalaaviMVC_DomainClasses.Users
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "نقش کاربر")]
        public string Title { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
