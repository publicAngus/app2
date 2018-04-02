using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using app2.DB.Models;

namespace app2.DB
{
    public class TestCustomDb:jumpmanjiContext{
        DbContextOptionsBuilder options;
        public TestCustomDb(DbContextOptions<jumpmanjiContext> options):base(options){
            this.options = new DbContextOptionsBuilder(options);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder = this.options;
            
        }

    }
}