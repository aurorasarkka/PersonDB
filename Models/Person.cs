using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDB.Models
{
    public partial class person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string EyeColor { get; set; }
        public int? ShoeSize { get; set; }
        public int? Height { get; set; }
    }
}
