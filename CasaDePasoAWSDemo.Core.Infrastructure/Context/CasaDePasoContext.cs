using CasaDePasoAWSDemo.Core.Domain.Functions.Modules.Login;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Infrastructure.Context
{
    public class CasaDePasoContext : DbContext
    {
        public CasaDePasoContext(DbContextOptions<CasaDePasoContext> options) : base(options)
        {
        }
        public DbSet<Fn_GetUserAccess> GetUserAccess { get; set; }
        public DbSet<Fn_GetUserPermision> GetUserPermision { get; set; }
        
        //Contexto de Hotel
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
            builder.Entity<Fn_GetUserAccess>().HasNoKey().ToView(null);
            builder.Entity<Fn_GetUserPermision>().HasNoKey().ToView(null);

            //Aplicamos de forma automatica las configuraciones que se encuentran en la carpeta CONFIGURACIONES
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
