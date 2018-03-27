using System;
using System.Collections.Generic;

namespace app2.DB.Models
{
    public partial class UsersItems
    {
        public long Id { get; set; }
        public long Userid { get; set; }
        public string ItemName { get; set; }
    }
}
