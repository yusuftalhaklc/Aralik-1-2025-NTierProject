using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        // Navigation Property
        public virtual AppUser AppUser { get; set; }
    }
}
