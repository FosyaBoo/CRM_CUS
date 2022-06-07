﻿using System;
using System.Collections.Generic;

namespace CRM_CUS.Models
{
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
            Passports = new HashSet<Passport>();
            Phones = new HashSet<Phone>();
        }

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Birthplace { get; set; }
        public string? Gender { get; set; }
        public string? FullName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Passport> Passports { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
