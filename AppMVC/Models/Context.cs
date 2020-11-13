using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer(connectionString:
              @"Data Source=PAT1555\SQL2017; 
              Initial Catalog=AppMVC;
              User ID=supervisor;
              Password=senhas;
              Trusted_Connection=False;
              Connect Timeout=120;
              MultipleActiveResultSets=True;
              Application Name=PDVAlterdata.exe;
              Min Pool Size=5;
              Max Pool Size=250");
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

    }
}
