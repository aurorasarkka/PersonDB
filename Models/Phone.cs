using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDB.Models
{
    public partial class Phone
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string Phonenumber { get; set; }
        public bool? NotUsed { get; set; }
    }
}
