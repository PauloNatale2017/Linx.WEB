using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.DataAccessLayer.dbContext
{
    public class dbContext :DbContext
    {

        public dbContext() : base("name=ConnetionDataBase"){}

        public DbSet<Linx.Domain.Mapping.Entities.Users> _Users { get; set; }
        public DbSet<Linx.Domain.Mapping.Entities.UserClaimsConseg> _UserClaimsConseg { get; set; }
        public DbSet<Linx.Domain.Mapping.Entities.Client> _Client { get; set; }
        public DbSet<Linx.Domain.Mapping.Entities.Token> _Token { get; set; }
        public DbSet<Linx.Domain.Mapping.Entities.ClientSecret> _ClientSecret { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }


    }
}
