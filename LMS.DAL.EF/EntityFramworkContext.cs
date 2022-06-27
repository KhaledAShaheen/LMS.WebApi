using LMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.EF
{

    public class EntityFramworkContext : DbContext
    {
        public EntityFramworkContext() : base()
        {

        }
        
        public EntityFramworkContext(DbContextOptions<EntityFramworkContext> options) : base(options)
        {

        }
       
        // Entities        
        public DbSet<BookEntity> BookEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public object BookEntity { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LMS;Integrated Security=True");
            
        }

    }
}

