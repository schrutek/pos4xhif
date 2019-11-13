using System;
using System.Collections.Generic;
using System.Text;

namespace SPG.CodeFirstApplication.Entities
{
    public class Pupil
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }

        public virtual Guid SchoolClassId { get; set; }
    }
}
