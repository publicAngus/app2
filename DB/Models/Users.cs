using System;
using System.Collections.Generic;

namespace app2.DB.Models
{
    public partial class Users
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? IntVal { get; set; }
    }
}
