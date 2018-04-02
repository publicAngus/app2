using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace app2.DB.Models
{
    public partial class jumpmanjiContext : DbContext
    {
        public jumpmanjiContext(DbContextOptions<jumpmanjiContext> options):base(options){

        }
    }
}
