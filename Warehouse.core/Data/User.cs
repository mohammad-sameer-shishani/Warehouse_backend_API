using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Supplydocuments = new HashSet<Supplydocument>();
            Warehouses = new HashSet<Warehouse>();
        }

        public decimal Userid { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Passwordhashed { get; set; } = null!;
        public string Usertype { get; set; } = null!;
        public DateTime? Createddate { get; set; }

        public virtual ICollection<Supplydocument> Supplydocuments { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
